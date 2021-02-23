namespace WAReciclas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERFIL")]
    public partial class PERFIL
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string DESCRIPCION { get; set; }
    }
}
