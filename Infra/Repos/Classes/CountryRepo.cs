using Domain.Entities;
using Infra.Data;
using Infra.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repos.Classes;

public class CountryRepo : ICountryRepo
{
    private readonly DataContext _context;

    public CountryRepo(DataContext context)
    {
        _context = context;
    }

    public async Task Add(Country country)
    {
        _context.Countries.Add(country);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Country country)
    {
        _context.Entry(country).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Country country)
    {
        _context.Countries.Remove(country);
        await _context.SaveChangesAsync();
    }

    public async Task<Country?> GetByName(string name) => await _context.Countries.FirstOrDefaultAsync(c => c.Name == name);

    public async Task<Country?> GetById(int id) => await _context.Countries.FindAsync(id);

    public async Task<List<Country>> GetAll() => await _context.Countries.AsNoTracking().ToListAsync();

}
