using CustomerB2B.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.ViewModels
{
    public class CompanyRepresentativeInfoViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int? Gender { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public CompanyRepresentativeInfoViewModel() { }

        public CompanyRepresentativeInfoViewModel(CompanyRepresentative model)
        {
            Id = model.Id.ToString();
            Name = model.Name;
            Position = model.Position;
            Gender = model.Gender;
            PhoneNumber = model.PhoneNumber;
            Email = model.Email;
            DateOfBirth = model.DateOfBirth;
        }

        public CompanyRepresentative ConvertViewModel(CompanyRepresentativeInfoViewModel model)
        {
            return new CompanyRepresentative
            {
                Id = new Guid(),
                DateOfBirth = model.DateOfBirth,
                Position = model.Position,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                IsDeleted = false,
                Name = model.Name
            };
        }
    }
}
