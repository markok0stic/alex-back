using Microsoft.EntityFrameworkCore;
using MusiciansAbilities.Models;

namespace MusiciansAbilities.Services;

public interface IDbService
{
    Task<bool> InsertUser(User user);
    Task<bool> UpdateUser(User user);
    Task<bool> InsertExperimentResultsForUser(List<ExperimentResult> result, string userId);

    Task<IEnumerable<User>> GetUsers(string userId = "");
    Task<IEnumerable<ExperimentResult>> GetExperimentResultsForUser(string userId);
}
public class DbService: IDbService
{
    private readonly DbResultsContext _dbResultsContext;

    public DbService(DbResultsContext dbResultsContext)
    {
        _dbResultsContext = dbResultsContext;
    }

    public async Task<bool> InsertUser(User user)
    {
        _dbResultsContext.Users.Add(user);
        await _dbResultsContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateUser(User user)
    {
        _dbResultsContext.Users.Update(user);
        await _dbResultsContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> InsertExperimentResultsForUser(List<ExperimentResult> result, string userId)
    {
        var res = false;
        var user = await _dbResultsContext.Users.FirstOrDefaultAsync(u => u.SecretId == userId);
        if (user != null)
        {
            user.ExperimentResults = result;
            _dbResultsContext.Users.Update(user);
            await _dbResultsContext.SaveChangesAsync();
            
            res = true;
        }

        return res;
    }

    public async Task<IEnumerable<User>> GetUsers(string userId = "")
    {
        var res = new List<User>();
        if (string.IsNullOrEmpty(userId))
        {
            res = await _dbResultsContext.Users
                .Include(u=>u.ExperimentResults)
                .ToListAsync();
        }
        else
        {
            res = await _dbResultsContext.Users
                .Include(u=>u.ExperimentResults)
                .Where(u=>u.SecretId == userId)
                .ToListAsync();
        }

        return res;
    }

    public async Task<IEnumerable<ExperimentResult>> GetExperimentResultsForUser(string userId)
    {
        var res = new List<ExperimentResult>();
        var listUsers = await _dbResultsContext.Users
            .Include(u=>u.ExperimentResults)
            .Where(u=>u.SecretId == userId)
            .ToListAsync();
        var u = listUsers.FirstOrDefault();
        if (u != null)
        {
            res = u.ExperimentResults;
        }
        
        return res;
    }
}