using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualStudioBl.Model
{
    public class Coworker
    {
        public int CoworkerId { get; set; }

        public string Name { get; set;}

        public string Post { get; set; }

        public string Task { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Computer> Computer { get; set; }

        public virtual ICollection<MainComputer> MainComputers { get; set; }


     
    }
}
