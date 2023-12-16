using CustomerB2B.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.ViewModels
{
    public class CompanyGroupInfoViewModel
    {
        public string Id { get; set; }
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
        public CompanyGroupInfoViewModel() { }

        public CompanyGroupInfoViewModel(CompanyGroup model)
        {
            Id = model.Id.ToString();
            GroupName = model.Name;
            GroupCode = model.Code;
        }

        public CompanyGroup ConvertViewModel(CompanyGroupInfoViewModel model)
        {
            return new CompanyGroup
            {
                Id = new Guid(),
                Code = model.GroupCode,
                Name = model.GroupName,
            };
        }
    }


}
