using CustomerB2B.Models;
using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyGroupInfo
{
    public interface ICompanyGroupInfo
    {
        PagedResult<CompanyGroupInfoViewModel> GetAll(int pageNumber, int pageSize);
        CompanyGroupInfoViewModel GetCompanyGroupById(string id);
        ResponseData UpdateCompanyGroup(CompanyGroupInfoViewModel companyGroupInfo);
        ResponseData InsertCompanyGroup(CompanyGroupInfoViewModel companyGroupInfo);
        ResponseData DeleteCompnayGroup(string id);
    }
}
