namespace OrbisaAsp.Data.Services
{
    public interface IImageService
    {
        Task<List<string>> UploadImagesAsync(
            List<IFormFile> images, string id
        );
    }
}
