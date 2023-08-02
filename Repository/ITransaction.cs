using Test_API_LTSEDU.Service;

namespace Test_API_LTSEDU.Repository
{
    public interface ITransaction
    {
        Task<ErrorType> MuaHang(int ProductId, int SoLuongMua);
    }
}
