namespace WAReciclas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HORARIO_DISPONIBLE
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string DESCRIPCION { get; set; }
    }
}