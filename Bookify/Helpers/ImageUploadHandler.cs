namespace Bookify.Helpers;

public static class ImageUploadHandler
{
    public static string UploadImage(IFormFile image, IWebHostEnvironment hostEnvironment)
    {
        string uniqueFileName = null;
        var uploadFolder = Path.Combine(hostEnvironment.WebRootPath, "img");
        uniqueFileName = Guid.NewGuid() + "_" + Path.GetFileName(image.FileName);;
        var filePath = Path.Combine(uploadFolder,uniqueFileName);
        var fileStream = new FileStream(filePath, FileMode.Create);
        image.CopyTo(fileStream);
        fileStream.Close();
        return uniqueFileName;
    }
}