using Microsoft.EntityFrameworkCore;
using ProjectTwo.Data;
using ProjectTwo.DTOs;
using ProjectTwo.Models;

namespace ProjectTwo.Services
{
    public class PurchaseHistoriesService : IPurchaseHistoriesService
    {
        private readonly AppDbContext _context;

        public PurchaseHistoriesService(AppDbContext context)
        {
            _context = context;
        }

        public PurchaseHistoryDTO AddPurchaseHistory(PurchaseHistoryDTO purchaseHistoryDTO)
        {
            var purchaseHistory = new PurchaseHistory
            {
                UserId = purchaseHistoryDTO.UserId,
                PlantId = purchaseHistoryDTO.PlantId,
                Quantity = purchaseHistoryDTO.Quantity,
                Price = purchaseHistoryDTO.Price
            };

            _context.PurchaseHistories.Add(purchaseHistory);
            _context.SaveChanges();

            return purchaseHistoryDTO;
        }

        public void DeletePurchaseHistory(int PurchaseHistoryId)
        {
            var purchaseHistory = _context.PurchaseHistories.FirstOrDefault(h => h.PurchaseHistoryId == PurchaseHistoryId);
            _context.PurchaseHistories.Remove(purchaseHistory);
            _context.SaveChanges();
        }

        public IEnumerable<PurchaseHistoryDTO> GetPurchaseHistories()
        {
            var purchaseHistories = _context.PurchaseHistories
                .Include(p => p.Plant)  
                .Select(p => new PurchaseHistoryDTO
                {
                    UserId = p.UserId,
                    PlantId = p.PlantId,
                    Quantity = p.Quantity,
                    Price = p.Price

                }).ToList();


            return purchaseHistories;
        }

        public PurchaseHistoryDTO GetPurchaseHistoryById(int PurchaseHistoryId)
        {
            var purchaseHistory = _context.PurchaseHistories.Find(PurchaseHistoryId);

            
            var purchaseHistoryDTO = new PurchaseHistoryDTO  
            {
                UserId = purchaseHistory.UserId,
                PlantId = purchaseHistory.PlantId,
                Quantity = purchaseHistory.Quantity,
                Price = purchaseHistory.Price
            };
            return purchaseHistoryDTO;
        }

        public PurchaseHistoryDTO UpdatePurchaseHistory(int PurchaseHistoryId, PurchaseHistoryDTO purchaseHistoryDTO)
        {
            var purchaseHistory = _context.PurchaseHistories.FirstOrDefault(h => h.PurchaseHistoryId == PurchaseHistoryId);

            purchaseHistory.UserId = purchaseHistoryDTO.UserId;
            purchaseHistory.PlantId = purchaseHistoryDTO.PlantId;
            purchaseHistory.Quantity = purchaseHistoryDTO.Quantity;
            purchaseHistory.Price = purchaseHistoryDTO.Price;   

            _context.PurchaseHistories.Update(purchaseHistory);
            _context.SaveChanges();

            return purchaseHistoryDTO;
        }

        public PurchaseHistoryDTO BuyPlant(int PlantId, int UserId, int Quantity)
        {
            var plant = _context.Plants.Find(PlantId);
            var user = _context.Users.Find(UserId);

            if (plant == null)
            {
                throw new Exception("Plant not found");
            }

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var purchaseHistory = new PurchaseHistoryDTO
            {
                UserId = UserId,
                PlantId = PlantId,
                Quantity = Quantity,
                Price = plant.Price
            };

            return AddPurchaseHistory(purchaseHistory);
        }
    }
}