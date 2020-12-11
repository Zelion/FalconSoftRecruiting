using System.Text;
using ExerciseB.API;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExerciseB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseBController : ControllerBase
    {

        public ExerciseBController()
        {
        }

        [HttpGet("getJson")]
        public string GetJson()
        {
            var sampleList = SampleGenerator.GenerateCustomSampleList(3050000, 0, 20);

            var json = JsonConvert.SerializeObject(sampleList);
            var size = Encoding.Unicode.GetByteCount(json); // just to check size

            return json;
        }
    }
}
