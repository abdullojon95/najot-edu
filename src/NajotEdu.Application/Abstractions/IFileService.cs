﻿using Microsoft.AspNetCore.Http;

namespace NajotEdu.Application.Abstractions
{
    public interface IFileService
    {
        Task<string> Upload(IFormFile formFile);
    }
}
