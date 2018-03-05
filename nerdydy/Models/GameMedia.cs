namespace nerdydy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GameMedia")]
    public partial class GameMedia
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        public string Filepath { get; set; }

        public int MediaTypeId { get; set; }

        public int GameId { get; set; }
    }
}
