using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Repositories
{
    //Bảng lưu thông tin bổ sung của 1 công ty
    public class CompanyAdditionalInformation
    {
        public Guid Id { get; set; }
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

    }
}
