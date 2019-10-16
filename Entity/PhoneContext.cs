using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PhoneContext : DbContext
    {
        public PhoneContext() : base("myConnectionString")
        {
        }

        public DbSet<PhoneDetails> dbPhoneDetails { get; set; }
    }
}
