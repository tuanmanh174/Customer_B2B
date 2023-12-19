using CustomerB2B.Models;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.ICompanySpecificInfo
{
    public interface ICompanySpecificInfo
    {
        List<CompanySpecificInformationInfoViewModel> GetAll(string companyId);
        ResponseData UpdateCompanySpecific(CompanySpecificUpdateInformationInfoViewModel companySpecificInfo, string id);
        ResponseData InsertCompanySpecific(CompanySpecificInsertInformationInfoViewModel companySpecificInfo);
        ResponseData DeleteCompnaySpecific(string id);
    }
}
