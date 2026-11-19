using DAL.Data;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ClassSpaceDB db;

        public UserRepository(ClassSpaceDB db)
        {
            this.db = db;
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public User GetUser(int id)
        {
            return db.Users.FirstOrDefault(u => u.UserID == id);
        }

        public User AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();   
            return user;
        }

        public User UpdateUser(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
            return user;
        }

        public bool DeleteUser(int id)
        {
            User user = GetUser(id);
            if (user == null)
                return false;
            db.Users.Remove(user);
            db.SaveChanges();
            return true;
        }

        public User GetUserByEmail(string email)
        {
            return db.Users.FirstOrDefault(u => u.Email == email);
        }

        public List<User> GetUsersByRole(Role role)
        {
            return db.Users.Where(u => u.Role == role).ToList();
        }
    }
}
