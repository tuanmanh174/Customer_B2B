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
        public PagedResult<CompanyGroupInfoViewModel> GetAll(int pageNumber, int pageSize)
        {
            var companyGroupViewModel = new CompanyGroupInfoViewModel();
            int totalCount;
            List<CompanyGroupInfoViewModel> vmList = new List<CompanyGroupInfoViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<CompanyGroup>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<CompanyGroup>().GetAll().ToList().Count;
                //vmList = ConvertModelToViewModelList(modelList);
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

        //private List<CompanyGroupInfoViewModel> ConvertModelToViewModelList(List<CompanyGroup> modelList)
        //{
           
        //}
    }
}
