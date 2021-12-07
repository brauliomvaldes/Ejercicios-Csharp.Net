using System;
using System.Collections.Generic;

#nullable disable

namespace GUIDProyect
{
    public partial class SaleConcept
    {
        public int Conceptid { get; set; }
        public Guid Saleid { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
