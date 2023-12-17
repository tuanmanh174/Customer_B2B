using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Repositories
{
    public class BaseEntity
    {
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
        public bool? IsDeleted { get; set; }
    }
}
