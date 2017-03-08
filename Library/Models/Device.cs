using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Device
    {
        public int Id { get; set; }


        public string Guid { get; set; }
        //[StringLength(DbConfigurationValue.MinStingLenght)]
        //public string Name { get; set; }

        //public virtual ICollection<DeviceName> DeviceName { get; set; }


        public string Password { get; set; }

        public int BlockCategory { get; set; }

        public bool CanBeDelete { get; set; }

        //to many
        // public virtual ICollection<Program> Programs { get; set; }
        //public virtual ICollection<Program> Programs { get; set; } //virtual = lazyLoad

        //public int UserId { get; set; } 
        public virtual ICollection<User> Users { get; set; }


        public Device()
        {
            //BlockCategory = 0;
            //Programs = new List<Program>();
            Users = new List<User>();
            // DeviceName = new List<DeviceName>();
        }
    }
}
