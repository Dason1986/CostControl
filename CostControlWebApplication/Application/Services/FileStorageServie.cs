using BingoX;
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
            this.boundedContext = boundedContext;
        }
        private readonly string rootPath;
        private readonly IBoundedContext boundedContext;
        public FileEntry AddFile(byte[] stream, string path)
        {
            var buffer = stream;
            var realPath = Path.Combine(rootPath, path);

            FileInfo fileInfo = new FileInfo(realPath);
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
            realPath = Path.Combine(fileInfo.Directory.FullName, boundedContext.Generator.New() + "_" + Path.GetFileName(path));
            File.WriteAllBytes(realPath, buffer);
            return new FileEntry { StoragePath = realPath, FileSize = buffer.Length, FileName = Path.GetFileName(path) };
        }
        public FileEntry AddFile(Stream stream, string path)
        {
            var buffer = stream.ToArray();
            var realPath = Path.Combine(rootPath, path);

            FileInfo fileInfo = new FileInfo(realPath);
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
            realPath = Path.Combine(fileInfo.Directory.FullName, boundedContext.Generator.New() + "_" + Path.GetFileName(path));
            File.WriteAllBytes(realPath, buffer);
            return new FileEntry { StoragePath = realPath, FileSize = buffer.Length, FileName = Path.GetFileName(path) };
        }

        public void Move(string path1, string path2)
        {
            try
            {


                FileInfo fileInfo1 = new FileInfo( path1);
                if (!fileInfo1.Exists) return;
                FileInfo fileInfo2 = new FileInfo(Path.Combine(rootPath, path2));
                if (!fileInfo2.Directory.Exists) fileInfo2.Directory.Create();
                fileInfo1.MoveTo(fileInfo2.FullName);
            }
            catch (Exception ex)
            {

                throw new LogicException("文件处理失败", ex);
            }
        }
    }
}
