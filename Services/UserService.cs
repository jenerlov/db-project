using dbproject.Contexts;
using dbproject.Models.Entities;
using dbproject.Models.Forms;
using Microsoft.EntityFrameworkCore;


namespace dbproject.Services
{

internal class UserService
{
    private readonly DataContext _context = new DataContext();

    public async Task<UserEntity> GetOrCreateIfNotExistAsync(CaseRegForm form){

        var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Email == form.Email);
        if (userEntity == null)
        {
            userEntity = new UserEntity()
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                PhoneNumber = form.PhoneNumber
            };
            _context.Add(userEntity);
            await _context.SaveChangesAsync();
        }
        return userEntity;
    }
}
}