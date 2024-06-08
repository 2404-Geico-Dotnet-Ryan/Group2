using ProjectTwo.Data;
using ProjectTwo.DTOs;
using ProjectTwo.Models;

namespace ProjectTwo.Services
{
    public class PlantsService : IPlantsService
    {
        private readonly AppDbContext _context;

        public PlantsService(AppDbContext context)
        {
            _context = context;
        }

        public PlantDTO AddPlant(PlantDTO plantDTO)
        {
            var plant = new Plant
            {
                PlantName = plantDTO.PlantName,
                Price = plantDTO.Price,
                Quantity = plantDTO.Quantity,
            };

            _context.Plants.Add(plant);
            _context.SaveChanges();

            return plantDTO;
        }

        public void DeletePlant(int PlantId)
        {
            var plant = _context.Plants.FirstOrDefault(p => p.PlantId == PlantId);
            _context.Plants.Remove(plant);
            _context.SaveChanges();
        }

        public PlantDTO GetPlantById(int PlantId)
        {
            var plant = _context.Plants
            //.Include(h => h.PurchaseHistory)
            .FirstOrDefault(p => p.PlantId == PlantId);

            if (plant == null)
            {
                throw new Exception("Plant not found");
            }

            //var plant = _context.Plants.Find(PlantId);
            var plantDTO = new PlantDTO
            {
                PlantName = plant.PlantName,
                Price = plant.Price,
                Quantity = plant.Quantity,
            };
            return plantDTO;
        }

        public IEnumerable<PlantDTO> GetPlants()
        {
            var plants = _context.Plants
                //.Include(p => p.PurchaseHistory)
                .Select(p => new PlantDTO
                {
                    PlantName = p.PlantName,
                    Price = p.Price,
                    Quantity = p.Quantity
                }).ToList();

            return plants;
        }

        public PlantDTO UpdatePlant(int PlantId, PlantDTO plantDTO)
        {
            var plant = _context.Plants.FirstOrDefault(p => p.PlantId == PlantId);

            plant.PlantName = plantDTO.PlantName;
            plant.Price = plantDTO.Price;
            plant.Quantity = plantDTO.Quantity;

            _context.Plants.Update(plant);
            _context.SaveChanges();

            return plantDTO;
        }
    }
}