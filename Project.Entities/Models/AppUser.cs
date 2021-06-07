using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class AppUser:BaseEntity
    {
        public AppUser()
        {
            AppUserRole = AppUserRole.Member;
            ActivationCode = Guid.NewGuid();
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid ActivationCode { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }
        public AppUserRole AppUserRole { get; set; }

        //relational properites
        public virtual UserProfile UserProfile { get; set; }
    }
}
