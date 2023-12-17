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
        //Ngày tạo bản ghi
        public DateTime? CreatedDate { get; set; }
        //Ngay cập nhật bản ghi
        public DateTime? UpdatedDate { get; set; }
        //Người tạo bản ghi
        public string CreatedBy { get; set; }
        //Người cập nhật bản ghi
        public string UpdatedBy { get; set; }
        //Ghi chú
        public string Notice { get; set; }
        //Trạng thái đã xóa hoặc chưa xóa bản ghi
        public bool IsDeleted { get; set; } = false;


        public CompanyInfoViewModel() { }

        public CompanyInfoViewModel(Company model)
        {
            Id = model.Id.ToString();
            Name = model.Name;
            Code = model.Code;
        }

        public Company ConvertViewModel(CompanyInfoViewModel model, string userName)
        {
            return new Company
            {
                Id = Guid.Parse(model.Id),
                Code = model.Code,
                Name = model.Name,
                CreatedBy = userName,
                CreatedDate = DateTime.Now,
            };
        }

    }
}
