using CustomerB2B.Services.CompanyDocumentInfo;
using CustomerB2B.Services.CompanyGroupInfo;
using CustomerB2B.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerB2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDocumentController : ControllerBase
    {
        private readonly ICompanyDocumentInfo _companyDocumentInfo;
        public CompanyDocumentController(ICompanyDocumentInfo companyDocumentInfo)
        {
            _companyDocumentInfo = companyDocumentInfo;
        }

        [HttpGet]
        public IActionResult Get(string companyId)
        {
            var lstCompanyGroup = _companyDocumentInfo.GetAll(companyId);
            return Ok(lstCompanyGroup);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var lstCompanyGroup = _companyDocumentInfo.GetCompanyDocumentById(id);
            return Ok(lstCompanyGroup);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CompanyDocumentInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyDocumentInfo.InsertCompanyDocument(data);
            return Ok(res);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(string id, [FromBody] CompanyDocumentInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyDocumentInfo.UpdateCompanyDocument(data, id);
            return Ok(res);
        }

        [HttpPost("delete/{id}")]
        public IActionResult Remove(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyDocumentInfo.DeleteCompnayDocument(id);
            return Ok(res);
        }
    }
}
