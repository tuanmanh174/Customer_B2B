using CustomerB2B.Models;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyTypeCompanyInfo
{
    public interface ICompanyTypeCompanyService
    {
        ResponseData RemoveCompanyTypeCompany(string companyId, string companyTypeId);
        ResponseData InsertCompanyTypeCompany(CompanyTypeCompanyInfoViewModel companyTypeCompanyInfo);
    }
}
