using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ExerciseB.API;
using Newtonsoft.Json;
using Xunit;

namespace ExerciseB.UnitTesting
{
    public class ExerciseBControllerTest
    {
        [Fact]
        public void Test1()
        {
            var sampleList1 = SampleGenerator.GenerateCustomSampleList(500000, 0, 20);
            var sampleList2 = SampleGenerator.GenerateSampleList2();

            var newSampleList = (from s1 in sampleList1
                                 join s2 in sampleList2
                                     on s1.Id equals s2.Id
                                 select new Sample
                                 {
                                     Id = s1.Id,
                                     Content = s1.Content,
                                     Qty = s1.Qty
                                 }).ToList();

            Assert.NotEmpty(newSampleList);
        }

        [Fact]
        public void Test2()
        {
            using WebClient client = new WebClient();
            var json = client.DownloadString("https://localhost:44353/ExerciseB/getJson");

            var sampleList = JsonConvert.DeserializeObject<IEnumerable<Sample>>(json);

            Assert.NotEmpty(sampleList);
        }

        [Fact]
        public void Test3_IfSampleListCorrect()
        {
            var sampleList = SampleGenerator.GenerateCustomSampleList(400000, 1, 20);
            int qtyTotal = (from s in sampleList
                            select s.Qty).Sum();

            var result = ParallelExercise(sampleList);

            Assert.Equal(qtyTotal, result);
        }

        [Fact]
        public void Test3_OutOfRangeException()
        {
            var sampleList = SampleGenerator.GenerateCustomSampleList(1000, 20, 30);
            long qtyTotal = (from s in sampleList
                             select s.Qty).Sum();

            var result = ParallelExercise(sampleList);

            // Assert: should fail and throw ArgumentOutOfRangeException (check test explorer message)
        }

        [Fact]
        public void Test3_NullException()
        {
            var sampleList = SampleGenerator.GenerateCustomSampleList(1000, 0, 10);
            long qtyTotal = (from s in sampleList
                             select s.Qty).Sum();

            var result = ParallelExercise(sampleList);

            // Assert: should fail and throw ArgumentNullException (check test explorer message)
        }

        [Fact]
        public void Test3_Cancellation()
        {
            var sampleList = SampleGenerator.GenerateCustomSampleList(1000, 1, 10);
            long qtyTotal = (from s in sampleList
                             select s.Qty).Sum();

            var result = ParallelExercise(sampleList, true);

            // Assert: should fail and throw OperationCanceledException (check test explorer message)
        }

        #region Private Methods

        private int ParallelExercise(IEnumerable<Sample> sampleList, bool shouldCancel = false)
        {
            int sum = 0;
            CancellationTokenSource cts = new CancellationTokenSource();
            var po = new ParallelOptions
            {
                CancellationToken = cts.Token,
                MaxDegreeOfParallelism = 10
            };

            try
            {
                sum = SumQtyInParallel(sampleList, po, cts, shouldCancel);
            }
            catch (AggregateException ae)
            {
                var ignoredExceptions = new List<Exception>();

                foreach (var ex in ae.Flatten().InnerExceptions)
                {
                    if (ex is ArgumentOutOfRangeException)
                    {
                        throw ex; // or do something
                    }
                    else if (ex is ArgumentNullException)
                    {
                        throw ex; // or do something
                    }
                    else if (ex is OperationCanceledException)
                    {
                        throw ex; // or do something
                    }
                    else
                    {
                        ignoredExceptions.Add(ex);
                    }
                }

                if (ignoredExceptions.Count > 0) throw new AggregateException(ignoredExceptions);
            }

            return sum;
        }

        private int SumQtyInParallel(IEnumerable<Sample> sampleList, ParallelOptions po, CancellationTokenSource cts, bool shouldCancel)
        {
            int sum = 0;
            var exceptions = new ConcurrentQueue<Exception>();

            Parallel.ForEach(sampleList,
            () =>
            {
                return 0;
            },
            (sample, state, subtotal) =>
            {
                po.CancellationToken.ThrowIfCancellationRequested();

                if (shouldCancel)
                    cts.Cancel();

                if (sample.Qty > 20)
                    exceptions.Enqueue(new ArgumentOutOfRangeException());
                else if (sample.Qty == 0)
                    exceptions.Enqueue(new ArgumentNullException());

                return subtotal += sample.Qty;
            },
            (subtotal) =>
            {

                lock (sampleList)
                {
                    sum += subtotal;
                }
            });

            cts.Dispose();

            if (exceptions.Count > 0) throw new AggregateException(exceptions);

            return sum;
        }
        #endregion
    }
}
