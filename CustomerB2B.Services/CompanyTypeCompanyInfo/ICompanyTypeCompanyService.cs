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
        void UpdateCompanyTypeCompany(CompanyTypeCompanyInfoViewModel companyTypeCompanyInfo);
        void InsertCompanyTypeCompany(CompanyTypeCompanyInfoViewModel companyTypeCompanyInfo);
    }
}
