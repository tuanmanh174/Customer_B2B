using CustomerB2B.Models;
using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyDocumentInfo
{
    public interface ICompanyDocumentInfo
    {
        List<CompanyDocumentInfoViewModel> GetAll(string companyId);
        CompanyDocumentInfoViewModel GetCompanyDocumentById(string id);
        ResponseData UpdateCompanyDocument(CompanyDocumentInfoViewModel companyDocumentInfo, string id);
        ResponseData InsertCompanyDocument(CompanyDocumentInfoViewModel companyDocumentInfo);
        ResponseData DeleteCompnayDocument(string id);
    }
}
