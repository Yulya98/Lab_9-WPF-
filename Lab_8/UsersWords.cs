using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab_8
{
    public class UsersWords
    {
        public int UserId { get; set; }
        public Users User { get; set; }

        public int WordId { get; set; }
        public Words Word { get; set; }

        public bool flag { get; set; }
    }
}
