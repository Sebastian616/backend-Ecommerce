using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace OrbisaAsp.Data.Services
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary _cloudinary;

        public ImageService()
        {
            var cloudName =
                Environment.GetEnvironmentVariable(
                    "CLOUDINARY_CLOUD_NAME"
                );

            var apiKey =
                Environment.GetEnvironmentVariable(
                    "CLOUDINARY_API_KEY"
                );

            var apiSecret =
                Environment.GetEnvironmentVariable(
                    "CLOUDINARY_API_SECRET"
                );

            if (string.IsNullOrWhiteSpace(cloudName) ||
                string.IsNullOrWhiteSpace(apiKey) ||
                string.IsNullOrWhiteSpace(apiSecret))
            {
                throw new Exception(
                    "Las credenciales de Cloudinary no están configuradas."
                );
            }

            var account = new Account(
                cloudName,
                apiKey,
                apiSecret
            );

            _cloudinary = new Cloudinary(account);

            _cloudinary.Api.Secure = true;
        }

        public async Task<List<string>> UploadImagesAsync(
            List<IFormFile> images, string id)
        {
            var imageUrls = new List<string>();

            foreach (var image in images)
            {
                //Validaciones
                if (image == null || image.Length == 0)
                    continue;
                var extension =
                Path.GetExtension(image.FileName)
                    .ToLowerInvariant();

                if (!AllowedExtensions.Contains(extension))
                {
                    throw new ArgumentException(
                        $"Formato de imagen no permitido: {extension}"
                    );
                }
                const long MaxFileSize = 5 * 1024 * 1024;

                if (image.Length > MaxFileSize)
                {
                    throw new ArgumentException(
                        $"La imagen {image.FileName} supera los 5 MB."
                    );
                }

                //Ahora sí, subir
                await using var stream =
                    image.OpenReadStream();

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(
                        image.FileName,
                        stream
                    ),

                    Folder = $"orbisa/productos_Orbisa/{id}"
                };

                var result =
                    await _cloudinary.UploadAsync(
                        uploadParams
                    );

                if (result.Error != null)
                {
                    throw new Exception(
                        $"Error subiendo imagen a Cloudinary: " +
                        result.Error.Message
                    );
                }

                imageUrls.Add(result.SecureUrl.ToString());
            }

            return imageUrls;
        }

        private static readonly string[] AllowedExtensions =
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".webp"
        };
    }
}