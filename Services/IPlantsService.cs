using ProjectTwo.DTOs;

namespace ProjectTwo.Services
{
    public interface IPlantsService
    {
        IEnumerable<PlantDTO> GetPlants();
        PlantDTO GetPlantById(int PlantId);
        PlantDTO AddPlant(PlantDTO plantDTO);
        PlantDTO UpdatePlant(int PlantId, PlantDTO plantDTO);
        void DeletePlant(int PlantId);

    }
}