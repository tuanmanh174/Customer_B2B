using CustomerB2B.Services.CompanyTypeCompanyInfo;
using CustomerB2B.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerB2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypeCompanyController : ControllerBase
    {
        private readonly ICompanyTypeCompanyInfo _companyTypeCompanyInfo;
        public CompanyTypeCompanyController(ICompanyTypeCompanyInfo companyTypeCompanyInfo)
        {
            _companyTypeCompanyInfo = companyTypeCompanyInfo;
        }


        [HttpPost]
        public IActionResult Post([FromBody] CompanyTypeCompanyInfoViewModel data)
        {
            var res = _companyTypeCompanyInfo.InsertCompanyTypeCompany(data);
            return Ok(res);
        }

        [HttpPost("delelte")]
        public IActionResult Delete(string companyId, string companyTypeId)
        {
            var res = _companyTypeCompanyInfo.RemoveCompanyTypeCompany(companyId, companyTypeId);
            return Ok(res);
        }
    }
}
