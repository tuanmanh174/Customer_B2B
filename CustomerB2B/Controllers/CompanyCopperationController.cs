using CustomerB2B.Services.CompanyAdditionalInfo;
using CustomerB2B.Services.CompanyCopperationInfo;
using CustomerB2B.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerB2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyCopperationController : ControllerBase
    {
        private readonly ICompanyCopperationInfo _companyCopperationInfo;
        public CompanyCopperationController(ICompanyCopperationInfo companyCopperationInfo)
        {
            _companyCopperationInfo = companyCopperationInfo;
        }
        [HttpGet]
        public IActionResult Get(string companyId)
        {
            var lstCompanyAdditional = _companyCopperationInfo.GetAll(companyId);
            return Ok(lstCompanyAdditional);
        }


        [HttpPost]
        public IActionResult Post([FromBody] CompanyCopperationInsertInformationInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyCopperationInfo.InsertCompanyCopperation(data);
            return Ok(res);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update(string id, [FromBody] CompanyCopperationUpdateInformationInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _companyCopperationInfo.UpdateCompanyCopperation(data, id);
            return Ok(res);
        }
    }
}
