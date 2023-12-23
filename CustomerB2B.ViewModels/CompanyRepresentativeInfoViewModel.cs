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
        public string CompanyId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Notice { get; set; }
        public int? Gender { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        
        public bool Status { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public CompanyRepresentativeInfoViewModel() { }

        public CompanyRepresentativeInfoViewModel(CompanyRepresentative model)
        {
            Id = model.Id.ToString();
            CompanyId = model.CompanyId.ToString();
            Name = model.Name;
            Position = model.Position;
            Gender = model.Gender;
            PhoneNumber = model.PhoneNumber;
            Email = model.Email;
            DateOfBirth = model.DateOfBirth;
            Notice = model.Notice;
            Status = model.Status;
        }

        public CompanyRepresentative ConvertViewModel(CompanyRepresentativeInfoViewModel model)
        {
            return new CompanyRepresentative
            {
                Id = Guid.Parse(model.Id),
                DateOfBirth = model.DateOfBirth,
                Position = model.Position,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Notice = model.Notice,
                Status = model.Status,
            };
        }
    }

    public class CompanyRepresentativeInsertInfoViewModel
    {
        public string Name { get; set; }
        public string CompanyId { get; set; }
        public string Position { get; set; }
        public int? Gender { get; set; }
        public int PhoneNumber { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Notice { get; set; }
        public CompanyRepresentativeInsertInfoViewModel() { }



        public CompanyRepresentative ConvertViewModel(CompanyRepresentativeInsertInfoViewModel model)
        {
            return new CompanyRepresentative
            {
                Id = new Guid(),
                CompanyId = model.CompanyId,
                Name = model.Name,
                Position = model.Position,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                Notice = model.Notice,
                Status = model.Status,
            };
        }
    }


    public class CompanyRepresentativeUpdateInfoViewModel
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int? Gender { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Notice { get; set; }
        public CompanyRepresentativeUpdateInfoViewModel() { }



        public CompanyRepresentative ConvertViewModel(CompanyRepresentativeUpdateInfoViewModel model)
        {
            return new CompanyRepresentative
            {
                Name = model.Name,
                Position = model.Position,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                Notice = model.Notice,
                Status = model.Status,
            };
        }
    }
}
