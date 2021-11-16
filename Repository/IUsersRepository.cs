using CollisionManagementSystems.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollisionManagementSystems.Repository
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetUsers(string UserName = "");
        Users GetUserByID(int UserID);
        void InsertUsre(Users user);
        void DeleteUser(Users user);
        void UpdatedUser(Users user);
        bool IsUsersExists(int UserID);
        void Save();
    }
}
