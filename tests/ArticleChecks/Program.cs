using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Servis.Controllers;
using HerkesYazarOlsun.Servis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Security.Claims;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Font;

int checks = 0;
void Check(bool value, string name) { if (!value) throw new Exception(name); checks++; Console.WriteLine("PASS " + name); }
using var word = new MemoryStream();
using (var document = WordprocessingDocument.Create(word, WordprocessingDocumentType.Document, true))
{
    var main = document.AddMainDocumentPart();
    main.Document = new Document(new Body(new Paragraph(new Run(new Text("Türkçe makale: ğüşiöç"))), new Paragraph(new Run(new Text("İkinci paragraf")))));
    main.Document.Save();
}
word.Position = 0;
var text = MakaleDocumentReader.Read(word, ".docx");
Check(text.Contains("Türkçe makale: ğüşiöç") && text.Contains("\n\nİkinci paragraf"), "Word text and paragraphs");
MemoryStream MakePdf(string content)
{
    var objects = new[] { "<< /Type /Catalog /Pages 2 0 R >>", "<< /Type /Pages /Kids [3 0 R] /Count 1 >>",
        "<< /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Resources << /Font << /F1 4 0 R >> >> /Contents 5 0 R >>",
        "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>", $"<< /Length {content.Length} >>\nstream\n{content}\nendstream" };
    var result = new System.Text.StringBuilder("%PDF-1.4\n");
    var offsets = new List<int>();
    for (int i = 0; i < objects.Length; i++) { offsets.Add(result.Length); result.Append($"{i + 1} 0 obj\n{objects[i]}\nendobj\n"); }
    int xref = result.Length;
    result.Append("xref\n0 6\n0000000000 65535 f \n");
    foreach (var offset in offsets) result.Append($"{offset:D10} 00000 n \n");
    result.Append($"trailer\n<< /Size 6 /Root 1 0 R >>\nstartxref\n{xref}\n%%EOF");
    return new MemoryStream(System.Text.Encoding.ASCII.GetBytes(result.ToString()));
}
using var pdf = MakePdf("BT /F1 12 Tf 40 700 Td (Article PDF text) Tj ET");
pdf.Position = 0;
Check(MakaleDocumentReader.Read(pdf, ".pdf") == "", "PDF preserved without lossy text extraction");
foreach (var extension in new[] { ".pdf", ".docx" })
{
    bool rejected = false;
    try { MakaleDocumentReader.Read(new MemoryStream([1, 2, 3]), extension); }
    catch (InvalidDataException) { rejected = true; }
    Check(rejected, "Reject malformed " + extension);
}
using var emptyPdf = MakePdf("");
emptyPdf.Position = 0;
Check(MakaleDocumentReader.Read(emptyPdf, ".pdf") == "", "Accept valid PDF without selectable text");
using var db = new SqlServerContext(new DbContextOptionsBuilder<SqlServerContext>().UseSqlServer("Server=localhost;Database=unused;Trusted_Connection=True;TrustServerCertificate=True").Options);
var controller = new MakalelerController(new MakalelerService(db)) { ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() } };
Check((await controller.List(page: 0)).Result is BadRequestResult, "Reject invalid pagination");
Check((await controller.List(author: 1, drafts: true)).Result is ForbidResult, "Anonymous cannot list drafts");
controller.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity([new Claim("user_id", "2")], "test"));
Check((await controller.List(author: 1, drafts: true)).Result is ForbidResult, "Other author cannot list drafts");
var entity = db.Model.FindEntityType(typeof(Makale))!;
Check(entity.GetIndexes().Any(i => i.Properties.Select(p => p.Name).SequenceEqual(new[] { "YazarId", "YayinTarihi", "Id" })), "Author listing has index");
Check(entity.GetForeignKeys().Any(f => f.PrincipalEntityType.ClrType == typeof(Users)), "Author foreign key");
Check(db.Model.FindEntityType(typeof(MakaleBelge))!.GetForeignKeys().Single().DeleteBehavior == DeleteBehavior.Cascade, "Document linked to article");
foreach (var migration in new Microsoft.EntityFrameworkCore.Migrations.Migration[] {
    new HerkesYazarOlsun.DataLayer.SqlServerMigrations.AddMakaleler(),
    new HerkesYazarOlsun.DataLayer.Migrations.AddMakaleler() })
{
    Check(migration.UpOperations.Count == 4 && migration.UpOperations.All(x => x is CreateTableOperation or CreateIndexOperation), "Migration only adds article tables/indexes: " + migration.GetType().Namespace);
}
var originalDirectory = Directory.GetCurrentDirectory();
var serviceDirectory = HerkesYazarOlsun.DataLayer.ConnectionConncet.ServiceSettingsDirectory();
try
{
    var repo = Directory.GetParent(serviceDirectory)!.FullName;
    foreach (var location in new[] { repo, serviceDirectory, Path.Combine(repo, "HerkesYazarOlsun.DataLayer") })
    {
        Directory.SetCurrentDirectory(location);
        Check(HerkesYazarOlsun.DataLayer.ConnectionConncet.ServiceSettingsDirectory() == serviceDirectory, "EF uses service settings from " + Path.GetFileName(location));
    }
}
finally { Directory.SetCurrentDirectory(originalDirectory); }
Check(HerkesYazarOlsun.Portal.Helpers.BookPagination.Total(34) == 38, "Reader total includes four extra pages");
Check(HerkesYazarOlsun.Portal.Helpers.BookPagination.Next(34) == 39, "Continue writing is reader total plus one");
Console.WriteLine($"{checks} checks passed.");
