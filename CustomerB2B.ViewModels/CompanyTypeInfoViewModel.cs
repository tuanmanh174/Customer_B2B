using CustomerB2B.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.ViewModels
{
    public class CompanyTypeInfoViewModel
    {
        public string CompanyTypeCode { get; set; }
        public string CompanyTypeName { get; set; }
        public string Id { get; set; }

        public CompanyTypeInfoViewModel() { }

        public CompanyTypeInfoViewModel(CompanyType model)
        {
            Id = model.Id.ToString();
            CompanyTypeCode = model.Code;
            CompanyTypeName = model.Name;
        }

        public CompanyType ConvertViewModel(CompanyTypeInfoViewModel model)
        {
            return new CompanyType
            {
                Id = Guid.Parse(model.Id),
                Code = model.CompanyTypeCode,
                Name = model.CompanyTypeName,
            };
        }
    }
}
