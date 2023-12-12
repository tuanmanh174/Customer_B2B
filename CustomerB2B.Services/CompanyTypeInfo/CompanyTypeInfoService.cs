using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.Repositories;
using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyTypeInfo
{
    public class CompanyTypeInfoService : ICompanyTypeInfo
    {
        private IUnitOfWork _unitOfWork;
        public CompanyTypeInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteCompanyType(string id)
        {
            var model = _unitOfWork.GenericRepository<CompanyType>().GetById(id);
            _unitOfWork.GenericRepository<CompanyType>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<CompanyTypeInfoViewModel> GetAll(int pageNumber, int pageSize)
        {

            int totalCount;
            List<CompanyTypeInfoViewModel> vmList = new List<CompanyTypeInfoViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<CompanyType>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<CompanyType>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }
            var result = new PagedResult<CompanyTypeInfoViewModel>()
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public CompanyTypeInfoViewModel GetCompanyTypeById(string id)
        {
            var model = _unitOfWork.GenericRepository<CompanyType>().GetById(id);
            var vm = new CompanyTypeInfoViewModel(model);
            return vm;
        }

        public void InsertCompanyType(CompanyTypeInfoViewModel companyTypeInfo)
        {
            var model = new CompanyTypeInfoViewModel().ConvertViewModel(companyTypeInfo);
            _unitOfWork.GenericRepository<CompanyType>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateCompanyType(CompanyTypeInfoViewModel companyTypeInfo)
        {
            var model = new CompanyTypeInfoViewModel().ConvertViewModel(companyTypeInfo);
            var modelById = _unitOfWork.GenericRepository<CompanyType>().GetById(model);
            modelById.Code = companyTypeInfo.CompanyTypeCode;
            modelById.Name = companyTypeInfo.CompanyTypeName;
            modelById.UpdatedDate = DateTime.Now;
            _unitOfWork.GenericRepository<CompanyType>().Update(modelById);
            _unitOfWork.Save();
        }

        private List<CompanyTypeInfoViewModel> ConvertModelToViewModelList(List<CompanyType> modelList)
        {
            return modelList.Select(x => new CompanyTypeInfoViewModel(x)).ToList();
        }
    }
}
