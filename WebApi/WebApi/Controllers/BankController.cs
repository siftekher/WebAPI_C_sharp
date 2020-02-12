using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.DataManager;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly ILogger<BankController> _logger;
        private IRepositoryWrapper _repoWrapper;

        public BankController(ILogger<BankController> logger, IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
        }

       
        // GET: api/Bank/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            //return "value";
            try
            {
                var customer = _repoWrapper.Customer.GetCustomer(id);

                _logger.LogInformation($"Returned all Customer from database.");

                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            try
            {
                var owners = _repoWrapper.Customer.GetAllCustomer();

                _logger.LogInformation($"Returned all Customer from database.");

                return Ok(owners);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            try
            {
                _logger.LogError($" FROM POST API    **********     :");
                _repoWrapper.Customer.Update(customer);
                _repoWrapper.Save();

                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Post action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Bank/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            var customer = _repoWrapper.Customer.GetCustomer(id);

            _repoWrapper.Customer.Delete(customer);
            _repoWrapper.Save();


            return Ok();
        }
    }
}
