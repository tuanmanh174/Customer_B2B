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
        public Guid CompanyTypeId { get; set; }
        public Guid CompanyId { get; set; }

        public CompanyTypeCompanyInfoViewModel() { }



        public CompanyTypeCompany ConvertViewModel(CompanyTypeCompanyInfoViewModel model)
        {
            return new CompanyTypeCompany
            {
                Id = new Guid(),
                CompanyId = model.CompanyId.ToString(),
                CompanyTypeId = model.CompanyTypeId.ToString(),
            };
        }
    }
}
