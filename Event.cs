using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211Lab6
{
    internal class Event
    {
        public string EventNumber {  get; set; } //Stored as string since no math will be performed on an ID number
        public string Location { get; set; }

        public Event(string EventNumber, string Location)
        {
            this.EventNumber = EventNumber;
            this.Location = Location;
        }

        public Event()
        {
            this.EventNumber = "0";
            this.Location = "Unknown";
        }

        public override string ToString()
        {
            return $"Event number {EventNumber} takes place in {Location}.";
        }
    }
}
