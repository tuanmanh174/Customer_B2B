using CustomerB2B.Services.CompanyAdditionalInfo;
using CustomerB2B.Services.CompanyInfo;
using CustomerB2B.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerB2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyAdditionalController : ControllerBase
    {
        private readonly ICompanyAdditionalInfo _companyAdditionalInfo;
        public CompanyAdditionalController(ICompanyAdditionalInfo companyAdditionalInfo)
        {
            _companyAdditionalInfo = companyAdditionalInfo;
        }

        [HttpGet]
        public IActionResult Get(string companyId)
        {
            var lstCompanyAdditional = _companyAdditionalInfo.GetAll(companyId);
            return Ok(lstCompanyAdditional);
        }


        [HttpGet]
        public IActionResult GetByCompanyId(string companyId)
        {
            var companyAdditional = _companyAdditionalInfo.GetCompnayAdditionalById(companyId);
            return Ok(companyAdditional);
        }


        [HttpPost]
        public IActionResult Post([FromBody] CompanyAdditionalInsertInformationInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyAdditionalInfo.InsertCompanyAdditional(data);
            return Ok(res);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(string id, [FromBody] CompanyAdditionalUpdateInformationInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyAdditionalInfo.UpdateCompanyAdditional(data, id);
            return Ok(res);
        }

        [HttpPost("delete/{id}")]
        public IActionResult Remove(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyAdditionalInfo.DeleteCompnayAdditional(id);
            return Ok(res);
        }
    }
}
