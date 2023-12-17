using CustomerB2B.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.ViewModels
{
    public class CompanyDocumentInfoViewModel
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string DocumentName { get; set; }
        public string Path { get; set; }
        public int Size { get; set; }
        public CompanyDocumentInfoViewModel() { }
        public CompanyDocumentInfoViewModel(CompanyDocument model)
        {
            Id = model.Id.ToString();
            CompanyId = model.CompanyId;
            DocumentName = model.DocumentName;
            Path = model.Path;
            Size = model.Size;

        }

        public CompanyDocument ConvertViewModel(CompanyDocumentInfoViewModel model)
        {
            return new CompanyDocument
            {
                Id = Guid.Parse(model.Id),
                CompanyId = model.CompanyId,
                DocumentName = model.DocumentName,
                Path = model.Path,
                Size = model.Size,
            };
        }
    }
}
