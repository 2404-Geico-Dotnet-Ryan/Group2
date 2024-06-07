using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTwo.Data;
using ProjectTwo.DTOs;
using ProjectTwo.Models;

namespace ProjectTwo.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseHistoriesController : ControllerBase
    {

        private readonly AppDbContext _context;

        public PurchaseHistoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PurchaseHistoryDTO>> GetPlants()
        {
            var purchaseHistories = _context.PurchaseHistories
                .Include(p => p.Plant)  //***Do we needs plural???
                .Select(p => new PurchaseHistoryDTO
                {
                    UserId = p.UserId,
                    PlantId = p.PlantId,
                    Quantity = p.Quantity,
                    Price = p.Price

                }).ToList();


            return purchaseHistories;
        }

        [HttpGet("{PurchaseHistoriesId}")]
        public ActionResult<PurchaseHistoryDTO> GetPurchaseHistoryById(int PurchaseHistoryId)
        {
            var purchaseHistory = _context.PurchaseHistories.Find(PurchaseHistoryId);

            //var plant = _context.Plants.Find(PlantId);
            var purchaseHistoryDTO = new PurchaseHistoryDTO  //Questionable????
            {
                //UserId = purchaseHistory.UserId,
                PlantId = purchaseHistory.PlantId,
                Quantity = purchaseHistory.Quantity,
                Price = purchaseHistory.Price
            };
            return purchaseHistoryDTO;
        }

        [HttpPost]
        public ActionResult<PurchaseHistoryDTO> AddPurchaseHistory(PurchaseHistoryDTO purchaseHistoryDTO)
        {


            var purchaseHistory = new PurchaseHistory
            {
                PlantId = purchaseHistoryDTO.PlantId,
                Quantity = purchaseHistoryDTO.Quantity,
                Price = purchaseHistoryDTO.Price
            };

            _context.PurchaseHistories.Add(purchaseHistory);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPurchaseHistoryById), new { purchaseHistoryId = purchaseHistory.PurchaseHistoryId }, purchaseHistoryDTO);
            //Check the GetPurchaseHistoryById ****************************
        }


        [HttpPut("{PurchaseHistoryId}")]
        public ActionResult<PurchaseHistoryDTO> UpdatePurchaseHistory(int PurchaseHistoryId, PurchaseHistoryDTO UpdatedPurchaseHistory)
        {
            var purchaseHistory = _context.PurchaseHistories.FirstOrDefault(h => h.PurchaseHistoryId == PurchaseHistoryId);

            //purchaseHistory.PlantId = UpdatedPurchaseHistory.PlantId;
            purchaseHistory.Quantity = UpdatedPurchaseHistory.Quantity;
            //purchaseHistory.Price = UpdatedPurchaseHistory.Price   //****more questions 

            _context.PurchaseHistories.Update(purchaseHistory);
            _context.SaveChanges();

            return Ok(UpdatedPurchaseHistory);
        }

        [HttpDelete("{PurchaseHistoryId}")]
        public IActionResult DeletePurchseHistory(int PurchaseHistoryId)
        {
            var purchaseHistory = _context.PurchaseHistories.FirstOrDefault(h => h.PurchaseHistoryId == PurchaseHistoryId);
            _context.PurchaseHistories.Remove(purchaseHistory);
            _context.SaveChanges();

            return Ok();
        }
    }
}