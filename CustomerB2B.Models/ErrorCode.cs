using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Models
{
    public class ErrorCode
    {
        public const int SUCCESS_CODE = 200;
        public const string INSERT_SUCCESS_MESSAGE = "Thêm mới dữ liệu thành công";
        public const string UPDATE_SUCCESS_MESSAGE = "Cập nhật dữ liệu thành công";
        public const string REMOVE_SUCCESS_MESSAGE = "Xóa dữ liệu thành công";
        public const int ERROR_SYSTEM_CODE = -99;
        public const string ERROR_SYSTEM_MESSAGE = "Hệ thống đang lỗi, vui lòng liên hệ admin";
        public const int DATA_NOT_EXISTS_CODE = -500;
        public const string DATA_NOT_EXISTS_MESSAGE = "Dữ liệu không tồn tại";
        public const int DATA_EXISTS_CODE = -505;
        public const string DATA_EXISTS_MESSAGE = "Dữ liệu đã tồn tại";
    }
}
