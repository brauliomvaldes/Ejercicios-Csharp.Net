using System;
using System.Collections.Generic;

#nullable disable

namespace GUIDProyect
{
    public partial class Sale
    {
        public Sale()
        {
            SaleConcepts = new HashSet<SaleConcept>();
        }

        public Guid SaleId { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<SaleConcept> SaleConcepts { get; set; }
    }
}
