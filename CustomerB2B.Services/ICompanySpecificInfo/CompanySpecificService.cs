using CustomerB2B.Models;
using CustomerB2B.Repositories;
using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.Services.CompanyAdditionalInfo;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.ICompanySpecificInfo
{
    public class CompanySpecificService : ICompanySpecificInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanySpecificService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResponseData DeleteCompnaySpecific(string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                Guid _id = Guid.Parse(id);
                var model = _unitOfWork.GenericRepository<CompanySpecificInformation>().GetById(_id);
                _unitOfWork.GenericRepository<CompanySpecificInformation>().Delete(model);
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

        public List<CompanySpecificInformationInfoViewModel> GetAll(string companyId)
        {
            List<CompanySpecificInformationInfoViewModel> vmList = new List<CompanySpecificInformationInfoViewModel>();
            try
            {
                var modelList = _unitOfWork.GenericRepository<CompanySpecificInformation>().GetAll(x => x.CompanyId == companyId).ToList();
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }
            return vmList;

        }

        public ResponseData InsertCompanySpecific(CompanySpecificInsertInformationInfoViewModel companySpecificInfo)
        {
            ResponseData res = new ResponseData();
            try
            {
                var model = new CompanySpecificInsertInformationInfoViewModel().ConvertViewModel(companySpecificInfo);
                _unitOfWork.GenericRepository<CompanySpecificInformation>().Add(model);
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

        public ResponseData UpdateCompanySpecific(CompanySpecificUpdateInformationInfoViewModel companySpecificInfo, string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                Guid _id = Guid.Parse(id);
                var modelById = _unitOfWork.GenericRepository<CompanySpecificInformation>().GetById(_id);
                modelById.Description = companySpecificInfo.Description;
                _unitOfWork.GenericRepository<CompanySpecificInformation>().Update(modelById);
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

        private List<CompanySpecificInformationInfoViewModel> ConvertModelToViewModelList(List<CompanySpecificInformation> modelList)
        {
            return modelList.Select(x => new CompanySpecificInformationInfoViewModel(x)).ToList();
        }
    }
}
