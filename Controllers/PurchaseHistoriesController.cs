using Microsoft.AspNetCore.Mvc;
using ProjectTwo.DTOs;
using ProjectTwo.Services;

namespace ProjectTwo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseHistoriesController : ControllerBase
    {

        private readonly IPurchaseHistoriesService _purchaseHistoriesService;

        public PurchaseHistoriesController(IPurchaseHistoriesService purchaseHistoriesService)
        {
            _purchaseHistoriesService = purchaseHistoriesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PurchaseHistoryDTO>> GetPurchaseHistories()
        {
            var purchaseHistories = _purchaseHistoriesService.GetPurchaseHistories();
            return Ok(purchaseHistories);
        }

        [HttpGet("{PurchaseHistoriesId}")]
        public ActionResult<PurchaseHistoryDTO> GetPurchaseHistoryById(int PurchaseHistoryId)
        {
            var purchaseHistory = _purchaseHistoriesService.GetPurchaseHistoryById(PurchaseHistoryId);
            return Ok(purchaseHistory);
        }

        [HttpPost]
        public ActionResult<PurchaseHistoryDTO> AddPurchaseHistory(PurchaseHistoryDTO purchaseHistoryDTO)
        {
            var purchaseHistory = _purchaseHistoriesService.AddPurchaseHistory(purchaseHistoryDTO);
            return Ok(purchaseHistory);
        }


        [HttpPut("{PurchaseHistoryId}")]
        public ActionResult<PurchaseHistoryDTO> UpdatePurchaseHistory(int PurchaseHistoryId, PurchaseHistoryDTO UpdatedPurchaseHistory)
        {
            var purchaseHistory = _purchaseHistoriesService.UpdatePurchaseHistory(PurchaseHistoryId, UpdatedPurchaseHistory);
            return Ok(purchaseHistory);
        }

        [HttpDelete("{PurchaseHistoryId}")]
        public IActionResult DeletePurchaseHistory(int PurchaseHistoryId)
        {
            _purchaseHistoriesService.DeletePurchaseHistory(PurchaseHistoryId);
            return Ok();
        }

        [HttpPost("Buy")]
        public ActionResult<PurchaseHistoryDTO> BuyPlant(PurchaseHistoryDTO purchaseHistoryDTO)
        {
            try
            {
                var purchaseHistory = _purchaseHistoriesService.BuyPlant(purchaseHistoryDTO.PlantId, purchaseHistoryDTO.UserId, purchaseHistoryDTO.Quantity);
                return Ok(purchaseHistory);
            }
            catch (Exception e)
            {
                if (e.Message == "Plant not found" || e.Message == "User not found")
                {
                    return NotFound(e.Message);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}