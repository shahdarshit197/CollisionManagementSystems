using CollisionManagementSystems.Db;
using CollisionManagementSystems.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollisionManagementSystems.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CMSContext _context;
        public UsersRepository(CMSContext context)
        {
            _context = context;
        }
        public void DeleteUser(Users user)
        {
            _context.Userses.Remove(user);
            Save();
        }
        public Users GetUserByID(int UserID)
        {
            return _context.Userses.Find(UserID);
        }
        public IEnumerable<Users> GetUsers(string UserName = "")
        {
            var qurey = _context.Userses;
            if (!string.IsNullOrEmpty(UserName))
            {
                return qurey.Where(a => a.username.Equals(UserName)).ToList();
            }
            return qurey.ToList();
        }
        public void InsertUsre(Users user)
        {
            _context.Userses.Add(user);
            Save();
        }
        public bool IsUsersExists(int UserID)
        {
            return _context.Userses.Any(e => e.Id == UserID);
        }
        public void UpdatedUser(Users user)
        {
            _context.Entry(user).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
