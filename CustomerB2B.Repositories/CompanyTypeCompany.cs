using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Repositories
{
    //Bảng này map giữa bảng Company và CompanyType
    // 1 công ty có thể thuộc nhiều loại hình
    public class CompanyTypeCompany
    {
        public Guid Id { get; set; }
        public string CompanyId { get; set; }
        public string CompanyTypeId { get; set; }

    }
}
