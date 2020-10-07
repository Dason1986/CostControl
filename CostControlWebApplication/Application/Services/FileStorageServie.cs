using BingoX.AspNetCore;
using BingoX.Helper;
using BingoX.Repository;
using CostControlWebApplication.Application.Data;
using CostControlWebApplication.Domain;
using System;
using System.IO;

namespace CostControlWebApplication.Services
{


    public class FileStorageServie : IService
    {

        public FileStorageServie(IBoundedContext boundedContext)
        {
            rootPath = Path.Combine(boundedContext.ContentRootPath, "FileStorage");
        }
        private readonly string rootPath;
        public FileEntry AddFile(Stream stream, string path)
        {
            var buffer = stream.ToArray();
            var realPath = Path.Combine(rootPath, path);
            FileInfo fileInfo = new FileInfo(realPath);
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
            File.WriteAllBytes(realPath, buffer);
            return new FileEntry { StoragePath = realPath, FileSize = buffer.Length, FileName = Path.GetFileName(path) };
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
