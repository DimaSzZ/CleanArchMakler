using CleanAdArch.Domain.Settings.Utils.File;

namespace CleanAdArch.Infrastructure.Utils.File;

public class FileUtils : IFileUtils
{
    public static readonly List<string> AllowedImageExtensions = new()
    {
        "jpg",
        "jpeg",
        "png",
        "gif",
        "bmp",
        "svg"
    };
    public string GetExtension(string name)
    {
        var indexPoint = name.IndexOf(".", StringComparison.Ordinal) + 1;
        return name[indexPoint..];
    }

    public bool IsImage(string filename)
    {
        var extension = GetExtension(filename);
        return !AllowedImageExtensions.Contains(extension);
    }
}