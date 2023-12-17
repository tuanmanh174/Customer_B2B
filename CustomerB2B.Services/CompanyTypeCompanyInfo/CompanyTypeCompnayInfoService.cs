using CustomerB2B.Models;
using CustomerB2B.Repositories;
using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.Services.CompanyGroupInfo;
using CustomerB2B.Services.CompanyTypeInfo;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyTypeCompanyInfo
{
    public class CompanyTypeCompnayInfoService : ICompanyTypeCompanyInfo
    {
        private IUnitOfWork _unitOfWork;
        private CustomerB2BDbContext _dbContext;
        public CompanyTypeCompnayInfoService(IUnitOfWork unitOfWork, CustomerB2BDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }



        public ResponseData InsertCompanyTypeCompany(CompanyTypeCompanyInfoViewModel companyTypeCompanyInfo)
        {
            ResponseData res = new ResponseData();
            try
            {

                var modelCompanyTypeCompany = _dbContext.CompanyTypeCompany.Where(x => x.CompanyId == companyTypeCompanyInfo.CompanyId && x.CompanyTypeId == companyTypeCompanyInfo.CompanyTypeId).FirstOrDefault();
                if (modelCompanyTypeCompany != null)
                {
                    res.ResponseCode = ErrorCode.DATA_EXISTS_CODE;
                    res.ResponseMessage = ErrorCode.DATA_EXISTS_MESSAGE;
                    return res;
                }
                companyTypeCompanyInfo.Id = new Guid().ToString();
                var model = new CompanyTypeCompanyInfoViewModel().ConvertViewModel(companyTypeCompanyInfo);
                _unitOfWork.GenericRepository<CompanyTypeCompany>().Add(model);
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

        public ResponseData RemoveCompanyTypeCompany(string companyId, string companyTypeId)
        {
            ResponseData res = new ResponseData();
            try
            {
                var modelCompanyTypeCompany = _dbContext.CompanyTypeCompany.Where(x => x.CompanyTypeId == companyTypeId && x.CompanyId == companyId).FirstOrDefault();
                if (modelCompanyTypeCompany == null)
                {
                    res.ResponseCode = ErrorCode.DATA_NOT_EXISTS_CODE;
                    res.ResponseMessage = ErrorCode.DATA_NOT_EXISTS_MESSAGE;
                    return res;
                }
                else
                {
                    var id = modelCompanyTypeCompany.Id;
                    var modelById = _unitOfWork.GenericRepository<CompanyTypeCompany>().GetById(id);
                    _unitOfWork.GenericRepository<CompanyTypeCompany>().Delete(modelById);
                    _unitOfWork.Save();
                    res.ResponseCode = ErrorCode.SUCCESS_CODE;
                    res.ResponseMessage = ErrorCode.REMOVE_SUCCESS_MESSAGE;
                    res.Data = modelById;
                }

            }
            catch (Exception ex)
            {
                res.ResponseCode = ErrorCode.ERROR_SYSTEM_CODE;
                res.ResponseMessage = ErrorCode.ERROR_SYSTEM_MESSAGE;
                res.Data = null;
            }
            return res;
        }
    }
}
