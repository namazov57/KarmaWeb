using Microsoft.AspNetCore.Http;

namespace Karma.Infrastructure.Services.Abstracts
{
    public interface IFileService
    {
        string Upload(IFormFile file);
        string ChangeFile(IFormFile file, string oldFileName, bool withoutArchive = false);
    }
}
