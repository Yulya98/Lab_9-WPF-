using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lab_8
{
    public class Words
    {
        [Key]
        public int WordId { get; set; }
        public string Word { get; set; }
        public string Translate { get; set; }
        public List<UsersWords> UsersWord { get; set; }
    }
}
