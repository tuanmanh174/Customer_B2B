using CustomerB2B.Services.CompanyGroupInfo;
using CustomerB2B.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerB2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyGroupController : ControllerBase
    {
        ICompanyGroupInfo _companyGroupInfo;
        public CompanyGroupController(ICompanyGroupInfo companyGroupInfo)
        {
            _companyGroupInfo = companyGroupInfo;
        }

        [HttpGet]
        public IActionResult Get(int pageNumber, int pageSize)
        {
            var lstCompanyGroup = _companyGroupInfo.GetAll(pageNumber, pageSize);
            return Ok(lstCompanyGroup);
        }

        [HttpGet("id")]
        public IActionResult GetById(string id)
        {
            var lstCompanyGroup = _companyGroupInfo.GetCompanyGroupById(id);
            return Ok(lstCompanyGroup);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CompanyGroupInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyGroupInfo.InsertCompanyGroup(data);
            return Ok(res);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(string id, [FromBody] CompanyGroupInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyGroupInfo.UpdateCompanyGroup(data, id);
            return Ok(res);
        }

        [HttpPost("delete/{id}")]
        public IActionResult Remove(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyGroupInfo.DeleteCompnayGroup(id);
            return Ok(res);
        }
    }
}
