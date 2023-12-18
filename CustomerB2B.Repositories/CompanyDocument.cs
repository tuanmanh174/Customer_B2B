using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Repositories
{
    //Bảng lưu thông tin file tài liệu trong 1 công ty
    public class CompanyDocument 
    {
        public Guid Id { get; set; }
        public string CompanyId { get; set; }
        public string DocumentName { get; set; }
        public string Path { get; set; }
        public int Size { get; set; }
    }
}
