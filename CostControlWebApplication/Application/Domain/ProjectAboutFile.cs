using BingoX.Domain;

namespace CostControlWebApplication.Domain
{
    public class ProjectAboutFile : FileEntry, ISnowflakeEntity<ProjectAboutFile>
    {
        public long ProjectId { get; set; }

        public long FileTypeId { get; set; }
    }
}
