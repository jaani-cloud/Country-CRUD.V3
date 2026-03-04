using Domain.Entities;
using Infra.Data;
using Infra.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repos.Classes;

public class CityRepo : ICityRepo
{
    private readonly DataContext _context;
    public CityRepo(DataContext context)
    {
        _context = context;
    }

    public async Task Add(City city)
    {
        _context.Cities.Add(city);
        await _context.SaveChangesAsync();
    }
    public async Task Update(City city)
    {
        _context.Cities.Update(city);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(City city)
    {
        _context.Cities.Remove(city);
        await _context.SaveChangesAsync();
    }

    public async Task<City?> GetByName(string name) =>
        await _context.Cities.AsNoTracking().Include(c => c.State).FirstOrDefaultAsync(c => c.Name == name);

    public async Task<City?> GetBYId(int id) => await _context.Cities.Include(c => c.State).FirstOrDefaultAsync(c => c.Id == id);
    public async Task<List<City>> GetAll() => await _context.Cities.AsNoTracking().Include(c => c.State).ToListAsync();
}
