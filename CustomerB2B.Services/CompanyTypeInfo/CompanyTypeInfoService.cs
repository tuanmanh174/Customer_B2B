using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.Repositories;
using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerB2B.Models;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;

namespace CustomerB2B.Services.CompanyTypeInfo
{
    public class CompanyTypeInfoService : ICompanyTypeInfo
    {
        private IUnitOfWork _unitOfWork;
        private CustomerB2BDbContext _dbContext;
        public CompanyTypeInfoService(IUnitOfWork unitOfWork, CustomerB2BDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }

        public ResponseData DeleteCompanyType(string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                var companyTypeId = Guid.Parse(id);
                var modelById = _unitOfWork.GenericRepository<CompanyType>().GetById(companyTypeId);
                modelById.IsDeleted = true;
                _unitOfWork.GenericRepository<CompanyType>().Update(modelById);
                _unitOfWork.Save();
                res.ResponseCode = ErrorCode.SUCCESS_CODE;
                res.ResponseMessage = ErrorCode.REMOVE_SUCCESS_MESSAGE;
                res.Data = modelById;
            }
            catch (Exception ex)
            {
                res.ResponseCode = ErrorCode.ERROR_SYSTEM_CODE;
                res.ResponseMessage = ErrorCode.ERROR_SYSTEM_MESSAGE;
                res.Data = null;
            }
            return res;

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

        public ResponseData InsertCompanyType(CompanyTypeInsertInfoViewModel companyTypeInfo)
        {
            ResponseData res = new ResponseData();
            try
            {
                var model = new CompanyTypeInsertInfoViewModel().ConvertViewModel(companyTypeInfo);
                _unitOfWork.GenericRepository<CompanyType>().Add(model);
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

        public ResponseData UpdateCompanyType(CompanyTypeUpdateInfoViewModel companyTypeInfo, string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                var companyTypeId = Guid.Parse(id);
                var modelById = _unitOfWork.GenericRepository<CompanyType>().GetById(companyTypeId);
                if (modelById == null)
                {
                    res.ResponseCode = ErrorCode.DATA_NOT_EXISTS_CODE;
                    res.ResponseMessage = ErrorCode.DATA_NOT_EXISTS_MESSAGE;
                    return res;
                }
                modelById.Code = companyTypeInfo.CompanyTypeCode;
                modelById.Name = companyTypeInfo.CompanyTypeName;
                modelById.Notice = companyTypeInfo.Notice;
                modelById.UpdatedBy = "manhdt";
                modelById.UpdatedDate = DateTime.Now;
                _unitOfWork.GenericRepository<CompanyType>().Update(modelById);
                _unitOfWork.Save();
                res.ResponseCode = ErrorCode.SUCCESS_CODE;
                res.ResponseMessage = ErrorCode.UPDATE_SUCCESS_MESSAGE;
                res.Data = modelById;
            }
            catch (Exception ex)
            {
                res.ResponseCode = ErrorCode.ERROR_SYSTEM_CODE;
                res.ResponseMessage = ErrorCode.ERROR_SYSTEM_MESSAGE;
                res.Data = null;
            }
            return res;
        }

        private List<CompanyTypeInfoViewModel> ConvertModelToViewModelList(List<CompanyType> modelList)
        {
            return modelList.Select(x => new CompanyTypeInfoViewModel(x)).ToList();
        }
    }
}
