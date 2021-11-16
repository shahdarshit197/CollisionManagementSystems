using CollisionManagementSystems.Model;
using CollisionManagementSystems.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Transactions;
using System.Linq;

namespace CollisionManagementSystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<UsersDTO>> GetUserses()
        {
            var users = _usersRepository.GetUsers().Select(a => new UsersDTO
            {
                Id = a.Id,
                username = a.username
            }).ToList();
            return new OkObjectResult(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<UsersDTO> GetUsers(int id)
        {
            var users = _usersRepository.GetUserByID(id);

            if (users == null)
            {
                return NotFound();
            }
            return new UsersDTO
            {
                Id = users.Id,
                username = users.username
            };
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutUsers(int id, Users users)
        {

            if (!UsersExists(id))
            {
                return NotFound();
            }
            using (var scope = new TransactionScope())
            {
                users.Id = id;
                _usersRepository.UpdatedUser(users);
                scope.Complete();
                return new OkResult();
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Users> PostUsers(Users users)
        {

            if (_usersRepository.GetUsers(users.username).Count() > 0)
            {
                ModelState.AddModelError("Error", "Duplicate usernames found");
                return BadRequest(ModelState);
            }
            using (var scope = new TransactionScope())
            {
                _usersRepository.InsertUsre(users);
                scope.Complete();
                return CreatedAtAction("GetUsers", new { id = users.Id }, users);
            }

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public ActionResult<Users> DeleteUsers(int id)
        {
            var users = _usersRepository.GetUserByID(id);
            if (users == null)
            {
                return NotFound();
            }
            _usersRepository.DeleteUser(users);
            return new OkResult();
        }

        private bool UsersExists(int id)
        {
            return _usersRepository.IsUsersExists(id);
        }
    }
}
