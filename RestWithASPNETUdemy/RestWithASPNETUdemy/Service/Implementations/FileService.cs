﻿using Microsoft.AspNetCore.Http;
using RestWithASPNETUdemy.Data.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Service.Implementations
{
    public class FileService : IFileService
    {
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public FileService(IHttpContextAccessor context)
        { 
            _context = context;
            _basePath = Directory.GetCurrentDirectory() + "/UploadDir/"; //Change Directory path to match your OS notation
        }

        public byte[] GetFile(string filename)
        {
            var filePath = _basePath + filename;
            return File.ReadAllBytes(filePath);
        }

        public async Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> files)
        {
            List<FileDetailVO> list = new List<FileDetailVO>();
            foreach (var file in files)
            {
                list.Add(await SaveFileToDisk(file));
            }
            return list;
        }

        public async Task<FileDetailVO> SaveFileToDisk(IFormFile file)
        {
            FileDetailVO fileDetail = new FileDetailVO();

            var fileType = Path.GetExtension(file.FileName);
            var baseUrl = _context.HttpContext.Request.Host;

            if(fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" || 
               fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg")
            {
                var docName = Path.GetFileName(file.FileName);
                if (file != null && file.Length > 0)
                {
                    var destination = Path.Combine(_basePath, "", docName);
                    fileDetail.DocumentName = docName;
                    fileDetail.DocumentType = fileType;
                    fileDetail.DocumentUrl = Path.Combine(baseUrl + "/api/file/v1/" + fileDetail.DocumentName);

                    using var stream = new FileStream(destination, FileMode.Create);
                    await file.CopyToAsync(stream);
                }
            }
            return fileDetail;
        }
    }
}
