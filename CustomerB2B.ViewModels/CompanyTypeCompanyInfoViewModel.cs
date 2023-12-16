using CustomerB2B.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.ViewModels
{
    public class CompanyTypeCompanyInfoViewModel
    {
        public string Id { get; set; }
        public string CompanyTypeId { get; set; }
        public string CompanyId { get; set; }

        public CompanyTypeCompanyInfoViewModel() { }

        public CompanyTypeCompanyInfoViewModel(CompanyType model)
        {
            Id = model.Id.ToString();
            CompanyTypeId = model.Code;
            CompanyId = model.Name;
        }

        public CompanyTypeCompany ConvertViewModel(CompanyTypeCompanyInfoViewModel model)
        {
            return new CompanyTypeCompany
            {
                Id = new Guid(),
                CompanyId = model.CompanyId,
                CompanyTypeId = model.CompanyTypeId,
            };
        }
    }
}
