using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Repositories
{
    public class Company : BaseEntity
    {
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
        public string GroupId { get; set; }
    }
}
