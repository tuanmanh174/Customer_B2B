﻿using CustomerB2B.Models;
using CustomerB2B.Repositories;
using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.Services.CompanyTypeCompanyInfo;
using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerB2B.Services.CompanyRepresentativeInfo
{
    public class CompanyRepresentativeInfoService : ICompanyRepresentativeInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomerB2BDbContext _dbContext;
        public CompanyRepresentativeInfoService(IUnitOfWork unitOfWork, CustomerB2BDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }


        public List<CompanyRepresentativeInfoViewModel> GetAll(string companyId)
        {
            List<CompanyRepresentativeInfoViewModel> vmList = new List<CompanyRepresentativeInfoViewModel>();
            try
            {
                var modelList = _unitOfWork.GenericRepository<CompanyRepresentative>().GetAll().Where(x => x.IsDeleted == false).ToList();
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }
            return vmList;
        }
        public ResponseData InsertCompanyRepresentative(CompanyRepresentativeInfoViewModel companyRepresentativeInfo)
        {
            ResponseData res = new ResponseData();
            try
            {
                companyRepresentativeInfo.Id = new Guid().ToString();
                var model = new CompanyRepresentativeInfoViewModel().ConvertViewModel(companyRepresentativeInfo);
                _unitOfWork.GenericRepository<CompanyRepresentative>().Add(model);
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

        public ResponseData UpdateCompanyRepresentative(CompanyRepresentativeInfoViewModel companyRepresentativeInfo, string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                var modelById = _unitOfWork.GenericRepository<CompanyRepresentative>().GetById(id);
                modelById.PhoneNumber = companyRepresentativeInfo.PhoneNumber;
                modelById.Gender = companyRepresentativeInfo.Gender;
                modelById.UpdatedDate = DateTime.Now;
                _unitOfWork.GenericRepository<CompanyRepresentative>().Update(modelById);
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


        public ResponseData InsertRangeCompanyRepresentative(List<CompanyRepresentative> companyRepresentativeInfo)
        {
            ResponseData res = new ResponseData();
            try
            {
                _dbContext.CompanyRepresentatives.AddRange(companyRepresentativeInfo);
                _dbContext.SaveChanges();
                res.ResponseCode = ErrorCode.ERROR_SYSTEM_CODE;
                res.ResponseMessage = ErrorCode.ERROR_SYSTEM_MESSAGE;
                res.Data = null;
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
        private List<CompanyRepresentativeInfoViewModel> ConvertModelToViewModelList(List<CompanyRepresentative> modelList)
        {
            return modelList.Select(x => new CompanyRepresentativeInfoViewModel(x)).ToList();
        }
    }
}
