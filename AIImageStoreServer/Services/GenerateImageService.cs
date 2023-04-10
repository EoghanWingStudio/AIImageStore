using AIImageStoreServer.Interface;
using AIImageStoreServer.Repositories;
using Microsoft.Extensions.Options;

namespace AIImageStoreServer.Services
{
    public interface IGenerateImageService
    {
        Task<byte[]> GenerateImage(string description);
    }
    public class GenerateImageService : IGenerateImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly AppSettings _appSettings;
        GenerateImageService(ImageRepository imageRepositorty, IOptionsMonitor<AppSettings> appSettings)
        {
            _imageRepository= imageRepositorty;
            _appSettings = appSettings.CurrentValue;
        }

        public async Task<byte[]> GenerateImage(string description)
        {
            var apiKey = _appSettings.OpenAIKey;
            var url = $"https://api.openai.com/v1/images/generations?model=image-alpha-001&prompt={description}&api_key={apiKey}";

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, null);
                var image = await response.Content.ReadAsByteArrayAsync();
                
                return image;
            }
        }
    }
}

