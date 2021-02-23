namespace WAReciclas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RECOJO")]
    public partial class RECOJO
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string DESCRIPCION { get; set; }

        public int? ID_HORARIO { get; set; }
        [StringLength(255)]
        public string DIRECCION { get; set; }
        [StringLength(255)]
        public string TOKEN_RECOJO { get; set; }
        [StringLength(255)]
        public string TOKEN_USUARIO { get; set; }

        public DateTime? FECHA_TRANSACCION { get; set; }

        public int? ID_ESTADO { get; set; }
    }
}
