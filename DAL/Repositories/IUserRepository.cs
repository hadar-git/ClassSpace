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
        Task<List<User>> GetUsersAsync();                   // כל המשתמשות
        Task<User> GetUserAsync(int id);                    // משתמשת לפי קוד
        Task<User> AddUserAsync(User user);                 // הוספה
        Task<User> UpdateUserAsync(User user);              // עדכון
        Task<bool> DeleteUserAsync(int id);                 // מחיקה לפי קוד ומחזיר האם נמחקה

        Task<User> GetUserByEmailAsync(string email);       // בשביל התחברות
        Task<List<User>> GetUsersByRoleAsync(Role role);    // רשימת כל המורות
    }
}