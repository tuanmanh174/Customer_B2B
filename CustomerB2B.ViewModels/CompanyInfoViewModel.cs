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
        public Guid Id { get; set; }
        //Tên khách hàng
        public string Name { get; set; }
        //Mã khách hàng
        public string Code { get; set; }
        //Mã số thuế
        public string TaxCode { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        //Thông tin Phường, Xã
        public string DistrictId { get; set; }
        public string City { get; set; }
        public Guid? GroupId { get; set; }
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
        public string GroupName { get; set; }
        public List<CompanyTypeInfoViewModel> lstCompanyType { get; set; }
        public CompanyInfoViewModel() { }

        public CompanyInfoViewModel(Company model)
        {
            Id = model.Id;
            Name = model.Name;
            Code = model.Code;
            TaxCode = model.TaxCode;
            PhoneNumber = model.PhoneNumber;
            Email = model.Email;
            Address = model.Address;
            DistrictId = model.DistrictId;
            GroupId = Guid.Parse(model.GroupId);
            City = model.City;
            Notice = model.Notice;
            UpdatedBy = model.UpdatedBy;
            UpdatedDate = DateTime.Now;
            CreatedBy = model.CreatedBy;
            CreatedDate = DateTime.Now;
        }

        public Company ConvertViewModel(CompanyInfoViewModel model, string userName)
        {
            return new Company
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name,
                TaxCode = model.TaxCode,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Address = model.Address,
                DistrictId = model.DistrictId,
                City = model.City,
                GroupId = model.GroupId.ToString(),
                Notice = model.Notice,
                UpdatedBy = userName,
                UpdatedDate = DateTime.Now,
                CreatedBy = userName,
                CreatedDate = DateTime.Now,
            };
        }

    }

    public class CompanyInsertInfoViewModel
    {
        //Id của doanh nghiệp
        public string Id { get; set; }
        //Tên khách hàng
        public string Name { get; set; }
        //Mã khách hàng
        public string Code { get; set; }
        //Mã số thuế
        public string TaxCode { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        //Thông tin Phường, Xã
        public string DistrictId { get; set; }
        public string City { get; set; }
        public Guid? GroupId { get; set; }
        //Ghi chú
        public string Notice { get; set; }
        public CompanyInsertInfoViewModel() { }



        public Company ConvertViewModel(CompanyInsertInfoViewModel model)
        {
            return new Company
            {
                Id = new Guid(),
                Code = model.Code,
                Name = model.Name,
                TaxCode = model.TaxCode,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Address = model.Address,
                DistrictId = model.DistrictId,
                City = model.City,
                GroupId = model.GroupId.ToString(),
                CreatedBy = "manhdt",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Notice = model.Notice,
            };
        }
    }


    public class CompanyUpdateInfoViewModel
    {
        //Tên khách hàng
        public string Name { get; set; }
        //Mã khách hàng
        public string Code { get; set; }
        //Mã số thuế
        public string TaxCode { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        //Thông tin Phường, Xã
        public string DistrictId { get; set; }
        public string City { get; set; }
        public Guid? GroupId { get; set; }
        //Ghi chú
        public string Notice { get; set; }
        public CompanyUpdateInfoViewModel() { }



        public Company ConvertViewModel(CompanyUpdateInfoViewModel model)
        {
            return new Company
            {
                Code = model.Code,
                Name = model.Name,
                TaxCode = model.TaxCode,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Address = model.Address,
                DistrictId = model.DistrictId,
                City = model.City,
                GroupId = model.GroupId.ToString(),
                UpdatedBy = "manhdt",
                UpdatedDate = DateTime.Now,
                Notice = model.Notice,
            };
        }
    }
}
