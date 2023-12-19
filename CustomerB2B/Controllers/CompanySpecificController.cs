using CustomerB2B.Services.CompanyAdditionalInfo;
using CustomerB2B.Services.ICompanySpecificInfo;
using CustomerB2B.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerB2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanySpecificController : ControllerBase
    {
        private readonly ICompanySpecificInfo _companySpecificInfo;
        public CompanySpecificController(ICompanySpecificInfo companySpecificInfo)
        {
            _companySpecificInfo = companySpecificInfo;
        }

        [HttpGet]
        public IActionResult Get(string companyId)
        {
            var lstCompanySpecific = _companySpecificInfo.GetAll(companyId);
            return Ok(lstCompanySpecific);
        }


        [HttpPost]
        public IActionResult Post([FromBody] CompanySpecificInsertInformationInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companySpecificInfo.InsertCompanySpecific(data);
            return Ok(res);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(string id, [FromBody] CompanySpecificUpdateInformationInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companySpecificInfo.UpdateCompanySpecific(data, id);
            return Ok(res);
        }

        [HttpPost("delete/{id}")]
        public IActionResult Remove(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companySpecificInfo.DeleteCompnaySpecific(id);
            return Ok(res);
        }
    }
}
