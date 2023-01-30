using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualStudioBl.Model
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public int? MainComputerId { get; set; }

        public virtual MainComputer MainComputer { get; set; }

        public string Text { get; set; }

        public int ComputerId { get; set; }

        public virtual Computer Computer { get; set; }


    }
}
