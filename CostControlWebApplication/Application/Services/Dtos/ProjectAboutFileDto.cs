namespace CostControlWebApplication.Application.Services.Dtos
{
    public class ProjectAboutFileDto : IDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long FileEntryId { get; set; }
        public string FileName { get; set; }

        public string FileSize { get; set; }

        public string CreatedDate { get; set; }
        public string Created { get; set; }
    }
}
