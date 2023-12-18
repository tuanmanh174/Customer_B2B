using CustomerB2B.Models;
using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyInfo
{
    public interface ICompanyInfo
    {
        PagedResult<CompanyInfoViewModel> GetAll(int pageNumber, int pageSize);
        CompanyInfoViewModel GetCompanyById(string id);
        ResponseData UpdateCompany(CompanyUpdateInfoViewModel companyInfo, string id);
        ResponseData InsertCompany(CompanyInsertInfoViewModel companyInfo);
        ResponseData DeleteCompany(string id);
    }
}
