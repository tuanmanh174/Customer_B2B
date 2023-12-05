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
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
        public CompanyGroupInfoViewModel() { }

        public CompanyGroupInfoViewModel(CompanyGroupInfoViewModel model)
        {
            GroupName = model.GroupName;
            GroupCode = model.GroupCode;
        }

        public CompanyGroup ConvertCompanyGroupToViewModel(CompanyGroupInfoViewModel model)
        {
            return new CompanyGroup
            {
                Code = model.GroupCode,
                Name = model.GroupName,

            };
        }
    }


}
