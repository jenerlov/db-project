using dbproject.Models.Forms;
using dbproject.Contexts;
using dbproject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace dbproject.Services

{

internal class CaseService
{
    private readonly DataContext _context = new DataContext();
    private readonly UserService _userService = new UserService();

    public async Task<CaseEntity>CreateAsync(CaseRegForm form)
    {
        var caseEntity = new CaseEntity()
        {
            Description = form.Description,
            Title = form.Title,
            StatusTypeId = 1,
            // UserId = (await _userService.GetOrCreateIfNotExistAsync(form)).UserId,

        };

        _context.Add(caseEntity);
        await _context.SaveChangesAsync();

        return caseEntity;
    }

    public async Task<IEnumerable<CaseEntity>> GetAllAsync()
    {
        return await _context.Cases
            .Include(x => x.User)
            .Include(x => x.Status)
            .Include(x => x.Comments)
            .ToListAsync();
    }

    public async Task<CaseEntity> GetAsync(string caseId)
    {
        var caseEntity = await _context.Cases
        .Include(x => x.User)
        .Include(x => x.Status)
        .Include(x => x.Comments)
        .FirstOrDefaultAsync(x => x.CaseId == caseId);
        if (caseEntity != null)
        return caseEntity;

        return null!;
    }

    public async Task ChangeStatusAsync(string caseId, int statusTypeId)
    {
        var _case = await GetAsync(caseId);
        _case.StatusTypeId = statusTypeId;

        await _context.SaveChangesAsync();
    }
}
}