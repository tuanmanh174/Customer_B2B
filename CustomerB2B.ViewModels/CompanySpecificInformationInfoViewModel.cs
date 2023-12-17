using CustomerB2B.Repositories;
using System;
using System.Collections.Generic;
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
        public string Title { get; set; }
        public string Description { get; set; }
        public CompanySpecificInformationInfoViewModel(CompanySpecificInformation model)
        {
            Id = model.Id.ToString();
            Title = model.Title;
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
}
