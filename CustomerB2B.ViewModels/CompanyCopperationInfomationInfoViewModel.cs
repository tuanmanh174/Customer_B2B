using CustomerB2B.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.ViewModels
{
    public class CompanyCopperationInformationInfoViewModel
    {
        public string Id { get; set; }
        public bool MOU { get; set; }
        //thời hạn MOU
        public int MouDuration { get; set; }
        //Lĩnh vực hợp tác
        public string CooperationField { get; set; }
        //Tần suất sử dụng
        public int FrequenceUse { get; set; }
        //các hợp tác khác
        public string CooperationOther { get; set; }
        public string Product { get; set; }
        //Đại lý phối hợp
        public string CoordinatingAgent { get; set; }
        public CompanyCopperationInformationInfoViewModel() { }

        public CompanyCopperationInformationInfoViewModel(CompanyCopperationInformation model)
        {
            Id = model.Id.ToString();
            MOU = model.MOU;
            MouDuration = model.MouDuration;
            CooperationField = model.CooperationField;
            FrequenceUse = model.FrequenceUse;
            CooperationOther = model.CooperationOther;
            Product = model.Product;
            CoordinatingAgent = model.CoordinatingAgent;

        }

        public CompanyCopperationInformation ConvertViewModel(CompanyCopperationInformationInfoViewModel model)
        {
            return new CompanyCopperationInformation
            {
                Id = Guid.Parse(model.Id),
                MOU = model.MOU,
                MouDuration = model.MouDuration,
                CooperationField = model.CooperationField,
                FrequenceUse = model.FrequenceUse,
                CooperationOther = model.CooperationOther,
                Product = model.Product,
                CoordinatingAgent = model.CoordinatingAgent
            };
        }
    }
}
