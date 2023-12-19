using CustomerB2B.Models;
using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyAdditionalInfo
{
    public interface ICompanyAdditionalInfo
    {
        List<CompanyAdditionalInformationInfoViewModel> GetAll(string companyId);
        ResponseData UpdateCompanyAdditional(CompanyAdditionalUpdateInformationInfoViewModel companyAdditionalInfo, string id);
        ResponseData InsertCompanyAdditional(CompanyAdditionalInsertInformationInfoViewModel companyAdditionalInfo);
        ResponseData DeleteCompnayAdditional(string id);
    }
}
