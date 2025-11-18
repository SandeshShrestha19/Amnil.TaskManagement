using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scriban.Functions;
using Volo.Abp.Domain.Entities.Auditing;

namespace Amnil.TaskManagement.Entities
{
    public class User : AuditedAggregateRoot<Guid>
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        protected User() { }

        public User(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }

        public void Update(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
