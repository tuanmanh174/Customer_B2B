using CustomerB2B.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.ViewModels
{
    public class CompanyInfoViewModel
    {
        //Id của doanh nghiệp
        public string Id { get; set; }
        //Tên doanh nghiệp
        public string Name { get; set; }
        // Mã doanh nghiệp trên hệ thống
        public string Code { get; set; }
        //Tên nhóm doanh nghiệp thuộc về
        public CompanyGroupInfoViewModel GroupName { get; set; }
        // List loại hình doanh nghiệp mà doanh nghiệp đó thuộc về
        public ICollection<CompanyTypeInfoViewModel> ListCompanyType { get; set; }


        public CompanyInfoViewModel() { }

        public CompanyInfoViewModel(Company model)
        {
            Id = model.Id.ToString();
            Name = model.Name;
            Code = model.Code;
        }

        public Company ConvertViewModel(CompanyInfoViewModel model)
        {
            return new Company
            {
                Id = Guid.Parse(model.Id),
                Code = model.Code,
                Name = model.Name,
            };
        }

    }
}
