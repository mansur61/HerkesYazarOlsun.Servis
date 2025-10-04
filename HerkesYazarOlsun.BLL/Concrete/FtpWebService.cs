using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Helper;
using HerkesYazarOlsun.Model;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Net;
using File = System.IO.File;
namespace HerkesYazarOlsun.BLL.Concrete
{

    public class FtpWebService : IFtpService
    {
        // FTP bilgileri
        private string _ftpUSer = "herkesya";
        private string _ftpPWD = "u%pS3=antm29Ne@2";
        private string _ftpServer = "77.245.159.121:21";
        private long _ftpPort = 21;

        private string _ftpPortType = "ftp://";
        public string _ftpServerPath;
        public string _ftpLocalTempPath = "";

        // Parametreli constructor
        public FtpWebService(string user, string pwd, string ip)
        {
            _ftpUSer = user;
            _ftpPWD = pwd;
            _ftpServer = ip;

            _ftpLocalTempPath = "C://Temp/";

            // FTP URL: IP + public_html
            _ftpServerPath = $"{_ftpPortType}{_ftpServer}/httpdocs/Belgeler/";//public_html
        }

        // Parametresiz constructor
        public FtpWebService()
        {
            _ftpLocalTempPath = "C://Temp/";
            _ftpServerPath = $"{_ftpPortType}{_ftpServer}/httpdocs/Belgeler/";//public_html
        }

        public async Task<ServiceResponse<VM_File_Result>> Upload(IFormFile file, bool isProfile = false)
        {
            var sonuc = new ServiceResponse<VM_File_Result>(null) { IsSuccess = true };

            try
            {
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    var bytes = ms.ToArray();
                    var fileName = file.FileName;
                    string extension = fileName.Split('.').Last();

                    var newFileName = Guid.NewGuid() + "." + extension;
                    string filePath = SaveDosyaByteOnIslem(newFileName, bytes, isProfile);

                    var uploadResult = new VM_File_Result
                    {
                        IsSuccess = true,
                        FileName = filePath
                    };

                    sonuc = new ServiceResponse<VM_File_Result>(uploadResult)
                    {
                        IsSuccess = true,
                        Message = "Dosya FTP'ye yüklendi"
                    };
                }
            }
            catch (Exception ex)
            {
                sonuc = new ServiceResponse<VM_File_Result>(new VM_File_Result
                {
                    IsSuccess = false,
                    FileName = "Dosya yükleme başarısız."
                })
                {
                    IsSuccess = false,
                    Message = ex.Message
                };

            }

            return sonuc;
        }
        public byte[] GetDosya(string filePath)
        {
            try
            {
                if (filePath != null)
                {
                    filePath = filePath.StartsWith("/") ? filePath.Substring(1) : filePath;
                    filePath = _ftpServerPath + filePath.Replace("//", "/");

                    var request = (FtpWebRequest)WebRequest.Create(filePath);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    request.UsePassive = false;

                    request.Credentials = new NetworkCredential(_ftpUSer, _ftpPWD);
                    using (var response = (FtpWebResponse)request.GetResponse())
                    using (var responseStream = response.GetResponseStream())
                    using (var memoryStream = new MemoryStream())
                    {
                        responseStream?.CopyTo(memoryStream);
                        return memoryStream.ToArray();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\FtpWebService.txt",
                    "GetDosya_" + filePath + "_____" + ex.Message + "_____" +
                    (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                return null;
            }
        }

        public long GetFileSize(string filePath)
        {
            try
            {
                filePath = filePath.StartsWith("/") ? filePath.Substring(1) : filePath;
                filePath = _ftpServerPath + filePath.Replace("//", "/");

                var request = (FtpWebRequest)WebRequest.Create(filePath);
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                request.Credentials = new NetworkCredential(_ftpUSer, _ftpPWD);
                request.UsePassive = false;
                request.Proxy = null;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                long size = response.ContentLength;
                response.Close();
                return size;
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\FtpWebService.txt",
                    "GetFileSize_" + filePath + "_____" + ex.Message + "_____" +
                    (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                if (ex.Message ==
                    "Uzak sunucu hata döndürdü: (550) Dosya kullanılamıyor (örneğin, dosya bulunamadı, erişim yok).")
                {
                    return 0;
                }

                return 0;
            }
        }

        public bool RenameFile(string url, string newUrl)
        {
            try
            {
                FtpWebRequest reqFTP = (FtpWebRequest)WebRequest.Create(_ftpServerPath + url);
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.Proxy = null;
                reqFTP.Credentials = new NetworkCredential(_ftpUSer, _ftpPWD);
                reqFTP.RenameTo = newUrl;

                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                if (response.StatusCode == FtpStatusCode.FileActionOK)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\FtpRenameFile.txt",
                    "RenameFile" + ex.Message + "_____" +
                    (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                return false;
            }
        }

        public long GetLocalFileSize(string filePath)
        {
            try
            {
                filePath = filePath.StartsWith("/") ? filePath.Substring(1) : filePath;
                filePath = _ftpLocalTempPath + filePath.Replace("//", "/");

                if (File.Exists(filePath))
                {
                    var info = new FileInfo(filePath);
                    long size = info.Length;
                    return size;
                }

                return 0;
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\FtpWebService.txt",
                    "GetLocalFileSize" + filePath + "_____" + ex.Message + "_____" +
                    (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                return 0;
            }
        }


        public long GetArsivDocumentFileSize(string filePath)
        {
            if (filePath != null)
            {
                try
                {
                    filePath = filePath.StartsWith("/") ? filePath.Substring(1) : filePath;
                    filePath = _ftpServerPath + filePath.Replace("//", "/");

                    var request = (FtpWebRequest)WebRequest.Create(filePath);
                    request.Method = WebRequestMethods.Ftp.GetFileSize;
                    request.Credentials = new NetworkCredential(_ftpUSer, _ftpPWD);
                    request.Proxy = null;
                    request.UsePassive = false;

                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    long size = response.ContentLength;
                    response.Close();
                    return size;
                }
                catch (Exception ex)
                {
                    LogHelper.log("\\log\\FtpWebService.txt",
                        "GetFileSize_" + filePath + "_____" + ex.Message + "_____" +
                        (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                    if (ex.Message ==
                        "Uzak sunucu hata döndürdü: (550) Dosya kullanılamıyor (örneğin, dosya bulunamadı, erişim yok).")
                    {
                        return 0;
                    }

                    return 0;
                }
            }

            return 0;
        }

        public List<string> GetListDirectory(string filePath = "BasPdf/")
        {
            try
            {
                filePath = _ftpServerPath + filePath;
                var request = (FtpWebRequest)WebRequest.Create(filePath);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(_ftpUSer, _ftpPWD);
                request.Proxy = null;
                request.UsePassive = false;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                List<string> directories = new List<string>();

                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    directories.Add(line);
                    line = streamReader.ReadLine();
                }

                streamReader.Close();

                return directories;
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\FtpWebService.txt",
                    "GetListDirectory_" + ex.Message + "_____" +
                    (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                return null;
            }
        }

        public string SaveDosyaByteOnIslem(string url, byte[] fileContents, bool isProfile = false)
        {
            string dizin = "";
            if (isProfile)
                dizin = $"/Profile/";
            else
                dizin = $"/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}/";

            return SaveDosyaByte(url, fileContents, dizin);
        }

        public string SaveDosyaByte(string url, byte[] fileContents, string dizin)
        {
            FtpWebRequest request;
            try
            {
                string ftpPath = CreateFtpDirectory(dizin) + url;
                if (ftpPath != "-1")
                {
                    ftpPath = ftpPath.StartsWith("/") ? ftpPath.Substring(1) : ftpPath;
                    ftpPath = ftpPath.Replace("//", "/");

                    request = (FtpWebRequest)WebRequest.Create(_ftpServerPath + ftpPath);

                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(_ftpUSer, _ftpPWD);
                    request.UseBinary = true;
                    request.UsePassive = true;

                    request.ContentLength = fileContents.Length;
                    //String status = (((FtpWebResponse)request.GetResponse()).StatusDescription);

                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(fileContents, 0, fileContents.Length);
                    }

                    using ((FtpWebResponse)request.GetResponse())
                    {
                        return ftpPath;
                    }
                }

                return "-1";
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\FtpWebService.txt",
                    "SaveDosyaByte_" + dizin + url + ex.Message + "_____" +
                    (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                return "-1";
            }
        }

        public void DeleteDosyaByte(string dosyaYolu)
        {
            FtpWebRequest request;
            try
            {
                dosyaYolu = dosyaYolu.StartsWith("/") ? dosyaYolu.Substring(1) : dosyaYolu;
                string ftpPath = _ftpServerPath + dosyaYolu.Replace("//", "/");
                request = (FtpWebRequest)WebRequest.Create(ftpPath);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(_ftpUSer, _ftpPWD);
                request.UseBinary = true;
                request.UsePassive = false;

                _ = (FtpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\FtpWebService.txt",
                    "DeleteDosyaByte_" + dosyaYolu + ex.Message + "_____" +
                    (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
            }
        }

        private static string FtpParseDirectory(string destFilePath)
        {
            try
            {
                return destFilePath.Substring(0, destFilePath.LastIndexOf("/"));
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\FtpWebService.txt",
                    "FtpParseDirectory_" + destFilePath + ex.Message + "_____" +
                    (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                return "-1";
            }
        }

        public string CreateFtpDirectory(string destFilePath)
        {
            try
            {
                string fullDir = FtpParseDirectory(destFilePath);
                if (fullDir != "-1")
                {
                    string[] dirs = fullDir.Split('/');
                    string curDir = "/";
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        string dir = dirs[i];
                        if (dir != null && dir.Length > 0)
                        {
                            try
                            {
                                curDir += dir + "/";
                                if (!CheckIfDirectoryExists(curDir))
                                    MakeDirectory(curDir);
                            }
                            catch (Exception)
                            {
                                return "-1";
                            }
                        }
                    }
                }

                return destFilePath;
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\FtpWebService.txt",
                    "CreateFtpDirectory_" + destFilePath + ex.Message + "_____" +
                    (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                return "-1";
            }
        }

        public bool CheckIfDirectoryExists(string localFile)
        {
            localFile = localFile.StartsWith("/") ? localFile.Substring(1) : localFile;
            var ftpPath = _ftpServerPath + localFile.Replace("//", "/");
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpPath);

            req.Credentials = new NetworkCredential(_ftpUSer, _ftpPWD);
            req.Method = WebRequestMethods.Ftp.ListDirectory;
            req.UsePassive = false;

            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\FtpWebService.txt",
                    "CheckIfDirectoryExists_" + localFile + ex.Message + "_____" +
                    (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                req.Abort();
                return false;
            }

            req.Abort();
            return true;
        }

        public bool MakeDirectory(string localFile)
        {
            localFile = localFile.StartsWith("/") ? localFile.Substring(1) : localFile;
            var ftpPath = _ftpServerPath + localFile.Replace("//", "/");
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpPath);
            req.Credentials = new NetworkCredential(_ftpUSer, _ftpPWD);
            req.Method = WebRequestMethods.Ftp.MakeDirectory;
            req.UsePassive = false;

            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\FtpWebService.txt",
                    "MakeDirectory_" + localFile + ex.Message + "_____" +
                    (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                req.Abort();
                return false;
            }

            req.Abort();
            return true;
        }

        public string AppendDosya(string url, byte[] fileContents)
        {
            try
            {
                if (!File.Exists(_ftpLocalTempPath + url))
                {
                    string dateFolder = $"/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}/";
                    url = dateFolder + Guid.NewGuid() + GetExtension(url);
                    string ekPath = CreateDirectoryLocal(url);
                    if (ekPath != "-1")
                    {
                        using (var fs = new FileStream(_ftpLocalTempPath + url, FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(fileContents, 0, fileContents.Length);
                            return url;
                        }
                    }
                }
                else
                {
                    using (FileStream fs = File.Open(_ftpLocalTempPath + url, FileMode.Append))
                    {
                        fs.Write(fileContents, 0, fileContents.Length);
                    }
                }

                return url;
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\MergeFiles.txt", url + ex.Message);
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                return "-1";
            }
        }

        public void UploadLargeFileFtp(string url)
        {
            try
            {
                string dizin = url.Substring(0, url.LastIndexOf('/') + 1);
                url = url.Substring(url.LastIndexOf('/') + 1);
                string ftpPath = CreateFtpDirectory(dizin) + url;
                ftpPath = ftpPath.StartsWith("/") ? ftpPath.Substring(1) : ftpPath;
                ftpPath = ftpPath.Replace("//", "/");


                var request = (FtpWebRequest)WebRequest.Create(_ftpServerPath + ftpPath);

                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(_ftpUSer, _ftpPWD);
                request.UseBinary = true;
                request.UsePassive = false;

                long localFileSize = 0;
                using (FileStream fileStream = File.OpenRead(_ftpLocalTempPath + dizin + url))
                {
                    localFileSize = fileStream.Length;
                    using (Stream reqStream = request.GetRequestStream())
                    {
                        long curFileStreamPos = 0;
                        long chunkSize = 256000;

                        while (curFileStreamPos < fileStream.Length)
                        {
                            if (fileStream.Length - curFileStreamPos < chunkSize)
                                chunkSize = fileStream.Length - curFileStreamPos;

                            byte[] buff = new byte[chunkSize];
                            fileStream.Read(buff, 0, buff.Length);
                            reqStream.Write(buff, 0, buff.Length);

                            curFileStreamPos += chunkSize;
                        }

                        reqStream.Close();
                    }

                    fileStream.Close();
                }

                if (GetFileSize(dizin + url) == localFileSize)
                {
                    DeleteDosyaLocal(dizin + url);
                    DeleteFolder(dizin);
                }
                else
                {
                    LogHelper.log("\\log\\LengthNotEqual.txt", dizin + url);
                }
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\LargeUpload.txt", url + ex.Message);
            }
        }

        private void DeleteFolder(string dizin)
        {
            Directory.Delete(_ftpLocalTempPath + dizin);
        }

        public string CreateDirectoryLocal(string destFilePath)
        {
            try
            {
                string fullDir = FtpParseDirectory(destFilePath);
                if (fullDir != "-1")
                {
                    string[] dirs = fullDir.Split('/');
                    string curDir = "/";
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        string dir = dirs[i];
                        if (dir != null && dir.Length > 0)
                        {
                            curDir += dir + "/";
                            if (!Directory.Exists(_ftpLocalTempPath + destFilePath))
                                MakeDirectoryLocal(curDir);
                        }
                    }
                }

                return destFilePath;
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\FtpWebService.txt",
                    "CreateDirectoryLocal_" + destFilePath + ex.Message + "_____" +
                    (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                return "-1";
            }
        }

        public bool MakeDirectoryLocal(string localFile)
        {
            if (!Directory.Exists(_ftpLocalTempPath + localFile))
            {
                Directory.CreateDirectory(_ftpLocalTempPath + localFile);
            }

            return true;
        }

        /// <summary>
        /// This method will return the Stream object 
        /// and we can download a large file
        /// </summary>
        /// <param name="fileNameWithPath"></param>
        /// <returns></returns>
        public async Task<Stream> DownloadLargeFile(string ekPath)
        {
            ekPath = ekPath.StartsWith("/") ? ekPath.Substring(1) : ekPath;
            ekPath = ekPath.Replace("//", "/");

            return await Task.Run(() =>
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_ftpServerPath + ekPath);
                request.Credentials = new NetworkCredential(_ftpUSer, _ftpPWD);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.UsePassive = false;
                Stream reader = request.GetResponse().GetResponseStream();
                return reader;
            });
        }

        public string GetExtension(string fileName)
        {
            return "." + fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
        }

        private static void MergeFiles(string file1, string file2)
        {
            FileStream fs1 = null;
            FileStream fs2 = null;
            try
            {
                fs1 = File.Open(file1, FileMode.Append);
                fs2 = File.Open(file2, FileMode.Open);
                byte[] fs2Content = new byte[fs2.Length];
                fs2.Read(fs2Content, 0, (int)fs2.Length);
                fs1.Write(fs2Content, 0, (int)fs2.Length);
            }
            catch (Exception ex)
            {
                LogHelper.log("\\log\\MergeFiles.txt", ex.Message);
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
            }
            finally
            {
                if (fs1 != null) fs1.Close();
                if (fs2 != null) fs2.Close();
                File.Delete(file2);
            }
        }

        public void DeleteDosyaLocal(string dosyaYolu)
        {
            File.Delete(_ftpLocalTempPath + dosyaYolu);
        }


        public Stream GetPartialFileStream(string filePath, long start, long length)
        {
            var request = (FtpWebRequest)WebRequest.Create($"{_ftpServerPath}/{filePath}");
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(_ftpUSer, _ftpPWD);
            request.UseBinary = true;
            request.UsePassive = true; // Pasif mod
            request.Timeout = 30000; // Zaman aşımı
            request.ReadWriteTimeout = 30000;

            // Range destekliyorsa ContentOffset
            request.ContentOffset = start;

            try
            {
                var response = (FtpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();

                // Eğer belirli bir uzunlukta stream gerekiyorsa:
                return new LimitedStream(responseStream, length);
            }
            catch (WebException ex)
            {
                LogHelper.log("\\log\\FtpWebService.txt",
                    "GetPartialFileSystem" + ex.Message + "_____" +
                    (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                // Hata detaylarını logla
                throw new Exception($"FTP error: {ex.Message}", ex);
            }
        }
    }
}
