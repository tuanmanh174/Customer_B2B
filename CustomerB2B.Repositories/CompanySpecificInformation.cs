﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Repositories
{
    //Bảng này lưu các thông tin đặc thù trong 1 doanh nghiệp
    public class CompanySpecificInformation
    {
        public Guid Id { get; set; }
        public string CompanyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
