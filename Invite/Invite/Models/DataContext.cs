using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Invite.Models
{
        using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Invite.Models.BestFriends> BestFriends { get; set; }
    }
}
