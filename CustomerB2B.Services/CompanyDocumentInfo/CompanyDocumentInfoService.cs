using CustomerB2B.Models;
using CustomerB2B.Repositories;
using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.Services.CompanyGroupInfo;
using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyDocumentInfo
{
    public class CompanyDocumentInfoService : ICompanyDocumentInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomerB2BDbContext _dbContext;
        public CompanyDocumentInfoService(IUnitOfWork unitOfWork, CustomerB2BDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }

        public ResponseData DeleteCompnayDocument(string id)
        {
            throw new NotImplementedException();
        }

        public List<CompanyDocumentInfoViewModel> GetAll(string companyId)
        {
            List<CompanyDocumentInfoViewModel> vmList = new List<CompanyDocumentInfoViewModel>();
            try
            {
                var modelList = _unitOfWork.GenericRepository<CompanyDocument>().GetAll(x => x.CompanyId == companyId).ToList();
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }
            return vmList;
        }

        public CompanyDocumentInfoViewModel GetCompanyDocumentById(string id)
        {
            var model = _unitOfWork.GenericRepository<CompanyDocument>().GetById(id);
            var vm = new CompanyDocumentInfoViewModel(model);
            return vm;
        }

        public ResponseData InsertCompanyDocument(CompanyDocumentInfoViewModel companyDocumentInfo)
        {
            ResponseData res = new ResponseData();
            try
            {
                companyDocumentInfo.Id = new Guid().ToString();
                var model = new CompanyDocumentInfoViewModel().ConvertViewModel(companyDocumentInfo);
                _unitOfWork.GenericRepository<CompanyDocument>().Add(model);
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

        public ResponseData UpdateCompanyDocument(CompanyDocumentInfoViewModel companyDocumentInfo, string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                var modelById = _unitOfWork.GenericRepository<CompanyDocument>().GetById(id);
                modelById.CompanyId = companyDocumentInfo.CompanyId;
                modelById.DocumentName = companyDocumentInfo.DocumentName;
                modelById.Path = companyDocumentInfo.Path;
                modelById.Size = companyDocumentInfo.Size;
                _unitOfWork.GenericRepository<CompanyDocument>().Update(modelById);
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

        private List<CompanyDocumentInfoViewModel> ConvertModelToViewModelList(List<CompanyDocument> modelList)
        {
            return modelList.Select(x => new CompanyDocumentInfoViewModel(x)).ToList();
        }
    }
}
