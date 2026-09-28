using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System.IO.Compression;
namespace HerkesYazarOlsun.Servis.Services;
public static class MakaleDocumentReader
{
    public static string Read(MemoryStream stream, string extension)
    {
        string text;
        try
        {
            if (extension == ".docx")
            {
                using (var zip = new ZipArchive(stream, ZipArchiveMode.Read, true))
                    if (zip.Entries.Sum(e => e.Length) > 50 * 1024 * 1024)
                        throw new InvalidDataException("Expanded document is too large.");
                stream.Position = 0;
                using var document = WordprocessingDocument.Open(stream, false);
                text = string.Join("\n\n", document.MainDocumentPart!.Document.Body!
                    .Descendants<Paragraph>().Select(p => p.InnerText));
            }
            else
            {
                using var reader = new PdfReader(stream);
                reader.SetCloseStream(false);
                using var document = new PdfDocument(reader);
                if (document.GetNumberOfPages() > 200) throw new InvalidDataException("Too many pages.");
                text = string.Join("\n\n", Enumerable.Range(1, document.GetNumberOfPages())
                    .Select(i => PdfTextExtractor.GetTextFromPage(document.GetPage(i))));
            }
            if (string.IsNullOrWhiteSpace(text) || text.Length > 1000000)
                throw new InvalidDataException("No readable text or text too long.");
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            throw new InvalidDataException("Dosya okunamadı. Metin içeren, şifresiz Word (.docx) veya PDF yükleyin. PDF en fazla 200 sayfa olabilir.", ex);
        }
        return text;
    }
}
