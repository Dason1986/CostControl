﻿using BingoX.Domain;
using System.ComponentModel;

namespace CostControlWebApplication.Domain
{
    public class ProjectAboutFile : FileEntry, ISnowflakeEntity<ProjectAboutFile>
    {
        public long ProjectId { get; set; }
        public long ForeignID { get; set; }
        public ProjectFileType FileType { get; set; }
    }
    public enum ProjectFileType
    {
        Temp = 0,
        [Description("立項文件")]
        Create =1,
        [Description("採購審批文件")]
        Procurement = 2,
        [Description("收入文件")]
        CostIn = 2,
        [Description("支出文件")]
        CostOut = 3,

        [Description("其它文件")]
        Other = 99,
    }
}
