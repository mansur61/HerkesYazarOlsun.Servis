using HerkesYazarOlsun.Model.ViewModel;
using HerkesYazarOlsun.Model;
using Microsoft.AspNetCore.Http;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IFtpService
    {
        byte[] GetDosya(string filePath);
        Task<ServiceResponse<VM_File_Result>> Upload(IFormFile file, bool isProfile = false, bool isBookPage = false);
        string SaveDosyaByteOnIslem(string url, byte[] fileContents, bool isProfile = false, bool isBookPage = false);
        string SaveDosyaByte(string url, byte[] fileContents, string dizin);
        string CreateFtpDirectory(string directory);
        bool CheckIfDirectoryExists(string localFile);
        bool MakeDirectory(string localFile);
        Task DeleteDosyaByte(string dosyaYolu);
        long GetFileSize(string dosyaYolu);
        string AppendDosya(string url, byte[] fileContents);
        void UploadLargeFileFtp(string url);
        Stream GetPartialFileStream(string filePath, long start, long length);
    }
}
