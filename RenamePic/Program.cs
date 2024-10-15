using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string directoryPath = @"C:\path\to\your\folder";  // المسار الذي يحتوي على الملفات المضغوطة

        // البحث عن جميع الملفات المضغوطة داخل المسار
        var zipFiles = Directory.GetFiles(directoryPath, "*.zip");

        if (zipFiles.Length == 0)
        {
            Console.WriteLine("لم يتم العثور على أي ملفات مضغوطة في المسار المحدد.");
            return;
        }
        int x;

        string s = "add for test";
        string s2 = "add for test";
        string s3 = "add for test";

        foreach (var zipFilePath in zipFiles)
        {
            string extractPath = Path.Combine(Path.GetDirectoryName(zipFilePath), "ExtractedFiles_" + Path.GetFileNameWithoutExtension(zipFilePath));  // مجلد مؤقت للاستخراج
            string destinationFolder = Path.GetDirectoryName(zipFilePath);  // مكان حفظ الصورة النهائية

            // فك ضغط الملف إلى المجلد المؤقت
            ZipFile.ExtractToDirectory(zipFilePath, extractPath);

            // البحث عن مجلد باسم _Render Pics أو اسم قريب
            string targetFolder = Directory.GetDirectories(extractPath)
                .FirstOrDefault(d => Path.GetFileName(d).Contains("_Render Pics", StringComparison.OrdinalIgnoreCase));

            if (targetFolder == null)
            {
                Console.WriteLine($"لم يتم العثور على مجلد _Render Pics داخل {zipFilePath}.");
                continue;  // الانتقال إلى الملف المضغوط التالي
            }

            // البحث عن الصورة ذات الحجم الأكبر داخل المجلد
            var largestImage = new DirectoryInfo(targetFolder).GetFiles()
                .OrderByDescending(f => f.Length)
                .FirstOrDefault();

            if (largestImage == null)
            {
                Console.WriteLine($"لم يتم العثور على صور داخل المجلد {targetFolder}.");
                continue;  // الانتقال إلى الملف المضغوط التالي
            }

            // إعادة تسمية الصورة ونقلها إلى نفس مكان الملف المضغوط
            string newFileName = Path.Combine(destinationFolder, Path.GetFileNameWithoutExtension(zipFilePath) + largestImage.Extension);
            File.Copy(largestImage.FullName, newFileName, true);

            Console.WriteLine($"تم نسخ الصورة: {largestImage.Name} من {zipFilePath} إلى {newFileName}");
        }
    }
}
