using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Repositories
{
    //Bảng lưu thông tin danh sách người đại diện trong doanh nghiệp
    public class CompanyRepresentative 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int? Gender { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
