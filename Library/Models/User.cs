using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }


        public string Email { get; set; }
        public string Name { get; set; }

        //to many
        public virtual ICollection<Device> Devices { get; set; }

        public User()
        {
            Devices = new List<Device>();
        }
    }
}
