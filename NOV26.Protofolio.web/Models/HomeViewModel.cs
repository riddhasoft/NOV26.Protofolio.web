﻿namespace NOV26.Protofolio.web.Models
{
    public class HomeViewModel : PersonalInformationModel
    {
        public List<ResumeModel> Resumes { get; set; }
        public List<ServiceModel> Services { get; set; }
        public List<SkillModel> Skills { get; set; } = new List<SkillModel>();

        public List<ProjectModel> Projects { get; set; } = new List<ProjectModel>();
        public List<BlogModel> Blogs { get; set; } = new List<BlogModel>();
    }
}
