using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace NOV26.Protofolio.web.Models
{
    public class BlogModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        public string Paragraph1 { get; set; }
        public string Paragraph2 { get; set; }
        [ValidateNever]
        public DateTime DateTime { get; set; } = DateTime.Now;
    }

    public class BlogViewModel : BlogModel
    {
        public List<BlogCommentModel> comments { get; set; }
    }

}
