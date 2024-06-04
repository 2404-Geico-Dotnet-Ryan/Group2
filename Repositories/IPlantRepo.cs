using ProjectTwo.Models;

interface IPlantRepo
{
    public Plant AddPlant(Plant p);
    public Plant? GetPlant(int id);
    public List<Plant> GetAllPlants();
    public Plant? UpdatePlant(Plant updatedPlant);
    public Plant? DeletePlant(int id);
    public void Save();
}