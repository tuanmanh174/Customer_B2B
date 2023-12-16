using CustomerB2B.Models;
using CustomerB2B.Repositories;
using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyInfo
{
    public class CompanyInfoService : ICompanyInfo
    {

        private IUnitOfWork _unitOfWork;
        public CompanyInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseData DeleteCompany(string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                var model = _unitOfWork.GenericRepository<CompanyType>().GetById(id);
                _unitOfWork.GenericRepository<CompanyType>().Delete(model);
                _unitOfWork.Save();
                res.ResponseCode = ErrorCode.SUCCESS_CODE;
                res.ResponseMessage = ErrorCode.INSERT_SUCCESS_MESSAGE;
                res.Data = model;
            }
            catch (Exception ex)
            {
                ex.ToString();
                res.ResponseCode = ErrorCode.ERROR_SYSTEM_CODE;
                res.ResponseMessage = ErrorCode.ERROR_SYSTEM_MESSAGE;
                res.Data = null;
            }
            return res;
        }

        public PagedResult<CompanyInfoViewModel> GetAll(int pageNumber, int pageSize)
        {

            int totalCount;
            List<CompanyInfoViewModel> vmList = new List<CompanyInfoViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Company>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Company>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }
            var result = new PagedResult<CompanyInfoViewModel>()
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public CompanyInfoViewModel GetCompanyById(string id)
        {
            var model = _unitOfWork.GenericRepository<Company>().GetById(id);
            var vm = new CompanyInfoViewModel(model);
            return vm;
        }

        public ResponseData InsertCompany(CompanyInfoViewModel companyTypeInfo)
        {
            ResponseData res = new ResponseData();
            try
            {
                var model = new CompanyInfoViewModel().ConvertViewModel(companyTypeInfo);
                _unitOfWork.GenericRepository<Company>().Add(model);
                _unitOfWork.Save();
                res.ResponseCode = ErrorCode.SUCCESS_CODE;
                res.ResponseMessage = ErrorCode.INSERT_SUCCESS_MESSAGE;
                res.Data = model;
            }
            catch (Exception ex)
            {
                ex.ToString();
                res.ResponseCode = ErrorCode.ERROR_SYSTEM_CODE;
                res.ResponseMessage = ErrorCode.ERROR_SYSTEM_MESSAGE;
                res.Data = null;
            }
            return res;

        }

        public ResponseData UpdateCompany(CompanyInfoViewModel companyInfo, string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                var modelById = _unitOfWork.GenericRepository<CompanyType>().GetById(id);
                modelById.Code = companyInfo.Code;
                modelById.Name = companyInfo.Name;
                modelById.UpdatedDate = DateTime.Now;
                _unitOfWork.GenericRepository<CompanyType>().Update(modelById);
                _unitOfWork.Save();
                res.ResponseCode = ErrorCode.SUCCESS_CODE;
                res.ResponseMessage = ErrorCode.UPDATE_SUCCESS_MESSAGE;
                res.Data = modelById;
            }
            catch (Exception ex)
            {
                ex.ToString();
                res.ResponseCode = ErrorCode.ERROR_SYSTEM_CODE;
                res.ResponseMessage = ErrorCode.ERROR_SYSTEM_MESSAGE;
                res.Data = null;
            }
            return res;

        }

        private List<CompanyInfoViewModel> ConvertModelToViewModelList(List<Company> modelList)
        {
            return modelList.Select(x => new CompanyInfoViewModel(x)).ToList();
        }
    }
}
