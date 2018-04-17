using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Description("用户名")]
        public string name { get; set; }

        [Description("用户年龄")]
        public int age { get; set; }
    }
}
