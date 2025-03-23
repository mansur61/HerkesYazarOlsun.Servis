using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HerkesYazarOlsun.DataLayer.SqlServerMigrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountLogin",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: false),
                    RememberLogin = table.Column<bool>(type: "bit", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    benihatirla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPersistent = table.Column<bool>(type: "bit", nullable: true),
                    ExpiresUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllowRefresh = table.Column<bool>(type: "bit", nullable: true),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountLogin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ayarlar",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDegisiklik = table.Column<int>(type: "int", nullable: true),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: false),
                    UserDetailID = table.Column<long>(type: "bigint", nullable: false),
                    ProfileID = table.Column<long>(type: "bigint", nullable: false),
                    BildirimID = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayarlar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bildirimler",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsTakip = table.Column<bool>(type: "bit", nullable: false),
                    IsKitapYayin = table.Column<bool>(type: "bit", nullable: false),
                    IsKitapYorum = table.Column<bool>(type: "bit", nullable: false),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: true),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bildirimler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ONSOZ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ONKAPAKFOTO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ARKAKAPAKFOTO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ARKAKAPAKYAZISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TAMAMLANDIMI = table.Column<bool>(type: "bit", nullable: false),
                    YazarId = table.Column<long>(type: "bigint", nullable: false),
                    YAYINDAMI = table.Column<bool>(type: "bit", nullable: false),
                    CategoriId = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BooksComment",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<long>(type: "bigint", nullable: false),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksComment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BooksDegerlendirme",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KONU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACIKLAMA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<long>(type: "bigint", nullable: false),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: false),
                    StarPuani = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksDegerlendirme", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BooksPages",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageWrite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageWriteBase64 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BooksId = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksPages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BooksStars",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarPuani = table.Column<int>(type: "int", nullable: false),
                    LoginUserId = table.Column<int>(type: "int", nullable: false),
                    BookaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksStars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarouselDuyuru",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ICERIK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ICERIK_TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RENK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselDuyuru", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FAVORI_YAZARLAR",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginUserId = table.Column<int>(type: "int", nullable: false),
                    YazarId = table.Column<int>(type: "int", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAVORI_YAZARLAR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FAVORILER",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOOKS_ID = table.Column<long>(type: "bigint", nullable: false),
                    USER_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAVORILER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FavoriBooks",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BOOKS_ID = table.Column<long>(type: "bigint", nullable: false),
                    USER_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriBooks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kartlar",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cvv = table.Column<long>(type: "bigint", nullable: false),
                    KartUzerindekiIsim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KartTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KartTarihiAy = table.Column<int>(type: "int", nullable: false),
                    KartTarihiYil = table.Column<int>(type: "int", nullable: false),
                    KartNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdemeId = table.Column<long>(type: "bigint", nullable: false),
                    Tutar = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kartlar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Odeme",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapId = table.Column<long>(type: "bigint", nullable: false),
                    isOdeme = table.Column<bool>(type: "bit", nullable: false),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odeme", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OdemeSponsorlari",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapId = table.Column<long>(type: "bigint", nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<long>(type: "bigint", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SponsorId = table.Column<long>(type: "bigint", nullable: false),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdemeSponsorlari", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profil",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilResimURl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilResimBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilResimName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: true),
                    ProfilArkaplanResmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilArkaplanRenkKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profil", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sponsorlar",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SponsorAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ICON = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsorlar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TALEPLER",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADISOYADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KONU_ID = table.Column<int>(type: "int", nullable: true),
                    KONU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TARIHI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MESAJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TALEPLER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TELNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isEmail = table.Column<int>(type: "int", nullable: false),
                    isTelno = table.Column<int>(type: "int", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isSozlesmeOnay = table.Column<int>(type: "int", nullable: true),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsersDetails",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HAKKINDA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TEL = table.Column<long>(type: "bigint", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: true),
                    CREATE_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_CREATED_ID = table.Column<long>(type: "bigint", nullable: true),
                    OLUSTURAN_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_MODIFIED = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_MODIFIED_ID = table.Column<long>(type: "bigint", nullable: true),
                    USER_MODIFIED_MAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_DELETED = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WriterFollow",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginUserId = table.Column<int>(type: "int", nullable: false),
                    YazarId = table.Column<int>(type: "int", nullable: false),
                    isFollow = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriterFollow", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WriterStars",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarPuani = table.Column<int>(type: "int", nullable: false),
                    LoginUserId = table.Column<int>(type: "int", nullable: false),
                    YazarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriterStars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "YayinAyarlari",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToplamYildiz = table.Column<int>(type: "int", nullable: true),
                    ToplamBegeni = table.Column<int>(type: "int", nullable: true),
                    ToplamYorum = table.Column<int>(type: "int", nullable: true),
                    ToplamDegerlendirme = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayinAyarlari", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountLogin");

            migrationBuilder.DropTable(
                name: "Ayarlar");

            migrationBuilder.DropTable(
                name: "Bildirimler");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BooksComment");

            migrationBuilder.DropTable(
                name: "BooksDegerlendirme");

            migrationBuilder.DropTable(
                name: "BooksPages");

            migrationBuilder.DropTable(
                name: "BooksStars");

            migrationBuilder.DropTable(
                name: "CarouselDuyuru");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "FAVORI_YAZARLAR");

            migrationBuilder.DropTable(
                name: "FAVORILER");

            migrationBuilder.DropTable(
                name: "FavoriBooks");

            migrationBuilder.DropTable(
                name: "Kartlar");

            migrationBuilder.DropTable(
                name: "Odeme");

            migrationBuilder.DropTable(
                name: "OdemeSponsorlari");

            migrationBuilder.DropTable(
                name: "Profil");

            migrationBuilder.DropTable(
                name: "Sponsorlar");

            migrationBuilder.DropTable(
                name: "TALEPLER");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UsersDetails");

            migrationBuilder.DropTable(
                name: "WriterFollow");

            migrationBuilder.DropTable(
                name: "WriterStars");

            migrationBuilder.DropTable(
                name: "YayinAyarlari");
        }
    }
}
