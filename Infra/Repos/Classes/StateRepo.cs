using Domain.Entities;
using Infra.Data;
using Infra.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repos.Classes;

public class StateRepo : IStateRepo
{
    private readonly DataContext _context;

    public StateRepo(DataContext context)
    {
        _context = context;
    }

    public async Task Add(State state)
    {
        _context.States.Add(state);
        await _context.SaveChangesAsync();
    }
    public async Task Update(State state)
    {
        _context.Entry(state).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(State state)
    {
        _context.States.Remove(state);
        await _context.SaveChangesAsync();
    }

    public async Task<State?> GetByName(string name) =>
        await _context.States.AsNoTracking().Include(s => s.Country).FirstOrDefaultAsync(s => s.Name == name);

    public async Task<State?> GetById(int id) => await _context.States.Include(s => s.Country).FirstOrDefaultAsync(s => s.Id == id);

    public async Task<List<State>> GetAll() => await _context.States.AsNoTracking().Include(s => s.Country).ToListAsync();
}
 