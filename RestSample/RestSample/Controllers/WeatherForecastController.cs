using System.Data.Common;
using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Mvc;

namespace RestSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IDocumentCollection<User> _user;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            var store = new DataStore("db.json");
            _user = store.GetCollection<User>();   
        }

        [HttpPost]
        public void Post([FromBody] User user) {
            _user.InsertOne(user);
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _user.AsQueryable().ToList();
        }

        [HttpGet("{id:int}")]
        public User GeById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _user.AsQueryable().FirstOrDefault(user => user.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}

public class User{
    public int Id{get; set; }
    public required string Name{get; set; }
}
