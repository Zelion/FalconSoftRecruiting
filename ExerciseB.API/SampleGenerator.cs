using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;

namespace ExerciseB.API
{
    public static class SampleGenerator
    {
        public static IEnumerable<Sample> GenerateCustomSampleList(int amount, int minQty, int maxQty)
        {
            var sampleIds = 1;
            var sample = new Faker<Sample>()
                .RuleFor(m => m.Id, f => sampleIds++.ToString())
                .RuleFor(m => m.Content, f => f.Commerce.ProductName())
                .RuleFor(m => m.Qty, f => f.Random.Int(minQty, maxQty));
            return sample.GenerateBetween(amount, amount);
        }

        public static IEnumerable<Sample> GenerateSampleList2()
        {
            var sampleIds = 400000;
            var sample = new Faker<Sample>()
                .RuleFor(m => m.Id, f => sampleIds++.ToString())
                .RuleFor(m => m.Content, f => f.Commerce.ProductName())
                .RuleFor(m => m.Qty, f => f.Random.Int(0, 20));
            return sample.GenerateBetween(500000, 500000);
        }
    }
}
