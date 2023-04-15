﻿using MyCmsWebApi2.Domain.Entities;

namespace MyCmsWebApi2.Applications.Repository
{
    public interface IImageRepository
    {
        Task<Images> GetImageByIdAsync(Guid id);
        Task<Images> InsertImageAsync(Images image);
        Task UpdateImageAsync(Images images);
        Task DeleteImageByIdAsync(Guid id);
        Task<bool> ImageExist(Guid id);
    }
}