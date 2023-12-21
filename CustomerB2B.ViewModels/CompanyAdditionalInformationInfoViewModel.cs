using CustomerB2B.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomerB2B.ViewModels
{
    public class CompanyAdditionalInformationInfoViewModel
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string AccountBank { get; set; }
        public string BankName { get; set; }
        //Ngày thành lập
        public DateTime? Founding { get; set; }
        //Doanh thu
        public decimal? Revenue { get; set; }
        //Quy mô nhân sự
        public int? StaffSize { get; set; }
        //Số ngày được nợ
        public int? DaysOwed { get; set; }
        //Hạn mức nợ
        public decimal? DebtLimit { get; set; }
        //Là khách hàng từ
        public string CustomerFrom { get; set; }
        public CompanyAdditionalInformationInfoViewModel() { }

        public CompanyAdditionalInformationInfoViewModel(CompanyAdditionalInformation model)
        {
            Id = model.Id.ToString();
            CompanyId = model.CompanyId.ToString();
            AccountBank = model.AccountBank;
            BankName = model.BankName;
            Founding = model.Founding;
            Revenue = model.Revenue;
            StaffSize = model.StaffSize;
            DaysOwed = model.DaysOwed;
            DebtLimit = model.DebtLimit;
            CustomerFrom = model.CustomerFrom;

        }

        public CompanyAdditionalInformation ConvertViewModel(CompanyAdditionalInformationInfoViewModel model)
        {
            return new CompanyAdditionalInformation
            {
                Id = Guid.Parse(model.Id),
                AccountBank = model.AccountBank,
                BankName = model.BankName,
                Founding = model.Founding,
                Revenue = model.Revenue,
                StaffSize = model.StaffSize,
                DaysOwed = model.DaysOwed,
                DebtLimit = model.DebtLimit,
                CustomerFrom = model.CustomerFrom
            };
        }
    }


    public class CompanyAdditionalInsertInformationInfoViewModel
    {
        public string AccountBank { get; set; }
        public string CompanyId { get; set; }
        public string BankName { get; set; }
        //Ngày thành lập
        public DateTime? Founding { get; set; }
        //Doanh thu
        public decimal? Revenue { get; set; }
        //Quy mô nhân sự
        public int? StaffSize { get; set; }
        //Số ngày được nợ
        public int? DaysOwed { get; set; }
        //Hạn mức nợ
        public decimal? DebtLimit { get; set; }
        //Là khách hàng từ
        public string CustomerFrom { get; set; }
        public CompanyAdditionalInsertInformationInfoViewModel() { }



        public CompanyAdditionalInformation ConvertViewModel(CompanyAdditionalInsertInformationInfoViewModel model)
        {
            return new CompanyAdditionalInformation
            {
                Id = new Guid(),
                CompanyId = model.CompanyId,
                AccountBank = model.AccountBank,
                BankName = model.BankName,
                Founding = model.Founding,
                Revenue = model.Revenue,
                StaffSize = model.StaffSize,
                DaysOwed = model.DaysOwed,
                DebtLimit = model.DebtLimit,
                CustomerFrom = model.CustomerFrom,
            };
        }
    }


    public class CompanyAdditionalUpdateInformationInfoViewModel
    {
        public string AccountBank { get; set; }
        public string BankName { get; set; }
        //Ngày thành lập
        public DateTime? Founding { get; set; }
        //Doanh thu
        public decimal? Revenue { get; set; }
        //Quy mô nhân sự
        public int? StaffSize { get; set; }
        //Số ngày được nợ
        public int? DaysOwed { get; set; }
        //Hạn mức nợ
        public decimal? DebtLimit { get; set; }
        //Là khách hàng từ
        public string CustomerFrom { get; set; }
        public CompanyAdditionalUpdateInformationInfoViewModel() { }



        public CompanyAdditionalInformation ConvertViewModel(CompanyAdditionalUpdateInformationInfoViewModel model)
        {
            return new CompanyAdditionalInformation
            {
                AccountBank = model.AccountBank,
                BankName = model.BankName,
                Founding = model.Founding,
                Revenue = model.Revenue,
                StaffSize = model.StaffSize,
                DaysOwed = model.DaysOwed,
                DebtLimit = model.DebtLimit,
            };
        }
    }
}
