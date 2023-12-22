using CustomerB2B.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomerB2B.ViewModels
{
    public class CompanySpecificInformationInfoViewModel
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CompanySpecificInformationInfoViewModel(CompanySpecificInformation model)
        {
            Id = model.Id.ToString();
            Title = model.Title;
            CompanyId = model.CompanyId.ToString();
            Description = model.Description;
        }

        public CompanySpecificInformation ConvertViewModel(CompanySpecificInformationInfoViewModel model)
        {
            return new CompanySpecificInformation
            {
                Id = Guid.Parse(model.Id),
                Title = model.Title,
                Description = model.Description
            };
        }
    }

    public class CompanySpecificInsertInformationInfoViewModel
    {
        public string Title { get; set; }
        public string CompanyId { get; set; }
        public string Description { get; set; }
        public CompanySpecificInsertInformationInfoViewModel() { }



        public CompanySpecificInformation ConvertViewModel(CompanySpecificInsertInformationInfoViewModel model)
        {
            return new CompanySpecificInformation
            {
                Id = new Guid(),
                CompanyId = model.CompanyId,
                Title = model.Title,
                Description = model.Description,
            };
        }
    }


    public class CompanySpecificUpdateInformationInfoViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public CompanySpecificUpdateInformationInfoViewModel() { }



        public CompanySpecificInformation ConvertViewModel(CompanySpecificUpdateInformationInfoViewModel model)
        {
            return new CompanySpecificInformation
            {
                Title = model.Title,
                Description = model.Description,
            };
        }
    }
}
