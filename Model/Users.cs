using System.Text.Json.Serialization;

namespace CollisionManagementSystems.Model
{
    public class Users
    {
        [JsonIgnore]
        /// <summary>The unique identifier</summary>
        public int Id { get; set; }
        /// <summary>User Name</summary>
        public string username { get; set; }
    }
    public class UsersDTO
    {
        /// <summary>The unique identifier</summary>
        public int Id { get; set; }
        public string username { get; set; }
    }
}
