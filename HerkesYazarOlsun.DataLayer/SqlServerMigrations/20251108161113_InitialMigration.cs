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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Favoriler",
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
                    table.PrimaryKey("PK_Favoriler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FavoriYazarlar",
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
                    table.PrimaryKey("PK_FavoriYazarlar", x => x.ID);
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
                name: "Talepler",
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
                    table.PrimaryKey("PK_Talepler", x => x.ID);
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
                name: "CategoryYayinAyarlari",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToplamYildiz = table.Column<int>(type: "int", nullable: true),
                    ToplamBegeni = table.Column<int>(type: "int", nullable: true),
                    ToplamYorum = table.Column<int>(type: "int", nullable: true),
                    ToplamDegerlendirme = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryYayinAyarlari", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategoryYayinAyarlari_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "ID");
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
                    ONKAPAKFOTOPATH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ARKAKAPAKFOTOPATH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ARKAKAPAKYAZISI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TAMAMLANDIMI = table.Column<bool>(type: "bit", nullable: false),
                    YazarId = table.Column<long>(type: "bigint", nullable: true),
                    YAYINDAMI = table.Column<bool>(type: "bit", nullable: false),
                    CategoriId = table.Column<int>(type: "int", nullable: true),
                    BooksStarsId = table.Column<int>(type: "int", nullable: true),
                    FavoriBooksId = table.Column<int>(type: "int", nullable: true),
                    YayinAyarId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Books_Category_CategoriId",
                        column: x => x.CategoriId,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Users_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                    UserId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Profil_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID");
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
                    table.ForeignKey(
                        name: "FK_UsersDetails_Users_LoginUserId",
                        column: x => x.LoginUserId,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "WriterFollow",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: true),
                    YazarId = table.Column<long>(type: "bigint", nullable: true),
                    isFollow = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriterFollow", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WriterFollow_Users_LoginUserId",
                        column: x => x.LoginUserId,
                        principalTable: "Users",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WriterFollow_Users_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "WriterStars",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarPuani = table.Column<int>(type: "int", nullable: false),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: true),
                    YazarId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriterStars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WriterStars_Users_LoginUserId",
                        column: x => x.LoginUserId,
                        principalTable: "Users",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_WriterStars_Users_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Users",
                        principalColumn: "ID");
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
                    BookId = table.Column<long>(type: "bigint", nullable: true),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: false),
                    StarPuani = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_BooksComment_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                    BookId = table.Column<long>(type: "bigint", nullable: true),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: false),
                    StarPuani = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksDegerlendirme", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BooksDegerlendirme_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                    BookId = table.Column<long>(type: "bigint", nullable: false),
                    BooksID = table.Column<long>(type: "bigint", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_BooksPages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BooksPages_Books_BooksID",
                        column: x => x.BooksID,
                        principalTable: "Books",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BooksStars",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarPuani = table.Column<int>(type: "int", nullable: false),
                    LoginUserId = table.Column<long>(type: "bigint", nullable: false),
                    BookId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksStars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BooksStars_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksStars_Users_LoginUserId",
                        column: x => x.LoginUserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriBooks",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_FavoriBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FavoriBooks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "YayinAyarlari",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToplamYildiz = table.Column<int>(type: "int", nullable: true),
                    ToplamBegeni = table.Column<int>(type: "int", nullable: true),
                    ToplamYorum = table.Column<int>(type: "int", nullable: true),
                    ToplamDegerlendirme = table.Column<int>(type: "int", nullable: true),
                    BookId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayinAyarlari", x => x.ID);
                    table.ForeignKey(
                        name: "FK_YayinAyarlari_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoriId",
                table: "Books",
                column: "CategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_YazarId",
                table: "Books",
                column: "YazarId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksComment_BookId",
                table: "BooksComment",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksDegerlendirme_BookId",
                table: "BooksDegerlendirme",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksPages_BookId",
                table: "BooksPages",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksPages_BooksID",
                table: "BooksPages",
                column: "BooksID");

            migrationBuilder.CreateIndex(
                name: "IX_BooksStars_BookId",
                table: "BooksStars",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksStars_LoginUserId",
                table: "BooksStars",
                column: "LoginUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryYayinAyarlari_CategoryId",
                table: "CategoryYayinAyarlari",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriBooks_BookId",
                table: "FavoriBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriBooks_UserId",
                table: "FavoriBooks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Profil_UserId",
                table: "Profil",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDetails_LoginUserId",
                table: "UsersDetails",
                column: "LoginUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WriterFollow_LoginUserId",
                table: "WriterFollow",
                column: "LoginUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WriterFollow_YazarId",
                table: "WriterFollow",
                column: "YazarId");

            migrationBuilder.CreateIndex(
                name: "IX_WriterStars_LoginUserId",
                table: "WriterStars",
                column: "LoginUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WriterStars_YazarId",
                table: "WriterStars",
                column: "YazarId");

            migrationBuilder.CreateIndex(
                name: "IX_YayinAyarlari_BookId",
                table: "YayinAyarlari",
                column: "BookId",
                unique: true,
                filter: "[BookId] IS NOT NULL");
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
                name: "CategoryYayinAyarlari");

            migrationBuilder.DropTable(
                name: "FavoriBooks");

            migrationBuilder.DropTable(
                name: "Favoriler");

            migrationBuilder.DropTable(
                name: "FavoriYazarlar");

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
                name: "Talepler");

            migrationBuilder.DropTable(
                name: "UsersDetails");

            migrationBuilder.DropTable(
                name: "WriterFollow");

            migrationBuilder.DropTable(
                name: "WriterStars");

            migrationBuilder.DropTable(
                name: "YayinAyarlari");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
