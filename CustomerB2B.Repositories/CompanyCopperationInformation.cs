using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Repositories
{
    public class CompanyCopperationInformation
    {
        public Guid Id { get; set; }
        public string CompanyId { get; set; }
        public bool? MOU { get; set; }
        //thời hạn MOU
        public int? MouDuration { get; set; }
        //Lĩnh vực hợp tác
        public string CooperationField { get; set; }
        //Tần suất sử dụng
        public int? FrequenceUse { get; set; }
        //các hợp tác khác
        public string CooperationOther { get; set; }
        public string Product { get; set; }
        //Đại lý phối hợp
        public string CoordinatingAgent { get; set; }
        public bool? Status { get; set; }
    }
}
