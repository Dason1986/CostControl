using BingoX.Domain;
using System;

namespace CostControlWebApplication.Domain
{
    public class FileEntry : Entity, ISnowflakeEntity<FileEntry> 
    {
       

        public string FileName { get; set; }

        public long FileSize { get; set; }

        public string StoragePath { get; set; }
     
    }
}
