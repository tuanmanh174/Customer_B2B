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

        public void DeleteCompnayGroup(string id)
        {
            var model = _unitOfWork.GenericRepository<CompanyGroup>().GetById(id);
            _unitOfWork.GenericRepository<CompanyGroup>().Delete(model);
            _unitOfWork.Save();
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

        public void InsertCompanyGroup(CompanyGroupInfoViewModel companyGroupInfo)
        {
            var model = new CompanyGroupInfoViewModel().ConvertViewMoodel(companyGroupInfo);
            _unitOfWork.GenericRepository<CompanyGroup>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateCompanyGroup(CompanyGroupInfoViewModel companyGroupInfo)
        {
            var model = new CompanyGroupInfoViewModel().ConvertViewMoodel(companyGroupInfo);
            var modelById = _unitOfWork.GenericRepository<CompanyGroup>().GetById(model);
            modelById.Code = companyGroupInfo.GroupCode;
            modelById.Name = companyGroupInfo.GroupName;
            modelById.UpdatedDate = DateTime.Now;
            _unitOfWork.GenericRepository<CompanyGroup>().Update(modelById);
            _unitOfWork.Save();
        }

        private List<CompanyGroupInfoViewModel> ConvertModelToViewModelList(List<CompanyGroup> modelList)
        {
            return modelList.Select(x => new CompanyGroupInfoViewModel(x)).ToList();
        }


    }
}
