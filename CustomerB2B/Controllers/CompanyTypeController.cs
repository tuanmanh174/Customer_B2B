using CustomerB2B.Services.CompanyDocumentInfo;
using CustomerB2B.Services.CompanyGroupInfo;
using CustomerB2B.Services.CompanyTypeInfo;
using CustomerB2B.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerB2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypeController : ControllerBase
    {
        private readonly ICompanyTypeInfo _companyTypeInfo;
        public CompanyTypeController(ICompanyTypeInfo companyTypeInfo)
        {
            _companyTypeInfo = companyTypeInfo;
        }

        [HttpGet]
        public IActionResult Get(int pageNumber, int pageSize)
        {
            var lstCompanyGroup = _companyTypeInfo.GetAll(pageNumber, pageSize);
            return Ok(lstCompanyGroup);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var lstCompanyGroup = _companyTypeInfo.GetCompanyTypeById(id);
            return Ok(lstCompanyGroup);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CompanyTypeInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyTypeInfo.InsertCompanyType(data);
            return Ok(res);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(string id, [FromBody] CompanyTypeInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyTypeInfo.UpdateCompanyType(data, id);
            return Ok(res);
        }

        [HttpPost("delete/{id}")]
        public IActionResult Remove(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyTypeInfo.DeleteCompanyType(id);
            return Ok(res);
        }
    }
}
