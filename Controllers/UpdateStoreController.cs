using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_API_LTSEDU.Repository;
using Test_API_LTSEDU.Service;

namespace Test_API_LTSEDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateStoreController : ControllerBase
    {
        private readonly IUpdateStore updateStore;
        public UpdateStoreController()
        {
            updateStore = new UpdateStore();
        }
        // Gui lenh update so luong: Them vao kho hang
        [HttpPut("AddItemsQuan/{ProductDetailsId}/{Quantity}")]
        public async Task<IActionResult> AddItems (int ProductDetailsId, int Quantity)
        {
            var res = await updateStore.ThemSoLuongSanPham(ProductDetailsId, Quantity);
            if (res == ErrorType.CapNhatThanhCong) return Ok("Them hang muc thanh cong");
            else return BadRequest("San pham nhap vao khong ton tai");
        }

        // Gui lenh update so luong: Bot khoi kho hang
    }
}
