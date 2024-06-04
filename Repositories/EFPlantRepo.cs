using ProjectTwo.Data;
using ProjectTwo.Models;

class EFPlantRepo : IPlantRepo
{
    private readonly AppDbContext _context;

    public EFPlantRepo(AppDbContext context)
    {
        _context = context;
    }
    public Plant AddPlant(Plant p)
    {
        _context.Plants.Add(p);
        return p;
    }

    public Plant? DeletePlant(int id)
    {
        var plant = _context.Plants.Find(id);
        if (plant != null)
        {
            _context.Plants.Remove(plant);
        }
        return plant;
    }

    public List<Plant> GetAllPlants()
    {
        return _context.Plants.ToList();
    }

    public Plant? GetPlant(int id)
    {
        return _context.Plants.Find(id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public Plant? UpdatePlant(Plant updatedPlant)
    {
        _context.Plants.Update(updatedPlant);
        return updatedPlant;
    }
}