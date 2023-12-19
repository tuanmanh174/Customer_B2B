using CustomerB2B.Models;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyCopperationInfo
{
    public interface ICompanyCopperationInfo
    {
        List<CompanyCopperationInformationInfoViewModel> GetAll(string companyId);
        ResponseData UpdateCompanyCopperation(CompanyCopperationUpdateInformationInfoViewModel companyAdditionalInfo, string id);
        ResponseData InsertCompanyCopperation(CompanyCopperationInsertInformationInfoViewModel companyAdditionalInfo);
        ResponseData DeleteCompnayCopperation(string id);
    }
}
