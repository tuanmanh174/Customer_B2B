using CustomerB2B.Models;
using CustomerB2B.Repositories;
using CustomerB2B.Repositories.Interfaces;
using CustomerB2B.Utilities;
using CustomerB2B.ViewModels;
namespace CustomerB2B.Services.CompanyGroupInfo
{
    public class CompanyGroupInfoService : ICompanyGroupInfo
    {
        private IUnitOfWork _unitOfWork;
        public CompanyGroupInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ResponseData DeleteCompnayGroup(string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                var model = _unitOfWork.GenericRepository<CompanyGroup>().GetById(id);
                _unitOfWork.GenericRepository<CompanyGroup>().Delete(model);
                _unitOfWork.Save();
                res.ResponseCode = ErrorCode.SUCCESS_CODE;
                res.ResponseMessage = ErrorCode.REMOVE_SUCCESS_MESSAGE;
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

        public PagedResult<CompanyGroupInfoViewModel> GetAll(int pageNumber, int pageSize)
        {

            int totalCount;
            List<CompanyGroupInfoViewModel> vmList = new List<CompanyGroupInfoViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<CompanyGroup>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<CompanyGroup>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception ex)
            {
                throw;
            }
            var result = new PagedResult<CompanyGroupInfoViewModel>()
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        public CompanyGroupInfoViewModel GetCompanyGroupById(string id)
        {
            var model = _unitOfWork.GenericRepository<CompanyGroup>().GetById(id);
            var vm = new CompanyGroupInfoViewModel(model);
            return vm;
        }

        public ResponseData InsertCompanyGroup(CompanyGroupInfoViewModel companyGroupInfo)
        {
            ResponseData res = new ResponseData();
            try
            {

                var model = new CompanyGroupInfoViewModel().ConvertViewModel(companyGroupInfo);
                _unitOfWork.GenericRepository<CompanyGroup>().Add(model);
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

        public ResponseData UpdateCompanyGroup(CompanyGroupInfoViewModel companyGroupInfo, string id)
        {
            ResponseData res = new ResponseData();
            try
            {
                var modelById = _unitOfWork.GenericRepository<CompanyGroup>().GetById(id);
                modelById.Code = companyGroupInfo.GroupCode;
                modelById.Name = companyGroupInfo.GroupName;
                modelById.UpdatedDate = DateTime.Now;
                _unitOfWork.GenericRepository<CompanyGroup>().Update(modelById);
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

        private List<CompanyGroupInfoViewModel> ConvertModelToViewModelList(List<CompanyGroup> modelList)
        {
            return modelList.Select(x => new CompanyGroupInfoViewModel(x)).ToList();
        }


    }
}
