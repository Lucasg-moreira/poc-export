using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using poc_export.Entities;
using poc_export.Persistence;
using System.Text;

namespace poc_export.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ReportDbContext _context;
        public UserController(ReportDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.User.Where(d => !d.IsDeleted).ToList();
            return Ok(users);
        }

        [HttpGet("report")]
        public IActionResult GetReport() 
        {
            try
            {
                var users = _context.User.Where(user => !user.IsDeleted).ToList();

                string dataString = string.Join(Environment.NewLine, users.Select(u => $"{u.Id}, {u.UserName}, {u.CreatedAt}"));

                byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);

                MemoryStream stream = new MemoryStream(dataBytes);

                return new FileStreamResult(stream, "text/plain")
                {
                    FileDownloadName = "output.txt"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _context.User.SingleOrDefault(d => d.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(Guid id, User input)
        //{
        //    var user = _context.Users.SingleOrDefault(d => d.Id == id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    user.Update(input.UserName);
        //    _context.Reports.Update(user);
        //    _context.SaveChanges();

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var user = _context.User.SingleOrDefault(item => item.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.Delete();
            _context.SaveChanges();

            return NoContent();
        }
    }


}

