using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using SchoolManagement.DataAccess.Interfaces;
using StudentManagement.Models;
using System.Net;
using System.Net.Http.Headers;

namespace StudentManagement.SecureMessage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public IMessageSender _messageSender;
        private readonly IEmployeeDept _employeeDept;

        public WeatherForecastController(IMessageSender messageSender, IEmployeeDept employeeDept)
        {
            _messageSender = messageSender;
            _employeeDept = employeeDept;
        }

        [HttpPost]
        [Route("MessagePost")]
        public async Task MessagePost() {
            _messageSender.Send("Azure Key Vault Secrets added!! Hello World!");
        }

        [HttpGet]
        [Route("MessageGet")]
        public void MessageGet() 
        {
            var azureCredentialOption = new DefaultAzureCredentialOptions();
            azureCredentialOption.SharedTokenCacheUsername = "prakash@ca10prakashgmail.onmicrosoft.com";

            var credentials = new DefaultAzureCredential(azureCredentialOption);
            var keyVaultClient = new KeyVaultClient(async (authority, resource, scope) =>
            {
                var credential = new DefaultAzureCredential(false);
                var token = await credential.GetTokenAsync(
                    new Azure.Core.TokenRequestContext(new[] { "https://vault.azure.net/.default" }, null));
                return token.Token;
            });
        }

        [HttpGet]
        [Route("GetEmployeeDetail")]
        public IActionResult GetEmployeeDetail()
        {
            var data = new Employees() { EmployeeID = 1, FirstName = "Prakash", LastName = "Shrivastav" };
            return Ok(data);
            
        }


        [HttpGet]
        [Route("GetJson")]
        public IActionResult GetJson()
        {
            var data = new { message = "Hello, JSON!" };
            //var response = Request(HttpStatusCode.OK, data);
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return Ok(data);
        }

        [HttpGet("{id:int}.{format?}")]
        public Employees? GetById(int id)
        => _employeeDept.GetEmployeeById(id);

        [HttpOptions]
        [Route("GetJson")]
        public IActionResult GetJsonOption()
        {
            var data = new { message = "Hello, JSON! OPTION" };
            //var response = Request(HttpStatusCode.OK, data);
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return Ok(data);
        }

        [HttpGet("{id}")]
        [ProducesResponseType<Employees>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById_IActionResult(int id)
        {
            var product = _employeeDept.GetEmployeeById(id);
            return product == null ? NotFound() : Ok(product);
        }
    }
}
