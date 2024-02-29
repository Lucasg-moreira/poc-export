using Microsoft.EntityFrameworkCore;

namespace poc_export.Entities
{
    public class User
    {
        public User() {
            IsDeleted = false;
            CreatedAt = DateTime.UtcNow;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate{ get; set; }
        public DateTime CreatedAt { get; }
        public bool IsDeleted { get; set; }
    }
}
