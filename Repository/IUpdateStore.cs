using Test_API_LTSEDU.Service;

namespace Test_API_LTSEDU.Repository
{
    public interface IUpdateStore
    {
        Task<ErrorType> ThemSoLuongSanPham(int ProductDetailsId, int SoLuongCapNhat);
        Task<ErrorType> BotSoLuongSanPham(int ProductDetailsId, int SoLuongCapNhat);
    }
}
