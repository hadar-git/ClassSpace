using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ClassSpaceDB db;

        public UserRepository(ClassSpaceDB db)
        {
            this.db = db;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.UserID == id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            User user = await GetUserAsync(id);
            if (user == null)
                return false;
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetUsersByRoleAsync(Role role)
        {
            return await db.Users.Where(u => u.Role == role).ToListAsync();
        }
    }
}