using CustomerB2B.Services.CompanyGroupInfo;
using CustomerB2B.Services.CompanyInfo;
using CustomerB2B.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerB2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyInfo _companyInfo;
        public CompanyController(ICompanyInfo companyInfo)
        {
            _companyInfo = companyInfo;
        }

        [HttpGet]
        public IActionResult Get(int pageNumber, int pageSize)
        {
            var lstCompany = _companyInfo.GetAll(pageNumber, pageSize);
            return Ok(lstCompany);
        }

        [HttpGet("id")]
        public IActionResult GetById(string id)
        {
            var lstCompany = _companyInfo.GetCompanyById(id);
            return Ok(lstCompany);
        }

        [HttpPost]
        public IActionResult Post(string userName, [FromBody] CompanyInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyInfo.InsertCompany(data, userName);
            return Ok(res);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(string id, string userName, [FromBody] CompanyInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyInfo.UpdateCompany(data, id, userName);
            return Ok(res);
        }

        [HttpPost("delete/{id}")]
        public IActionResult Remove(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyInfo.DeleteCompany(id);
            return Ok(res);
        }
    }
}
