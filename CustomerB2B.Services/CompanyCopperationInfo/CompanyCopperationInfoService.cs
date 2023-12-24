using CustomerB2B.Models;
using CustomerB2B.Repositories;
using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyCopperationInfo
{
    public class CompanyCopperationInfoService : ICompanyCopperationInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomerB2BDbContext _dbContext;
        public CompanyCopperationInfoService(IUnitOfWork unitOfWork, CustomerB2BDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }

        public ResponseData DeleteCompnayCopperation(string id)
        {
            throw new NotImplementedException();
        }

        public List<CompanyCopperationInformationInfoViewModel> GetAll(string companyId)
        {
            List<CompanyCopperationInformationInfoViewModel> vmList = new List<CompanyCopperationInformationInfoViewModel>();
            try
            {
                var modelList = _unitOfWork.GenericRepository<CompanyCopperationInformation>().GetAll(x => x.CompanyId == companyId).ToList();
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }
            return vmList;
        }

        public CompanyCopperationInformationInfoViewModel GetCompnayCopperationById(string companyId)
        {

            var model = _dbContext.CompanyCopperationInformations.Where(x => x.CompanyId == companyId).FirstOrDefault();
            if (model == null)
            {
                return null;
            }
            var vm = new CompanyCopperationInformationInfoViewModel(model);
            return vm;
        }

        public ResponseData InsertCompanyCopperation(CompanyCopperationInsertInformationInfoViewModel companyAdditionalInfo)
        {
            ResponseData res = new ResponseData();
            try
            {
                var model = new CompanyCopperationInsertInformationInfoViewModel().ConvertViewModel(companyAdditionalInfo);
                _unitOfWork.GenericRepository<CompanyCopperationInformation>().Add(model);
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

        public ResponseData UpdateCompanyCopperation(CompanyCopperationUpdateInformationInfoViewModel companyAdditionalInfo, string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                Guid _id = Guid.Parse(id);
                var modelById = _unitOfWork.GenericRepository<CompanyCopperationInformation>().GetById(_id);
                modelById.MOU = companyAdditionalInfo.MOU;
                //thời hạn MOU
                modelById.MouDuration = companyAdditionalInfo.MouDuration;
                modelById.CooperationField = companyAdditionalInfo.CooperationField;
                modelById.FrequenceUse = companyAdditionalInfo.FrequenceUse;
                //các hợp tác khác
                modelById.CooperationOther = companyAdditionalInfo.CooperationOther;
                modelById.Product = companyAdditionalInfo.Product;
                modelById.CoordinatingAgent = companyAdditionalInfo.CoordinatingAgent;
                _unitOfWork.GenericRepository<CompanyCopperationInformation>().Update(modelById);
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

        private List<CompanyCopperationInformationInfoViewModel> ConvertModelToViewModelList(List<CompanyCopperationInformation> modelList)
        {
            return modelList.Select(x => new CompanyCopperationInformationInfoViewModel(x)).ToList();

        }
    }
}
