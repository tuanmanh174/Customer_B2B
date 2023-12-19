using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Repositories
{
    //Bảng lưu danh sách nhóm khách hàng
    public class CompanyGroup : BaseEntity
    {
        public Guid Id { get; set; }
        // Tên nhóm khách hàng
        public string Name { get; set; }
        // Mã nhóm khách hàng
        public string Code { get; set; }
        public bool Status { get; set; }
    }
}
