using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace NOV26.Protofolio.web.Models
{
    public class ProjectModel
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 2-10
        /// 4-8
        /// 6-6
        /// 12
        /// 
        /// </summary>
        public int Width { get; set; }
        public string Title { get; set; }
        public string ClientName { get; set; }
        [ValidateNever]
        public string ProjectImageUrl { get; set; }
        public int ServiceId { get; set; }
        [ValidateNever]
        public virtual ServiceModel Service { get; set; }
    }
}
