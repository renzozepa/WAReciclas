namespace WAReciclas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RECOJO_DETALLE
    {
        [Key]
        [StringLength(255)]
        public string TOKEN_RECOJO_DETALLE { get; set; }

        public int? ID_RECOJO { get; set; }

        public int? LINEA { get; set; }

        [StringLength(255)]
        public string DESCRIPCION { get; set; }

        public decimal? CANTIDAD { get; set; }

        public decimal? PESO { get; set; }

        public DateTime? FECHA_RECOJO { get; set; }

        public int? ID_ESTADO { get; set; }
    }
}
