using System;
using System.Collections.Generic;


namespace VirtualStudioBl.Model
{
    public class Computer
    {
        public int ComputerId { get; set; }
        
        public int CoworkerId { get; set; }

        public virtual Coworker Coworker { get; set; }

        public virtual ICollection<MainComputer> MainComputers { get; set; }

        public virtual ICollection<Streem> Streems { get; set; }

        public virtual ICollection<Screens> Screens { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

    }
}
