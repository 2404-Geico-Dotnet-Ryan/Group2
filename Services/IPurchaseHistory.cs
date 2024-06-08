using ProjectTwo.DTOs;

namespace ProjectTwo.Services
{
    public interface IPurchaseHistoriesService
    {
        IEnumerable<PurchaseHistoryDTO> GetPurchaseHistories();
        PurchaseHistoryDTO GetPurchaseHistoryById(int PurchaseHistoryId);
        PurchaseHistoryDTO AddPurchaseHistory(PurchaseHistoryDTO purchaseHistoryDTO);
        PurchaseHistoryDTO UpdatePurchaseHistory(int PurchaseHistoryId, PurchaseHistoryDTO purchaseHistoryDTO);
        void DeletePurchaseHistory(int PurchaseHistoryId);
        PurchaseHistoryDTO BuyPlant(int PlantId, int UserId, int Quantity);
    }
}