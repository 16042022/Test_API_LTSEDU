using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_API_LTSEDU.Model.Entity;
using Test_API_LTSEDU.Service;
using Test_API_LTSEDU.Service.Pagination;

namespace Test_API_LTSEDU.Repository
{
    public interface IStoreManagement
    {
        Task<PageResult<ProductDetails>> HienThiKhoHang(Pagination pgn);
    }
}
