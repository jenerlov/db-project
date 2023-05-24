using dbproject.Contexts;
using dbproject.Models.Entities;
using dbproject.Models.Forms;
using Microsoft.EntityFrameworkCore;
namespace dbproject.Services;

internal class CommentService 
{
    private readonly DataContext _context = new DataContext();

    public async Task<CommentEntity> CreateAsync(string caseId, CommentForm form)
    {
        var commentEntity = new CommentEntity()
        {
            CaseId = caseId,
            Comment = form.Comment,
            Created = DateTime.Now,
        };

        _context.Add(commentEntity);
        await _context.SaveChangesAsync();

        return commentEntity;
    }

}