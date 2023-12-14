using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyTypeCompanyInfo
{
    public class CompanyTypeCompnayService : ICompanyTypeCompanyService
    {
        private IUnitOfWork _unitOfWork;
        public CompanyTypeCompnayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void InsertCompanyTypeCompany(CompanyTypeCompanyInfoViewModel companyTypeCompanyInfo)
        {
            throw new NotImplementedException();
        }

        public void UpdateCompanyTypeCompany(CompanyTypeCompanyInfoViewModel companyTypeCompanyInfo)
        {
            throw new NotImplementedException();
        }
    }
}
