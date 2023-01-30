using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualStudioBl.Model
{
    public class Screens
    {
        public int ScreensId { get; set; }

        public int? MainComputerId { get; set; }

        public virtual MainComputer MainComputer { get; set; }

        public int ComputerId { get; set; }

        public virtual Computer Computer { get; set; }
    }
}
