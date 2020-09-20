using BingoX.AspNetCore;
using CostControlWebApplication.Domain;
using System;
using System.IO;

namespace CostControlWebApplication.Services
{
  

    public class FileStorageServie : IService
    {

        public FileStorageServie()
        {

        }
        private readonly string rootPath;
        public FileEntry AddProjectFile(string name, Stream stream, string filetype, string projectId)
        {
            return new FileEntry { ID = 111 };
        }

        public FileEntry AddTempFile(string name, Stream stream)
        {
            return new FileEntry { ID = 111, FileName = name, FileSize = stream.Length, CreatedDate = DateTime.Now };
        }

        public object AddTargetCostFile(string name, Stream stream, string targetId)
        {
            throw new System.NotImplementedException();
        }
    }
}
