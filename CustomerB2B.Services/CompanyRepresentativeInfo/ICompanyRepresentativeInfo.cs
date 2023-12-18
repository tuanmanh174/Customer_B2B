using CustomerB2B.Models;
using CustomerB2B.Repositories;
using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyRepresentativeInfo
{
    public interface ICompanyRepresentativeInfo
    {
        List<CompanyRepresentativeInfoViewModel> GetAll(string companyId);
        ResponseData UpdateCompanyRepresentative(CompanyRepresentativeUpdateInfoViewModel companyInfo, string id);
        ResponseData InsertCompanyRepresentative(CompanyRepresentativeInsertInfoViewModel companyRepresentativeInfo);
        ResponseData InsertRangeCompanyRepresentative(List<CompanyRepresentative> companyRepresentativeInfo);
    }
}
