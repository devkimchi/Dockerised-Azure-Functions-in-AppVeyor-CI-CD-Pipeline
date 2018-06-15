using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Dockerised.FunctionApp
{
    public static class TestHttpTrigger
    {
        [FunctionName(nameof(TestHttpTrigger))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "test")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var name = req.Query["name"];

            if (string.IsNullOrWhiteSpace(name))
            {
                return new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }

            return new OkObjectResult($"Hello, {name}");
        }
    }
}