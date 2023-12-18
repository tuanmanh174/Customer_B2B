using CustomerB2B.Services.CompanyDocumentInfo;
using CustomerB2B.Services.CompanyRepresentativeInfo;
using CustomerB2B.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerB2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyRepresentativeController : ControllerBase
    {
        private readonly ICompanyRepresentativeInfo _companyRepresentativeInfo;
        public CompanyRepresentativeController(ICompanyRepresentativeInfo companyRepresentativeInfo)
        {
            _companyRepresentativeInfo = companyRepresentativeInfo;
        }

        [HttpGet]
        public IActionResult Get(string companyId)
        {
            var lstCompanyRepresentative = _companyRepresentativeInfo.GetAll(companyId);
            return Ok(lstCompanyRepresentative);
        }


        [HttpPost]
        public IActionResult Post([FromBody] CompanyRepresentativeInsertInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyRepresentativeInfo.InsertCompanyRepresentative(data);
            return Ok(res);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(string id, [FromBody] CompanyRepresentativeUpdateInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyRepresentativeInfo.UpdateCompanyRepresentative(data, id);
            return Ok(res);
        }


    }
}
