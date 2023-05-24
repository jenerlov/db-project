using dbproject.Models.Forms;
using dbproject.Contexts;
using dbproject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace dbproject.Services

{
    internal class CaseService
    {
        private readonly DataContext _context;
        private readonly UserService _userService;


        public CaseService(DataContext context, UserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<CaseEntity> CreateAsync(CaseRegForm form)
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
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task <CaseEntity?> GetAsync(string caseId)
        {
            return await _context.Cases
                .Include(x => x.User)
                .Include(x => x.Status)
                .Include(x => x.Comments)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CaseId == caseId);
        }
    }
}