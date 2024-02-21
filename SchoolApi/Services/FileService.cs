using SchoolApi.Exceptions;

namespace SchoolApi.Services;

public class FileService
{
    private const string Url = "wwwroot";

    private static void CheckDirectory(string folder)
    {
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);
    }


    public static async Task<string> SaveFile(IFormFile file)
    {
        return await SaveFile(file, "Photos");
    }

    private static async Task<string> SaveFile(IFormFile file, string folder)
    {
        CheckDirectory(Path.Combine(Url, folder));
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        await File.WriteAllBytesAsync(Path.Combine(Url, folder, fileName), ms.ToArray());
        return $"{Url}/{folder}/{fileName}";
    }
}