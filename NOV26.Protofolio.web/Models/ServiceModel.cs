using System.ComponentModel.DataAnnotations;

namespace NOV26.Protofolio.web.Models
{
    public class ServiceModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}
