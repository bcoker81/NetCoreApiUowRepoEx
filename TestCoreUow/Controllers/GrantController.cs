using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCoreUow.Contracts;
using TestCoreUow.Entities;

namespace TestCoreUow.Controllers
{
    [Route("api/grant")]
    [ApiController]
    public class GrantController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public GrantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAllGrants()
        {
            List<Grants> grantList = _unitOfWork.GrantRepository.Get();

            return Ok(grantList);
        }

        [HttpGet]
        [Route("details/{gId}")]
        public IActionResult Details(int gId)
        {
            List<Grants> grantList = new List<Grants>();
            try
            {
                grantList = _unitOfWork.GrantRepository.Get(m => m.Id == gId, null, includes: p => p.Comments);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fuck you.");
                throw;
            }
            return Ok(grantList);
        }

        [HttpGet]
        [Route("get/{grantNumber}")]
        public IActionResult Get(string grantNumber)
        {
           IEnumerable<Grants> grant = _unitOfWork.GrantRepository.Get(m => m.MshpGrantNumber == grantNumber);

            return Ok(grant);
        }

        [HttpPost]
        [Route("newGrant")]
        public ActionResult Post([FromBody] Grants grants)
        {
            _unitOfWork.GrantRepository.Insert(grants);
            _unitOfWork.Save();
            return Ok();
        }
    }
}