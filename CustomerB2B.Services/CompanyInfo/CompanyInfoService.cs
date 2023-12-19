using CustomerB2B.Models;
using CustomerB2B.Repositories;
using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.Services.CompanyRepresentativeInfo;
using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyInfo
{
    public class CompanyInfoService : ICompanyInfo
    {

        private IUnitOfWork _unitOfWork;
        private readonly CustomerB2BDbContext _dbContext;
        public CompanyInfoService(IUnitOfWork unitOfWork, CustomerB2BDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }
        public ResponseData DeleteCompany(string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                var _id = Guid.Parse(id);
                var modelById = _unitOfWork.GenericRepository<Company>().GetById(_id);
                modelById.IsDeleted = true;
                _unitOfWork.GenericRepository<Company>().Update(modelById);
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

        public PagedResult<CompanyInfoViewModel> GetAll(int pageNumber, int pageSize)
        {

            int totalCount;
            List<CompanyInfoViewModel> vmList = new List<CompanyInfoViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                vmList = (from a in _dbContext.Companies
                          join b in _dbContext.CompanyGroups on a.GroupId equals b.Id.ToString()
                          where a.IsDeleted == false && b.IsDeleted == false
                          select new CompanyInfoViewModel
                          {
                              Id = a.Id,
                              Name = a.Name,
                              Code = a.Code,
                              TaxCode = a.TaxCode,
                              PhoneNumber = a.PhoneNumber,
                              Email = a.Email,
                              Address = a.Address,
                              DistrictId = a.DistrictId,
                              City = a.City,
                              GroupId = Guid.Parse(a.GroupId),
                              GroupName = b.Name,
                              lstCompanyType = (from ctc in _dbContext.CompanyTypeCompany
                                                join ct in _dbContext.CompanyTypes on ctc.CompanyTypeId equals ct.Id.ToString()
                                                where ctc.CompanyId == a.Id.ToString()
                                                select new CompanyTypeInfoViewModel
                                                {
                                                    CompanyTypeName = ct.Name,
                                                    CompanyTypeCode = ct.Code,
                                                    Notice = ct.Notice,
                                                    Id = a.Id,
                                                }).ToList()
                          }).ToList();

                var modelList = vmList.Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = vmList.Where(x => x.IsDeleted == false).ToList().Count;
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

        public ResponseData InsertCompany(CompanyInsertInfoViewModel companyInfo)
        {
            ResponseData res = new ResponseData();
            try
            {
                var modelCompanyInfo = _dbContext.Companies.Where(x => x.Code == companyInfo.Code).FirstOrDefault();
                if (modelCompanyInfo != null)
                {
                    res.ResponseCode = ErrorCode.DATA_EXISTS_CODE;
                    res.ResponseMessage = ErrorCode.DATA_EXISTS_MESSAGE;
                    return res;
                }
                companyInfo.Id = new Guid().ToString();
                var model = new CompanyInsertInfoViewModel().ConvertViewModel(companyInfo);
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

        public ResponseData UpdateCompany(CompanyUpdateInfoViewModel companyInfo, string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                var modelCompanyInfo = _dbContext.Companies.Where(x => x.Code == companyInfo.Code).FirstOrDefault();
                if (modelCompanyInfo != null)
                {
                    res.ResponseCode = ErrorCode.DATA_EXISTS_CODE;
                    res.ResponseMessage = ErrorCode.DATA_EXISTS_MESSAGE;
                    return res;
                }
                var modelById = _unitOfWork.GenericRepository<Company>().GetById(id);
                modelById.Code = companyInfo.Code;
                modelById.Name = companyInfo.Name;
                modelById.PhoneNumber = companyInfo.PhoneNumber;
                modelById.Address = companyInfo.Address;
                modelById.City = companyInfo.City;
                modelById.Notice = companyInfo.Notice;
                modelById.DistrictId = companyInfo.DistrictId;
                modelById.Email = companyInfo.Email;
                modelById.TaxCode = companyInfo.TaxCode;
                modelById.GroupId = companyInfo.GroupId.ToString();
                modelById.UpdatedBy = "manhdt";
                modelById.UpdatedDate = DateTime.Now;
                _unitOfWork.GenericRepository<Company>().Update(modelById);
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
