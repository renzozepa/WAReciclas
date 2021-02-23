namespace WAReciclas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HORARIO")]
    public partial class HORARIO
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string DESCRIPCION { get; set; }

        public DateTime? FECHA { get; set; }

        public string DEPARTAMENTO { get; set; }

        public string PROVINCIA { get; set; }

        public string DISTRITO { get; set; }


    }
}
