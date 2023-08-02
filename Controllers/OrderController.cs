using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using Test_API_LTSEDU.Repository;

namespace Test_API_LTSEDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ITransaction transaction;
        public OrderController()
        {
            transaction = new Transaction();
        }
        // Gui lenh thuc hien mua hang
        [HttpPut("Transaction/{ProductDetailsId}/{Quantity}")]
        public async Task<IActionResult> DatMuaHang(int ProductDetailsId, int Quantity)
        {
            var res = await transaction.MuaHang(ProductDetailsId, Quantity);
            if (res != Service.ErrorType.DatHangThanhCong)
            {
                if (res == Service.ErrorType.SanPhamKhongDuSoLuongBan)
                { return BadRequest("San pham khong du ton kho"); }
                else if (res == Service.ErrorType.SanPhamKhongConHang)
                { return BadRequest("San pham het hang"); } 
                else if (res == Service.ErrorType.SanPhamKhongTonTai)
                { return BadRequest("San pham nhap khong ton tai"); }
            } 
            return Ok("Dat hang thanh cong");
        }
    }
}

