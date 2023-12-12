using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyTypeInfo
{
    public interface ICompanyTypeInfo
    {
        PagedResult<CompanyTypeInfoViewModel> GetAll(int pageNumber, int pageSize);
        CompanyTypeInfoViewModel GetCompanyTypeById(string id);
        void UpdateCompanyType(CompanyTypeInfoViewModel companyTypeInfo);
        void InsertCompanyType(CompanyTypeInfoViewModel companyTypeInfo);
        void DeleteCompanyType(string id);
    }
}
