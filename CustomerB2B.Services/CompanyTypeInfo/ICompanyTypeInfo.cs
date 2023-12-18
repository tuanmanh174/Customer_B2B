using CustomerB2B.Models;
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
        ResponseData UpdateCompanyType(CompanyTypeUpdateInfoViewModel companyTypeInfo, string id);
        ResponseData InsertCompanyType(CompanyTypeInsertInfoViewModel companyTypeInfo);
        ResponseData DeleteCompanyType(string id);
    }
}
