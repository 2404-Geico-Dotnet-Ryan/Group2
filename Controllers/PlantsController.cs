using Microsoft.AspNetCore.Mvc;
using ProjectTwo.DTOs;
using ProjectTwo.Services;

namespace ProjectTwo.Controllers

{
    [ApiController]
    [Route("[controller]")]

    public class PlantsController : ControllerBase
    {
        private readonly IPlantsService _plantsService;

        public PlantsController(IPlantsService plantsService)
        {
            _plantsService = plantsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlantDTO>> GetPlants()
        {
            var plants = _plantsService.GetPlants();
            return Ok(plants);
        }

        [HttpGet("{PlantId}")]
        public ActionResult<PlantDTO> GetPlantById(int PlantId)
        {
            try
            {
                var plant = _plantsService.GetPlantById(PlantId);
                return Ok(plant);
            }
            catch (Exception e)
            {
                if (e.Message == "Plant not found")
                {
                    return NotFound(e.Message);
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public ActionResult<PlantDTO> AddPlant(PlantDTO plantDTO)
        {
            var plant = _plantsService.AddPlant(plantDTO);
            return Ok(plant);
        }

        [HttpPut("{PlantId}")]
        public ActionResult<PlantDTO> UpdatePlant(int PlantId, PlantDTO UpdatedPlant)
        {
            var plant = _plantsService.UpdatePlant(PlantId, UpdatedPlant);
            return Ok(plant);
        }

        [HttpDelete("{PlantId}")]
        public IActionResult DeletePlant(int PlantId)
        {
            _plantsService.DeletePlant(PlantId);
            return Ok();
        }
    }
}