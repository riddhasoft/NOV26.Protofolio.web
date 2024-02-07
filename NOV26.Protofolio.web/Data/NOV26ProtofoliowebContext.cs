using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NOV26.Protofolio.web.Models;

namespace NOV26.Protofolio.web.Data
{
    public class NOV26ProtofoliowebContext : DbContext
    {
        public NOV26ProtofoliowebContext(DbContextOptions<NOV26ProtofoliowebContext> options)
            : base(options)
        {
        }

        public DbSet<NOV26.Protofolio.web.Models.PersonalInformationModel> PersonalInformationModel { get; set; } = default!;

        public DbSet<NOV26.Protofolio.web.Models.ResumeModel>? ResumeModel { get; set; }

        public DbSet<NOV26.Protofolio.web.Models.ServiceModel>? ServiceModel { get; set; }

        public DbSet<NOV26.Protofolio.web.Models.SkillModel>? SkillModel { get; set; }

        public DbSet<NOV26.Protofolio.web.Models.ProjectModel>? ProjectModel { get; set; }

        public DbSet<NOV26.Protofolio.web.Models.BlogModel>? BlogModel { get; set; }
        public DbSet<NOV26.Protofolio.web.Models.BlogCommentModel>? BlogCommentModel { get; set; }
        public DbSet<NOV26.Protofolio.web.Models.UserModel>? UserModel { get; set; }

    }
}
