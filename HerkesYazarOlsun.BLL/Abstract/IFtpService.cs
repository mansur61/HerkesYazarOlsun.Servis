namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IFtpService
    {
        byte[] GetDosya(string filePath);
        string SaveDosyaByte(string url, byte[] fileContents, string dizin);
        string SaveDosyaByte(string url, byte[] fileContents);
        string CreateFtpDirectory(string directory);
        bool CheckIfDirectoryExists(string localFile);
        bool MakeDirectory(string localFile);
        void DeleteDosyaByte(string dosyaYolu);
        long GetFileSize(string dosyaYolu);
        string AppendDosya(string url, byte[] fileContents);
        void UploadLargeFileFtp(string url);
        Stream GetPartialFileStream(string filePath, long start, long length);
    }
}
