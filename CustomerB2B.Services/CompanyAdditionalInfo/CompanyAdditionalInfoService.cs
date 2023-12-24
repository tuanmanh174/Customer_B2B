using CustomerB2B.Models;
using CustomerB2B.Repositories;
using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.Services.CompanyGroupInfo;
using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyAdditionalInfo
{
    public class CompanyAdditionalInfoService : ICompanyAdditionalInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomerB2BDbContext _dbContext;
        public CompanyAdditionalInfoService(IUnitOfWork unitOfWork, CustomerB2BDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext; 
        }
        public ResponseData DeleteCompnayAdditional(string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                Guid _id = Guid.Parse(id);
                var model = _unitOfWork.GenericRepository<CompanyAdditionalInformation>().GetById(_id);
                _unitOfWork.GenericRepository<CompanyAdditionalInformation>().Delete(model);
                _unitOfWork.Save();
                res.ResponseCode = ErrorCode.SUCCESS_CODE;
                res.ResponseMessage = ErrorCode.REMOVE_SUCCESS_MESSAGE;
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

        public List<CompanyAdditionalInformationInfoViewModel> GetAll(string companyId)
        {

            List<CompanyAdditionalInformationInfoViewModel> vmList = new List<CompanyAdditionalInformationInfoViewModel>();
            try
            {
                var modelList = _unitOfWork.GenericRepository<CompanyAdditionalInformation>().GetAll(x => x.CompanyId == companyId).ToList();
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }
            return vmList;
        }

        public CompanyAdditionalInformationInfoViewModel GetCompnayAdditionalById(string companyId)
        {

            var model = _dbContext.CompanyAdditionalInformations.Where(x => x.CompanyId == companyId).FirstOrDefault();
            if (model == null)
            {
                return null;
            }
            var vm = new CompanyAdditionalInformationInfoViewModel(model);
            return vm;
        }

        public ResponseData InsertCompanyAdditional(CompanyAdditionalInsertInformationInfoViewModel companyAdditionalInfo)
        {
            ResponseData res = new ResponseData();
            try
            {
                var model = new CompanyAdditionalInsertInformationInfoViewModel().ConvertViewModel(companyAdditionalInfo);
                _unitOfWork.GenericRepository<CompanyAdditionalInformation>().Add(model);
                _unitOfWork.Save();
                res.ResponseCode = ErrorCode.SUCCESS_CODE;
                res.ResponseMessage = ErrorCode.INSERT_SUCCESS_MESSAGE;
                res.Data = model;
            }
            catch (Exception ex)
            {
                res.ResponseCode = ErrorCode.ERROR_SYSTEM_CODE;
                res.ResponseMessage = ErrorCode.ERROR_SYSTEM_MESSAGE;
                res.Data = null;
            }
            return res;
        }

        public ResponseData UpdateCompanyAdditional(CompanyAdditionalUpdateInformationInfoViewModel companyAdditionalInfo, string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                Guid _id = Guid.Parse(id);
                var modelById = _unitOfWork.GenericRepository<CompanyAdditionalInformation>().GetById(_id);
                modelById.AccountBank = companyAdditionalInfo.AccountBank;
                modelById.BankName = companyAdditionalInfo.BankName;
                modelById.DaysOwed = companyAdditionalInfo.DaysOwed;
                modelById.DebtLimit = companyAdditionalInfo.DebtLimit;
                modelById.StaffSize = companyAdditionalInfo.StaffSize;
                modelById.Revenue = companyAdditionalInfo.Revenue;
                modelById.Founding = companyAdditionalInfo.Founding;
                modelById.CustomerFrom = companyAdditionalInfo.CustomerFrom;
                _unitOfWork.GenericRepository<CompanyAdditionalInformation>().Update(modelById);
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

        private List<CompanyAdditionalInformationInfoViewModel> ConvertModelToViewModelList(List<CompanyAdditionalInformation> modelList)
        {
            return modelList.Select(x => new CompanyAdditionalInformationInfoViewModel(x)).ToList();
        }
    }
}
