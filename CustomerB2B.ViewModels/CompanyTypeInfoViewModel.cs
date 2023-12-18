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
        public bool? IsDeleted { get; set; }

        public CompanyTypeInfoViewModel() { }

        public CompanyTypeInfoViewModel(CompanyType model)
        {
            Id = model.Id.ToString();
            CompanyTypeCode = model.Code;
            CompanyTypeName = model.Name;
            CreatedDate = model.CreatedDate;
            UpdatedDate = model.UpdatedDate;
            CreatedBy = model.CreatedBy;
            UpdatedBy = model.UpdatedBy;
            Notice = model.Notice;
        }

        public CompanyType ConvertViewModel(CompanyTypeInfoViewModel model)
        {
            return new CompanyType
            {
                Id = Guid.Parse(model.Id),
                Code = model.CompanyTypeCode,
                Name = model.CompanyTypeName,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate,
                CreatedBy = model.CreatedBy,
                UpdatedBy = model.UpdatedBy,
                Notice = model.Notice,
            };
        }
    }
}
