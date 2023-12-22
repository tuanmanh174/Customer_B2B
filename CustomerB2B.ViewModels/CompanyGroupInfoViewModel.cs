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
        public bool Status { get; set; }
        public CompanyGroupInfoViewModel() { }

        public CompanyGroupInfoViewModel(CompanyGroup model)
        {
            Id = model.Id.ToString();
            GroupName = model.Name;
            GroupCode = model.Code;
            CreatedBy = model.CreatedBy;
            CreatedDate = model.CreatedDate;
            UpdatedBy = model.UpdatedBy;
            IsDeleted = model.IsDeleted;
            Notice = model.Notice;
            Status = model.Status;
            UpdatedDate = model.UpdatedDate;
        }

        public CompanyGroup ConvertViewModel(CompanyGroupInfoViewModel model)
        {
            return new CompanyGroup
            {
                Id = Guid.Parse(model.Id),
                Code = model.GroupCode,
                Name = model.GroupName,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                UpdatedBy = model.UpdatedBy,
                IsDeleted = false,
                Notice = model.Notice,
                Status = model.Status,
                UpdatedDate = model.UpdatedDate,
            };
        }
    }


    public class CompanyGroupInsertInfoViewModel
    {
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
        //Ghi chú
        public string Notice { get; set; }
        public bool Status { get; set; } = true;

        public CompanyGroupInsertInfoViewModel() { }



        public CompanyGroup ConvertViewModel(CompanyGroupInsertInfoViewModel model)
        {
            return new CompanyGroup
            {
                Id = new Guid(),
                Code = model.GroupCode,
                Name = model.GroupName,
                CreatedBy = "manhdt",
                CreatedDate = DateTime.Now,
                UpdatedBy = "manhdt",
                IsDeleted = false,
                Status = model.Status,
                Notice = model.Notice,
            };
        }
    }


    public class CompanyGroupUpdateInfoViewModel
    {
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
        //Ghi chú
        public string Notice { get; set; }
        public bool Status { get; set; }
        public CompanyGroupUpdateInfoViewModel() { }



        public CompanyGroup ConvertViewModel(CompanyGroupUpdateInfoViewModel model)
        {
            return new CompanyGroup
            {
                Code = model.GroupCode,
                Name = model.GroupName,
                UpdatedBy = "manhdt",
                Notice = model.Notice,
                Status = model.Status,
            };
        }
    }

}
