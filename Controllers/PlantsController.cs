using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTwo.Data;
using ProjectTwo.DTOs;
using ProjectTwo.Models;

namespace ProjectTwo.Controllers

{
    [ApiController]
    [Route("[controller]")]

    public class PlantsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlantsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlantDTO>> GetPlants()
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

        [HttpGet("{PlantId}")]
        public ActionResult<PlantDTO> GetPlantById(int PlantId)
        {
            var plant = _context.Plants
            //.Include(h => h.PurchaseHistory)
            .FirstOrDefault(p => p.PlantId == PlantId);
            //var plant = _context.Plants.Find(PlantId);
            var plantDTO = new PlantDTO
            {
                PlantName = plant.PlantName,
                Price = plant.Price,
                Quantity = plant.Quantity,
            };
            return plantDTO;
        }

        [HttpPost]
        public ActionResult<PlantDTO> AddPlant(PlantDTO plantDTO)
        {
            // var plant = await _context.Plants.FirstAsync(c => c.PlantName == plantDTO.PlantName);

            var plant = new Plant
            {
                PlantName = plantDTO.PlantName,
                Price = plantDTO.Price,
                Quantity = plantDTO.Quantity,
            };

            _context.Plants.Add(plant);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPlants), new { id = plant.PlantId }, plantDTO);
        }

        //   [HttpPost]
        // public async Task <ActionResult<PlantDTO>> PostPlant(PlantDTO plantDTO)
        // {
        //     //var PurchaseHistory = await _context.PurchaseHistories.FindAsync(p => p.PlantName==plantDTO.PlantName); ***FIX ME ****
        //     var plant = new Plant
        //     {
        //         PlantName = plantDTO.PlantName,
        //         Price = plantDTO.Price,
        //         Quantity = plantDTO.Quantity,

        //     };

        //     _context.Plants.Add(plant);
        //     _context.SaveChanges();
        //     //return Ok(plantDTO);
        //     return CreatedAtAction(nameof(GetPlants), new { UserId = plant.PlantId }, plantDTO);
        // }

        [HttpPut("{PlantId}")]
        public ActionResult<PlantDTO> UpdatePlant(int PlantId, PlantDTO UpdatedPlant)
        {
            var plant = _context.Plants.FirstOrDefault(p => p.PlantId == PlantId);

            plant.PlantName = UpdatedPlant.PlantName;
            plant.Price = UpdatedPlant.Price;
            plant.Quantity = UpdatedPlant.Quantity;

            _context.Plants.Update(plant);
            _context.SaveChanges();

            return Ok(UpdatedPlant);
        }

        [HttpDelete("{PlantId}")]
        public IActionResult DeletePlant(int PlantId)
        {
            var plant = _context.Plants.FirstOrDefault(p => p.PlantId == PlantId);
            _context.Plants.Remove(plant);
            _context.SaveChanges();

            return Ok();
        }
    }
}