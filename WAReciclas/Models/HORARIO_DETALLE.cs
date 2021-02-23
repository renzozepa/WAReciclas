namespace WAReciclas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HORARIO_DETALLE
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_HORARIO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string DESCRIPCION { get; set; }

        [StringLength(5)]
        public string HORA_INICIO { get; set; }

        [StringLength(5)]
        public string HORA_FIN { get; set; }
    }
}
