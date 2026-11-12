using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;

namespace DAL.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();                   // כל המשתמשות
        User GetUser(int id);                    // משתמשת לפי קוד
        User AddUser(User user);                 // הוספה
        User UpdateUser(User user);              // עדכון
        bool DeleteUser(int id);                 // מחיקה לפי קוד ומחזיר האם נמחקה

        User GetUserByEmail(string email);       // בשביל התחברות
        List<User> GetUsersByRole(Role role);    // רשימת כל המורות
    }
}
