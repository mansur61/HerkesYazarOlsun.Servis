using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.BLL.Helper;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace HerkesYazarOlsun.Servis.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController : BaseApiController
{
    private IFtpService _ftpService;
    private readonly ILogger<FileController> _logger;
    private IUsersService userService;
    public FileController(ILogger<FileController> logger, IUsersService _userService, IFtpService ftpService,
            IUserAccessor userAccessor, IUnitOfWork unitOfWork, IHttpContextAccessor configuration)
           : base(userAccessor, unitOfWork, configuration)
    {
        _logger = logger;
        userService = _userService;
        _ftpService = ftpService;
    }


    [HttpPost]
    [Route("SingleUpload")]

    public IActionResult SingleUpload(string fileName,string dizin)
    {
        var result = new VM_File_Result();
        try
        {
            using (var ms = new MemoryStream())
            {
                Request.Body.CopyToAsync(ms);
                //Request.Body.CopyTo(ms);
                var bytes = ms.ToArray();
                string extension = fileName.Split('.').Last();

                var newFileName = Guid.NewGuid() + "." + extension;
                string filePath = _ftpService.SaveDosyaByte(newFileName, bytes, dizin);

                result.IsSuccess = true;
                result.FileName = filePath;

                _logger.LogInformation("Dosya başarıyla yüklendi. Orijinal Ad: {OriginalName}, Yeni Ad: {NewName}, Yol: {Path}",
                                   fileName, newFileName, filePath);
            }

        }
        catch (Exception ex)
        {
            //terminale yazar veya logları LogHelper da tuttarsın FtpWebService kullanım örnekleri var projede logları burda tutabiliriz.
            _logger.LogError(ex, "Dosya yükleme sırasında hata oluştu. Dosya adı: {FileName}", fileName);
            result.IsSuccess = false;
        }
        return Ok(result);

    }

    [HttpPost]
    [Route("SingleUploadFile")]
    public async Task<IActionResult> SingleUploadFile(IFormFile file,string dizin)
    {
        var result = new VM_File_Result();

        try
        {
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                var bytes = ms.ToArray();
                var fileName = file.FileName;
                string extension = fileName.Split('.').Last();

                var newFileName = Guid.NewGuid() + "." + extension;
                string filePath = _ftpService.SaveDosyaByte(newFileName, bytes, dizin);

                result.IsSuccess = true;
                result.FileName = filePath;

            }

        }
        catch (Exception ex)
        {
            result.IsSuccess = false;
        }

        return Ok(result);

    }


    [HttpPost]
    [Route("MultiUpload")]
    public IActionResult MultiUpload(string fileName, long id, long count)
    {
        var result = new VM_File_Result();
        if (fileName.Equals("-1"))
        {
            result.IsSuccess = false;
        }

        try
        {
            using (var ms = new MemoryStream())
            {
                Request.Body.CopyToAsync(ms);
                //Request.Body.CopyTo(ms);
                var bytes = ms.ToArray();
                fileName = _ftpService.AppendDosya(fileName, bytes);

                if (id == count && !fileName.Equals("-1"))
                {
                    _ftpService.UploadLargeFileFtp(fileName);
                }

                if (!fileName.Contains('/'))
                {
                    result.IsSuccess = false;
                }

                result.IsSuccess = true;
                result.FileName = fileName;
            }
        }
        catch (Exception ex)
        {
            result.IsSuccess = false;
        }
        return Ok(result);
    }

    [HttpGet("GetFile")]
    public async Task<IActionResult> GetFile(string filePath)
    {

        long start = 0;
        long end = 0;
        long totalLength = _ftpService.GetFileSize(filePath);

        // Range başlığını kontrol et
        if (Request.Headers.ContainsKey("Range"))
        {
            string rangeHeader = Request.Headers["Range"].ToString();
            string[] range = rangeHeader.Replace("bytes=", "").Split('-');

            if (!long.TryParse(range[0], out start))
            {
                return BadRequest("Invalid Range Start");
            }

            if (range.Length > 1 && !string.IsNullOrEmpty(range[1]))
            {
                if (!long.TryParse(range[1], out end))
                {
                    return BadRequest("Invalid Range End");
                }
            }
            else
            {
                end = totalLength - 1;
            }

            if (start > end || end >= totalLength)
            {
                return BadRequest("Invalid Range");
            }

            Response.StatusCode = StatusCodes.Status206PartialContent;
        }
        else
        {
            end = totalLength - 1;
            Response.StatusCode = StatusCodes.Status200OK;
        }

        long contentLength = end - start + 1;

        // FTP'den dosyanın istenen kısmını okuma
        var responseStream = _ftpService.GetPartialFileStream(filePath, start, contentLength);

        // Response Header'ları ayarlama
        Response.Headers.Add("Accept-Ranges", "bytes");
        Response.Headers.Add("Content-Range", $"bytes {start}-{end}/{totalLength}");
        Response.Headers.Add("Content-Length", contentLength.ToString());

        return File(responseStream, "video/mp4", enableRangeProcessing: false);
    }


    [HttpGet]
    [Route("GetFileBase64")]
    public async Task<IActionResult> GetFileBase64(string filePath)
    {

        byte[] applicationPDFData = _ftpService.GetDosya(filePath);
        if (applicationPDFData == null)
            return Ok(new VM_File_Result()
            {
                FileName = "",
                IsSuccess = false
            });

        var result = Convert.ToBase64String(applicationPDFData);
        var filePathSplit = filePath.Split('.').ToList();
        if (!string.IsNullOrEmpty(filePathSplit.Last()))
        {
            result = $"data:{FileUploadHelper.MimTypeGetir(filePathSplit.Last())};base64,{result}";
        }
        return Ok(new VM_File_Result()
        {
            FileName = result,
            IsSuccess = true
        });
    }


}