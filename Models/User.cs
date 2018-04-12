using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class User
    {
        [Key]
        public Guid ID { get; set; }

        public string name { get; set; }

        public int age { get; set; }
    }
}
