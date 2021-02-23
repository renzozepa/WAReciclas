namespace WAReciclas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string NOMBRE { get; set; }

        [Column("USUARIO")]
        [StringLength(255)]
        public string USUARIO1 { get; set; }

        [StringLength(255)]
        public string CLAVE { get; set; }

        [StringLength(255)]
        public string DIRECCION { get; set; }

        [StringLength(25)]
        public string LATITUD { get; set; }

        [StringLength(25)]
        public string LONGITUD { get; set; }

        public int? ID_PERFIL { get; set; }

        [StringLength(255)]
        public string TOKEN { get; set; }

        public DateTime? FECHA_REGISTRO { get; set; }

        public int? ALTA { get; set; }

        public DateTime? FECHA_ALTA { get; set; }

        public string CELULAR { get; set; }
        public string ZIPCODE { get; set; }
    }
}
