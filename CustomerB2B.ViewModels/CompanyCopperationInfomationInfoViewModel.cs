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
        public CompanyCopperationInformationInfoViewModel() { }

        public CompanyCopperationInformationInfoViewModel(CompanyCopperationInformation model)
        {
            Id = model.Id.ToString();
            CompanyId = model.CompanyId.ToString();
            MOU = model.MOU;
            MouDuration = model.MouDuration;
            CooperationField = model.CooperationField;
            FrequenceUse = model.FrequenceUse;
            CooperationOther = model.CooperationOther;
            Product = model.Product;
            CoordinatingAgent = model.CoordinatingAgent;
            Status = model.Status;

        }

        public CompanyCopperationInformation ConvertViewModel(CompanyCopperationInformationInfoViewModel model)
        {
            return new CompanyCopperationInformation
            {
                Id = Guid.Parse(model.Id),
                CompanyId = model.CompanyId,
                MOU = model.MOU,
                MouDuration = model.MouDuration,
                CooperationField = model.CooperationField,
                FrequenceUse = model.FrequenceUse,
                CooperationOther = model.CooperationOther,
                Product = model.Product,
                CoordinatingAgent = model.CoordinatingAgent,
                Status = model.Status
            };
        }
    }

    public class CompanyCopperationInsertInformationInfoViewModel
    {
        public bool MOU { get; set; }
        public string CompanyId { get; set; }
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
        public bool? Status { get; set; }
        public CompanyCopperationInsertInformationInfoViewModel() { }



        public CompanyCopperationInformation ConvertViewModel(CompanyCopperationInsertInformationInfoViewModel model)
        {
            return new CompanyCopperationInformation
            {
                Id = new Guid(),
                CompanyId = model.CompanyId,
                MOU = model.MOU,
                MouDuration = model.MouDuration,
                CooperationField = model.CooperationField,
                FrequenceUse = model.FrequenceUse,
                CooperationOther = model.CooperationOther,
                Product = model.Product,
                CoordinatingAgent = model.CoordinatingAgent,
                Status = model.Status,
            };
        }
    }


    public class CompanyCopperationUpdateInformationInfoViewModel
    {
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
        public bool? Status { get; set; }
        public CompanyCopperationUpdateInformationInfoViewModel() { }



        public CompanyCopperationInformation ConvertViewModel(CompanyCopperationUpdateInformationInfoViewModel model)
        {
            return new CompanyCopperationInformation
            {
                MOU = model.MOU,
                MouDuration = model.MouDuration,
                CooperationField = model.CooperationField,
                FrequenceUse = model.FrequenceUse,
                CooperationOther = model.CooperationOther,
                Product = model.Product,
                CoordinatingAgent = model.CoordinatingAgent,
                Status = model.Status,
            };
        }
    }
}
