using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOV26.Protofolio.web.Models
{
    public class BlogCommentModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        [ValidateNever]
        public DateTime DateOfComment { get; set; } = DateTime.Now;
        [ForeignKey(nameof(Blog))]
        public int BlogId { get; set; }
        [ValidateNever]
        public virtual BlogModel Blog { get; set; }
    }
}
