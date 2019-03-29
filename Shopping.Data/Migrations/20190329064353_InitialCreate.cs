using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    SubTitle = table.Column<string>(maxLength: 200, nullable: false),
                    Html = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Style = table.Column<string>(nullable: true),
                    ButtonText = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AccessToken = table.Column<string>(nullable: true),
                    RefreshToken = table.Column<string>(nullable: true),
                    Pic = table.Column<string>(nullable: true),
                    Fullname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Slug = table.Column<string>(maxLength: 200, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    ShowInHome = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Value = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    OriginalName = table.Column<string>(maxLength: 200, nullable: false),
                    Alt = table.Column<string>(maxLength: 4000, nullable: false),
                    Category = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 200, nullable: false),
                    Extension = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    NativeName = table.Column<string>(maxLength: 200, nullable: false),
                    Flag = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Slug = table.Column<string>(maxLength: 200, nullable: false),
                    Body = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(maxLength: 200, nullable: false),
                    CustomHtml = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    MetaTitle = table.Column<string>(maxLength: 200, nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Slug = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(maxLength: 200, nullable: true),
                    ParentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCategories_PostCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Slug = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(maxLength: 200, nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Slug = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(maxLength: 200, nullable: true),
                    ParentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Url = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Slug = table.Column<string>(maxLength: 200, nullable: false),
                    Owner = table.Column<string>(maxLength: 200, nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(maxLength: 200, nullable: false),
                    ContactPhone = table.Column<string>(maxLength: 200, nullable: false),
                    ContactEmail = table.Column<string>(maxLength: 200, nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CountryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostPostCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    PostId = table.Column<string>(nullable: true),
                    PostCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostPostCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostPostCategories_PostCategories_PostCategoryId",
                        column: x => x.PostCategoryId,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostPostCategories_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Text = table.Column<string>(maxLength: 200, nullable: false),
                    Url = table.Column<string>(maxLength: 200, nullable: false),
                    Style = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(maxLength: 200, nullable: false),
                    Position = table.Column<int>(nullable: false),
                    SliderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slides_Sliders_SliderId",
                        column: x => x.SliderId,
                        principalTable: "Sliders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Slug = table.Column<string>(maxLength: 200, nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false),
                    IsOnSale = table.Column<bool>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 4000, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    NewPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Currency = table.Column<int>(nullable: false),
                    Tax = table.Column<float>(nullable: false),
                    RatingsCount = table.Column<int>(nullable: false),
                    RatingsValue = table.Column<float>(nullable: false),
                    AvailabilityCount = table.Column<int>(nullable: false),
                    Condition = table.Column<int>(nullable: false),
                    Weight = table.Column<float>(nullable: true),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(maxLength: 200, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 500, nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    BrandId = table.Column<string>(nullable: true),
                    StoreId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreBrands",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    StoreId = table.Column<string>(nullable: true),
                    BrandId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreBrands_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreBrands_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    ColorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductColors_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPhotos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Medium = table.Column<string>(maxLength: 200, nullable: false),
                    Small = table.Column<string>(maxLength: 200, nullable: false),
                    Large = table.Column<string>(maxLength: 200, nullable: false),
                    Alt = table.Column<string>(maxLength: 4000, nullable: false),
                    Position = table.Column<int>(nullable: false),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPhotos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    QuestionCategoryId = table.Column<string>(nullable: true),
                    StoreId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: false),
                    ShareDate = table.Column<DateTime>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductQuestions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductQuestions_QuestionCategories_QuestionCategoryId",
                        column: x => x.QuestionCategoryId,
                        principalTable: "QuestionCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductQuestions_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Body = table.Column<string>(maxLength: 4000, nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    ApprovedBy = table.Column<string>(nullable: true),
                    ApprovedAt = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Company = table.Column<string>(maxLength: 200, nullable: true),
                    CityId = table.Column<string>(nullable: true),
                    CountryId = table.Column<string>(nullable: true),
                    DistrictId = table.Column<string>(nullable: true),
                    AddressDescription = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    InvoiceType = table.Column<int>(nullable: false),
                    IdentityNumber = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    DemandDate = table.Column<DateTime>(nullable: false),
                    OrderCode = table.Column<string>(maxLength: 50, nullable: false),
                    DeliveryAddressId = table.Column<string>(nullable: true),
                    InvoiceAddressId = table.Column<string>(nullable: true),
                    StoreId = table.Column<string>(nullable: true),
                    OrderStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_InvoiceAddressId",
                        column: x => x.InvoiceAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    CouponNo = table.Column<string>(nullable: true),
                    CouponNumber = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    OrderId = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ForStoreId = table.Column<string>(nullable: true),
                    MinTotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Conditions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_Stores_ForStoreId",
                        column: x => x.ForStoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coupons_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    OrderId = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    BrandId = table.Column<string>(nullable: true),
                    StoreId = table.Column<string>(nullable: true),
                    ShipperId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 500, nullable: false),
                    NewPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AvailabilityCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Shippers_ShipperId",
                        column: x => x.ShipperId,
                        principalTable: "Shippers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "ButtonText", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "Html", "Image", "IpAddress", "IsActive", "IsDeleted", "Location", "Style", "SubTitle", "Title", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { "06edb6a0-30d0-498c-a380-45561360b347", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "notebook", "macBookAir.jpg", null, false, false, "0", "", "%30 İndirimlerle", "Yeni Notebooklar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "f2fb95c1-2c3d-4c80-914d-56fa25aabd03", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yeni telefonlar", "yenitelefon.jpg", null, false, false, "1", "", "2018 Model", "Yeni Cep Telefonlar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "2ac117b2-466b-4cd5-abf8-1843e40ef53e", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yeni saatler", "yenisaatler.jpg", null, false, false, "2", "", "2018 Model", "Yeni Saatler", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "43f5f97e-c1ed-46b4-8f2b-76461b96244f", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yeni Gözlük", "yenigunesgozluk.jpg", null, false, false, "3", "", "2018 Model", "Yeni Güneş Gözlükleri", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "ab7eb932-7930-401a-9414-a598fc0b71f2", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yeni Ayakkabılar", "yeniayakkabi.jpg", null, false, false, "4", "", "2018 Model", "Yeni Model Ayakkabılar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null },
                    { "e1e2c415-1b92-4325-b826-25ffad381878", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Yeni Takılar", "yenitakilar.jpg", null, false, false, "5", "", "2018 Model", "Yeni Model Takılar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "Image", "IpAddress", "IsActive", "IsDeleted", "Name", "ShowInHome", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "be084f87-b383-4939-a1db-97c9d16ce295", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3871), "username", null, null, null, "acer.jpg", null, true, false, "Acer", false, "acer", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3871), "username" },
                    { "d228e627-feb9-4208-9a10-b3ac8dc866fa", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3858), "username", null, null, null, "sony.jpg", null, true, false, "Sony", false, "sony", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3858), "username" },
                    { "109057a8-d4c0-40c5-bede-a238dcdf0245", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3849), "username", null, null, null, "asus.jpg", null, true, false, "Asus", false, "asus", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3854), "username" },
                    { "45ee14ef-d408-47e3-b104-01a9e23c5def", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3785), "username", null, null, null, "samsung1.jpg", null, true, false, "Samsung", false, "samsung", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3785), "username" },
                    { "ff23d5c6-d2b6-4687-a715-299ee0c5dd25", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3867), "username", null, null, null, "huawei.jpg", null, true, false, "Huawei", false, "huawei", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3867), "username" },
                    { "6d85aacb-8f1b-4488-b5bd-5390b9cd76c6", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3773), "username", null, null, null, "hp1.jpg", null, true, false, "Hp", false, "hp", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3773), "username" },
                    { "f3bf46ec-4135-4f13-b874-b6d0fea16ada", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3760), "username", null, null, null, "dell.jpg", null, true, false, "Dell", false, "dell", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3764), "username" },
                    { "e8840d39-abf2-4577-bfa5-a92144107b09", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3319), "username", null, null, null, "apple1.jpg", null, true, false, "Apple", false, "apple", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3328), "username" },
                    { "c047e1e6-01d1-47d9-8087-ad1b3400ad0e", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3781), "username", null, null, null, "lenovo1.jpg", null, true, false, "Lenovo", false, "lenovo", new DateTime(2019, 3, 29, 9, 43, 52, 244, DateTimeKind.Local).AddTicks(3781), "username" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "IpAddress", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "820b84fc-a4e0-4f56-a34f-e752287d7e52", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Turkey", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "f356f493-c46a-48d2-8908-64deeb51e92f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Germany", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "Description", "IpAddress", "IsActive", "IsDeleted", "Name", "ParentId", "Photo", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "2d53d8ef-0f19-42ed-9126-e03a0a1af060", new DateTime(2019, 3, 29, 9, 43, 52, 238, DateTimeKind.Local).AddTicks(3888), "username", null, null, null, null, null, true, false, "Tüm Kategoriler", null, null, "tum-kategoriler", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(2031), "username" });

            migrationBuilder.InsertData(
                table: "QuestionCategories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "IpAddress", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "c91699f8-0688-4bf5-926d-9f445191a97e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Kargo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Shippers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "IpAddress", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { "a54ae47b-f94b-4bf8-ab1c-fffabd092012", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Aras Kargo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://www.araskargo.com" },
                    { "dc20a22d-51d7-439c-9898-1015954cdbbd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Yurtiçi Kargo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://www.yurticikargo.com" },
                    { "8a8f0d2c-cc86-4d11-98d8-eb30847859a7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Sürat Kargo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://www.suratkargo.com" },
                    { "5a240eef-d844-4341-811e-3b2377920a5d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "MNG Kargo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "http://www.mngkargo.com" }
                });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "IpAddress", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "b5616904-9304-40ab-9488-5d4809021445", new DateTime(2019, 3, 29, 9, 43, 52, 240, DateTimeKind.Local).AddTicks(5814), "username", null, null, null, null, true, false, "Ana Kaydırıcı", new DateTime(2019, 3, 29, 9, 43, 52, 240, DateTimeKind.Local).AddTicks(5823), "username" },
                    { "d1689024-2cff-420d-a2aa-141e93cbbff7", new DateTime(2019, 3, 29, 9, 43, 52, 240, DateTimeKind.Local).AddTicks(6186), "username", null, null, null, null, true, false, "Orta Kaydırıcı", new DateTime(2019, 3, 29, 9, 43, 52, 240, DateTimeKind.Local).AddTicks(6186), "username" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "ContactEmail", "ContactName", "ContactPhone", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "Description", "IpAddress", "IsActive", "IsDeleted", "Logo", "Name", "Owner", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "5b843cf0-b7a5-475f-b22e-57054c54ba14", "Yeşilpınar Mah. Girne Cad. No:14 Daire:12", "karmaillegal57@gmail.com", "Emir Demirci", "05301564531", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "", null, false, false, "appstore1.jpg", "AppStore1", "emirdemirci721@gmail.com", "http://www.hepsiburada.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "6ad3fd8a-9b43-440d-bd83-fcf033101d9d", "Üsküdar", "emir.dmrc57@gmail.com", "Murat Demirci", "05395675645", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "", null, false, false, "vatan.jpg", "Vatan Bilgisayar", "mdemirci01@outlook.com", "http://www.vatanbilgisayar.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "f544e6dd-70c7-4c99-834e-8147e1bff9f1", "Eyüp", "edmrc57@gmail.com", "Yasin Demirci", "05678954567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Teknosa Herkes İçin Teknoloji", null, false, false, "teknosa.jpg", "Teknosa", "karmaillegal57@gmail.com", "http://www.teknosa.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "IpAddress", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "ce87fa38-6bb9-4f9d-9c7c-b2ca767106ba", "820b84fc-a4e0-4f56-a34f-e752287d7e52", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Istanbul", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "7c51c498-8047-4665-bec9-48283eb8de8e", "f356f493-c46a-48d2-8908-64deeb51e92f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Berlin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "Description", "IpAddress", "IsActive", "IsDeleted", "Name", "ParentId", "Photo", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "6d8135c2-833f-42fc-900d-6eeeb1c607b6", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7552), "username", null, null, null, null, null, true, false, "Elektronics", "2d53d8ef-0f19-42ed-9126-e03a0a1af060", null, "elektronics", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7556), "username" },
                    { "6d8135c2-833f-42fc-900d-6eeeb1c607b9", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7548), "username", null, null, null, null, null, true, false, "Computers", "2d53d8ef-0f19-42ed-9126-e03a0a1af060", null, "computers", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7548), "username" },
                    { "6d8135c2-833f-42fc-900d-6eeeb1c607b7", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7535), "username", null, null, null, null, null, true, false, "Beauty & Personal Care", "2d53d8ef-0f19-42ed-9126-e03a0a1af060", null, "beauty-personal-care", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7535), "username" },
                    { "6d8135c2-833f-42fc-900d-6eeeb1c607b0", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7531), "username", null, null, null, null, null, true, false, "Baby", "2d53d8ef-0f19-42ed-9126-e03a0a1af060", null, "baby", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7531), "username" },
                    { "6d8135c2-833f-42fc-900d-6eeeb1c607b8", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7539), "username", null, null, null, null, null, true, false, "Books", "2d53d8ef-0f19-42ed-9126-e03a0a1af060", null, "books", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7543), "username" },
                    { "6d8135c2-833f-42fc-900d-6eeeb1c607b4", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7509), "username", null, null, null, null, null, true, false, "Arts & Crafts", "2d53d8ef-0f19-42ed-9126-e03a0a1af060", null, "arts-crafts", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7509), "username" },
                    { "6d8135c2-833f-42fc-900d-6eeeb1c607b3", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7445), "username", null, null, null, null, null, true, false, "Kindle Store", "2d53d8ef-0f19-42ed-9126-e03a0a1af060", null, "kindle-store", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7445), "username" },
                    { "6d8135c2-833f-42fc-900d-6eeeb1c607b2", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7407), "username", null, null, null, null, null, true, false, "Music, CDs & Vinyl", "2d53d8ef-0f19-42ed-9126-e03a0a1af060", null, "music-cds-vinly", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7411), "username" },
                    { "6d8135c2-833f-42fc-900d-6eeeb1c607b1", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7107), "username", null, null, null, null, null, true, false, "Prime Video", "2d53d8ef-0f19-42ed-9126-e03a0a1af060", null, "prime-video", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7124), "username" },
                    { "6d8135c2-833f-42fc-900d-6eeeb1c607b5", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7522), "username", null, null, null, null, null, true, false, "Automotive", "2d53d8ef-0f19-42ed-9126-e03a0a1af060", null, "automotive", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7526), "username" }
                });

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "IpAddress", "IsActive", "IsDeleted", "Name", "Photo", "Position", "SliderId", "Style", "Text", "Title", "UpdatedAt", "UpdatedBy", "Url" },
                values: new object[,]
                {
                    { "007f78d2-f4d5-413a-9a80-737bc6850d5d", new DateTime(2019, 3, 29, 9, 43, 52, 242, DateTimeKind.Local).AddTicks(778), "username", null, null, null, null, true, false, "Kampanyalı Ürünlerimiz", "waterandmountains.jpg", 0, "b5616904-9304-40ab-9488-5d4809021445", null, "Çeşit Çeşit Paketlerdeki Orjinal Hediyeler", "Hediye Paketli Ürünlerimiz", new DateTime(2019, 3, 29, 9, 43, 52, 242, DateTimeKind.Local).AddTicks(791), "username", "http://www.google.com.tr" },
                    { "3a64713c-22b6-48ff-8d84-740dcefdbd37", new DateTime(2019, 3, 29, 9, 43, 52, 242, DateTimeKind.Local).AddTicks(1193), "username", null, null, null, null, true, false, "Yurt Dışından Gelen Ürünler", "yurtdış.jpg", 0, "b5616904-9304-40ab-9488-5d4809021445", null, "Bütün Avrupa ve Asya'daki ülkelerdeki ürünler", "Kaliteli ve Uygun Fiyatlarla", new DateTime(2019, 3, 29, 9, 43, 52, 242, DateTimeKind.Local).AddTicks(1193), "username", "http://www.apple.com.tr" },
                    { "0c0d6d02-c99a-4537-9821-f2c90f21f451", new DateTime(2019, 3, 29, 9, 43, 52, 242, DateTimeKind.Local).AddTicks(1206), "username", null, null, null, null, true, false, "Düğün Paketlerimiz", "aile.jpg", 0, "b5616904-9304-40ab-9488-5d4809021445", null, "Bütün Markaların Ürünleri Vitrinlerimizde", "Her Türlü Ev Eşyaları Uygun Fiyatlarla", new DateTime(2019, 3, 29, 9, 43, 52, 242, DateTimeKind.Local).AddTicks(1206), "username", "http://www.evkur.com.tr" },
                    { "cc3fc344-2141-40c5-be49-3b9c661d56b2", new DateTime(2019, 3, 29, 9, 43, 52, 242, DateTimeKind.Local).AddTicks(1214), "username", null, null, null, null, true, false, "İndirimli Apple Ürünleri", "appleur.jpg", 0, "b5616904-9304-40ab-9488-5d4809021445", null, "Bütün Elektronik Cihazlar Vitrinlerimizde", "%40 İndirim ile Vitrinlerimizde", new DateTime(2019, 3, 29, 9, 43, 52, 242, DateTimeKind.Local).AddTicks(1214), "username", "http://www.apple.com.tr" },
                    { "072df9fd-ef97-40f4-a10e-5b0e7dc3f08c", new DateTime(2019, 3, 29, 9, 43, 52, 242, DateTimeKind.Local).AddTicks(1219), "username", null, null, null, null, true, false, "2019 Model MacBook Air", "MacBookAir2019.jpg", 0, "b5616904-9304-40ab-9488-5d4809021445", null, "Kaçırmayın", "Şubat 2019'da Vitrinlerimizde", new DateTime(2019, 3, 29, 9, 43, 52, 242, DateTimeKind.Local).AddTicks(1219), "username", "http://www.apple.com.tr" }
                });

            migrationBuilder.InsertData(
                table: "StoreBrands",
                columns: new[] { "Id", "BrandId", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "IpAddress", "IsActive", "IsDeleted", "StoreId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "ad83d190-64b9-4828-aded-af481dbc8934", "e8840d39-abf2-4577-bfa5-a92144107b09", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "5b843cf0-b7a5-475f-b22e-57054c54ba14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "86dcccf4-3481-4e07-8ec9-0bcbbd90b1ad", "45ee14ef-d408-47e3-b104-01a9e23c5def", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "6ad3fd8a-9b43-440d-bd83-fcf033101d9d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "ecc78fd7-fafc-4969-be4f-193ed1f84532", "6d85aacb-8f1b-4488-b5bd-5390b9cd76c6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "f544e6dd-70c7-4c99-834e-8147e1bff9f1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "IpAddress", "IsActive", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "5c8d78df-6a68-4d2a-abe9-bc5638d91fa3", "ce87fa38-6bb9-4f9d-9c7c-b2ca767106ba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Üsküdar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "6c438a90-833a-48a1-9c4e-bda2820abcbe", "7c51c498-8047-4665-bec9-48283eb8de8e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Mitte", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "Description", "IpAddress", "IsActive", "IsDeleted", "Name", "ParentId", "Photo", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "42729bdd-3160-41f8-b1a6-c68ead8e314d", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7560), "username", null, null, null, null, null, true, false, "Bilgisayar", "6d8135c2-833f-42fc-900d-6eeeb1c607b6", null, "bilgisayar", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7560), "username" },
                    { "4b64df99-8909-4fb4-bc23-9a84e5063f27", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7573), "username", null, null, null, null, null, true, false, "Telefon", "6d8135c2-833f-42fc-900d-6eeeb1c607b6", null, "telefon", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7578), "username" },
                    { "8da13d65-1efb-40ea-b88f-08b06d0776ab", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7582), "username", null, null, null, null, null, true, false, "Kulaklık", "6d8135c2-833f-42fc-900d-6eeeb1c607b6", null, "kulaklık", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7582), "username" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressDescription", "CityId", "Company", "CountryId", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "DistrictId", "Email", "FirstName", "IdentityNumber", "InvoiceType", "IpAddress", "IsActive", "IsDeleted", "LastName", "MiddleName", "Phone", "PostalCode", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "c3f70794-26a5-4386-b6d6-09dec963b210", "Yeşilpınar Mah. Üsküp Sok. No:20  Daire:15", "ce87fa38-6bb9-4f9d-9c7c-b2ca767106ba", "", "820b84fc-a4e0-4f56-a34f-e752287d7e52", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "5c8d78df-6a68-4d2a-abe9-bc5638d91fa3", "edmrc58@gmail.com", "Emir", "23456789567", 0, null, false, false, "Demirci", "Sezer", "053456789046", "34122", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "440eb108-0a22-4e9c-a5fb-df0f43a92558", "Yeşilpınar Mah. Çoşkun Sok. No:20  Daire:15", "ce87fa38-6bb9-4f9d-9c7c-b2ca767106ba", "", "820b84fc-a4e0-4f56-a34f-e752287d7e52", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "5c8d78df-6a68-4d2a-abe9-bc5638d91fa3", "karmaillegal57@gmail.com", "Emir", "23333389567", 0, null, false, false, "Demirci", "Sezer", "053356383046", "34132", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "19f1a6cc-8e89-4efa-9ea1-8255f3a4616b", "Mimar Sinan Mah. Zenciler Sok. No:10 Daire:9", "ce87fa38-6bb9-4f9d-9c7c-b2ca767106ba", "İstanbul Ağaç ve Peyzaj A.Ş", "820b84fc-a4e0-4f56-a34f-e752287d7e52", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "5c8d78df-6a68-4d2a-abe9-bc5638d91fa3", "ydmrc57@gmail.com", "Yasin", "23891540669", 0, null, false, false, "Demirci", "", "05301567890", "34533", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "Description", "IpAddress", "IsActive", "IsDeleted", "Name", "ParentId", "Photo", "Slug", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "ed515341-522e-4bfa-8f68-15c874fd77e9", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7565), "username", null, null, null, null, null, true, false, "Dizüstü Notebook", "42729bdd-3160-41f8-b1a6-c68ead8e314d", null, "dizustu-notebook", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7565), "username" },
                    { "1f2f8408-9ad2-4908-b310-92dbdabe5979", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7569), "username", null, null, null, null, null, true, false, "All-In-One", "42729bdd-3160-41f8-b1a6-c68ead8e314d", null, "all-ın-one", new DateTime(2019, 3, 29, 9, 43, 52, 239, DateTimeKind.Local).AddTicks(7569), "username" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AdditionalInformation", "AvailabilityCount", "BrandId", "CategoryId", "Condition", "Cost", "CreatedAt", "CreatedBy", "Culture", "Currency", "DeletedAt", "DeletedBy", "Description", "Discount", "IpAddress", "IsActive", "IsDeleted", "IsFeatured", "IsNew", "IsOnSale", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NewPrice", "OldPrice", "RatingsCount", "RatingsValue", "ShortDescription", "Slug", "StoreId", "Tax", "UpdatedAt", "UpdatedBy", "Weight" },
                values: new object[,]
                {
                    { "35f09f0a-4f59-4c28-8b09-bbc6b083aa2d", "MacBook Pro 2018 Silver | 512 GB-256 GB-128 GB SSD çeşitleri | 16 GB RAM DDR5 | Ayrıca Hediyelerimiz: Çoklu USB portları,Apple mouse,harici dvd sürücü | ", 15, null, "42729bdd-3160-41f8-b1a6-c68ead8e314d", 1, 0m, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8266), "username", null, 0, null, null, "Stokta 15 adet bulunan MacBook Pro 2018 çeşitli hediyeler ile toplam alımlarda %45 indirim ile vitrinimizde.", 0m, null, true, false, true, false, false, null, null, "Elektronik", "MacBook Pro 2018", 13500m, 15000m, 5, 4f, "MacBook Pro 2018 Silver 256 GB SSD ", "MacBook Pro 2018 Silver ", "6ad3fd8a-9b43-440d-bd83-fcf033101d9d", 0f, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8275), "username", null },
                    { "7b4ff888-2e18-4490-b01a-76c4a7b3095b", "Hediyelerimiz bütün iMac ve Apple Pc'lerde geçerlidir.", 25, "e8840d39-abf2-4577-bfa5-a92144107b09", "42729bdd-3160-41f8-b1a6-c68ead8e314d", 1, 0m, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8814), "username", null, 0, null, null, "iMac Pro Uzay Grisi 256 GB SSD | 16 GB RAM DDR5 | İntel i7-9900 3.2 Ghz | Hediyelerimiz: Uzay Grisi Klavye-Fare, Usb Çoğaltıcı, Harici DVD Sürücü, JPL Bluetooth Hoparlör", 0m, null, true, false, true, false, false, null, null, "Elektronik", "iMac Pro Uzay Grisi", 25000m, 30000m, 5, 4f, "iMac Pro Uzay Grisi ", "imac pro uzay grisi", "f544e6dd-70c7-4c99-834e-8147e1bff9f1", 0f, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8818), "username", null },
                    { "7fdad843-e55c-4003-8b6a-486344e6d8cb", "Pembe Yasin-i Şerif ve Sureler Kitabı, Tül Keseli Tesbih", 15, null, "42729bdd-3160-41f8-b1a6-c68ead8e314d", 1, 0m, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8874), "username", null, 0, null, null, "Pembe Yasin-i Şerif ve Sureler Kitabı, Tül Keseli Tesbih ", 0m, null, true, false, true, false, false, null, null, "Hediyelik Kitap", " Pembe Yasin-i Şerif ve Sureler Kitabı", 2m, 4m, 5, 4f, "Pembe Yasin-i Şerif ve Sureler Kitabı", "Pembe Yasin-i Şerif ve Sureler Kitabı", "6ad3fd8a-9b43-440d-bd83-fcf033101d9d", 0f, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8874), "username", null },
                    { "cd9d729e-b245-4606-b480-4e90b94a3882", "Mavi Yasin-i Şerif ve Sureler Kitabı, Tül Keseli Tesbih", 15, null, "42729bdd-3160-41f8-b1a6-c68ead8e314d", 1, 0m, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8882), "username", null, 0, null, null, "Mavi Yasin-i Şerif ve Sureler Kitabı, Tül Keseli Tesbih ", 0m, null, true, false, true, false, false, null, null, "Hediyelik Kitap", " Mavi Yasin-i Şerif ve Sureler Kitabı", 2m, 4m, 5, 4f, "Mavi Yasin-i Şerif ve Sureler Kitabı", "Mavi Yasin-i Şerif ve Sureler Kitabı", "6ad3fd8a-9b43-440d-bd83-fcf033101d9d", 0f, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8882), "username", null },
                    { "700fe299-bb99-47a1-acd5-d614016a374e", "Kırmızı Yasin-i Şerif ve Sureler Kitabı, Tül Keseli Tesbih", 15, null, "42729bdd-3160-41f8-b1a6-c68ead8e314d", 1, 0m, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8891), "username", null, 0, null, null, "Kırmızı Yasin-i Şerif ve Sureler Kitabı, Tül Keseli Tesbih ", 0m, null, true, false, true, false, false, null, null, "Hediyelik Kitap", " Kırmızı Yasin-i Şerif ve Sureler Kitabı", 2m, 4m, 5, 4f, "Kırmızı Yasin-i Şerif ve Sureler Kitabı", "Kırmızı Yasin-i Şerif ve Sureler Kitabı", "6ad3fd8a-9b43-440d-bd83-fcf033101d9d", 0f, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8891), "username", null },
                    { "5e575e49-7724-4527-9ee9-15f4718c0778", "Kabe Desenli Yasin-i Şerif ve Tül Keseli Tespih Seti", 15, null, "42729bdd-3160-41f8-b1a6-c68ead8e314d", 1, 0m, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8972), "username", null, 0, null, null, "Kabe Desenli Yasin-i Şerif ve Tül Keseli Tespih Seti", 0m, null, true, false, true, false, false, null, null, "Hediyelik Kitap", "Kabe Desenli Yasin-i Şerif ve Tül Keseli Tespih Seti", 3m, 5m, 5, 4f, "Kabe Desenli Yasin-i Şerif ve Tül Keseli Tespih Seti", "Kabe Desenli Yasin-i Şerif ve Tül Keseli Tespih Seti", "6ad3fd8a-9b43-440d-bd83-fcf033101d9d", 0f, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8972), "username", null },
                    { "1db450c1-594b-4bed-b726-d4462a4d54f6", "50 Adet Mor Tül Keseli Tespih ve Kadife Sunumluk", 15, null, "42729bdd-3160-41f8-b1a6-c68ead8e314d", 1, 0m, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8981), "username", null, 0, null, null, "50 Adet Mor Tül Keseli Tespih ve Kadife Sunumluk", 0m, null, true, false, true, false, false, null, null, "Hediyelik Kitap", "50 Adet Mor Tül Keseli Tespih ve Kadife Sunumluk", 89m, 0m, 5, 4f, "50 Adet Mor Tül Keseli Tespih ve Kadife Sunumluk", "50 Adet Mor Tül Keseli Tespih ve Kadife Sunumluk", "6ad3fd8a-9b43-440d-bd83-fcf033101d9d", 0f, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8985), "username", null },
                    { "48ffccbf-b72e-4328-a5eb-cf487863589c", "50 Adet Siyah Tül Keseli Tespih ve Kadife Sunumluk", 15, null, "42729bdd-3160-41f8-b1a6-c68ead8e314d", 1, 0m, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8993), "username", null, 0, null, null, "50 Adet Siyah Tül Keseli Tespih ve Kadife Sunumluk", 0m, null, true, false, true, false, false, null, null, "Hediyelik Kitap", "50 Adet Siyah Tül Keseli Tespih ve Kadife Sunumluk", 89m, 0m, 5, 4f, "50 Adet Siyah Tül Keseli Tespih ve Kadife Sunumluk", "50 Adet Siyah Tül Keseli Tespih ve Kadife Sunumluk", "6ad3fd8a-9b43-440d-bd83-fcf033101d9d", 0f, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8993), "username", null },
                    { "0ff69f0d-76e1-4af0-b33d-e7fdee3975d0", "Hediyelerimiz bütün iPhone modellerinde geçerlidir.", 25, "e8840d39-abf2-4577-bfa5-a92144107b09", "4b64df99-8909-4fb4-bc23-9a84e5063f27", 1, 0m, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8835), "username", null, 0, null, null, "iPhone 6 S 64 GB Gümüş | Hediyelerimiz: Kulaklık, Orjinal Bataryalı Kılıf, İki Uçlu Usb Bellek ", 0m, null, true, false, false, false, true, null, null, "Elektronik", "iPhone 6 S 64 GB", 2750m, 2900m, 5, 4f, "iPhone 6 S 64 GB Gümüş", "iPhone 6 S 64 GB Gümüş", "5b843cf0-b7a5-475f-b22e-57054c54ba14", 0f, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8835), "username", null },
                    { "4330ef04-db35-4358-936a-d4db324d4fed", "Piyasanın çok altında satıyoruz herkes kullansın diye.", 30, "45ee14ef-d408-47e3-b104-01a9e23c5def", "4b64df99-8909-4fb4-bc23-9a84e5063f27", 1, 0m, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8848), "username", null, 0, null, null, "Samsung Galaxy Note 9 512 GB Okyanus Mavisi", 0m, null, true, false, false, true, false, null, null, "Elektronik", "Samsung Galaxy Note 9 512 GB", 5200m, 0m, 5, 4f, "Samsung Galaxy Note 9 512 GB Okyanus Mavisi", "Samsung Galaxy Note 9 Note 9 512 GB Okyanus Mavisi", "6ad3fd8a-9b43-440d-bd83-fcf033101d9d", 0f, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8848), "username", null },
                    { "fe01d29b-f753-4b89-a6e8-a502de6cfbe1", "Bütün AirPodslarda hediyelerimiz geçerlidir.", 30, "e8840d39-abf2-4577-bfa5-a92144107b09", "8da13d65-1efb-40ea-b88f-08b06d0776ab", 1, 0m, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8857), "username", null, 0, null, null, "Apple AirPods Kulaklık | Hediyelerimiz: Yedek Parçaları Orjinal, Yedek Şarjı", 0m, null, true, false, false, false, true, null, null, "Elektronik", "Apple AirPods Kulaklık ", 930m, 1000m, 5, 4f, "Apple AirPods Kulaklık", "apple airpods kulaklık", "f544e6dd-70c7-4c99-834e-8147e1bff9f1", 0f, new DateTime(2019, 3, 29, 9, 43, 52, 251, DateTimeKind.Local).AddTicks(8861), "username", null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "DeliveryAddressId", "DemandDate", "InvoiceAddressId", "IpAddress", "IsActive", "IsDeleted", "OrderCode", "OrderDate", "OrderStatus", "StoreId", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[,]
                {
                    { "3349a57f-2dcb-4b9b-922f-7c134517bd47", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "440eb108-0a22-4e9c-a5fb-df0f43a92558", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1990), "c3f70794-26a5-4386-b6d6-09dec963b210", null, false, false, "204723561283", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1992), 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "emir" },
                    { "3f6a2da6-f4c8-48c3-a42c-f0e71e37ee4f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "440eb108-0a22-4e9c-a5fb-df0f43a92558", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1989), "c3f70794-26a5-4386-b6d6-09dec963b210", null, false, false, "204723561286", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1991), 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "emir" },
                    { "51c16d53-3f56-4b7f-b652-37d546811f6b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "440eb108-0a22-4e9c-a5fb-df0f43a92558", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2015), "c3f70794-26a5-4386-b6d6-09dec963b210", null, false, false, "204723561287", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1990), 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "emir" },
                    { "cb93a8b3-c1d6-4c2c-8878-ea91e7e6864c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "440eb108-0a22-4e9c-a5fb-df0f43a92558", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014), "c3f70794-26a5-4386-b6d6-09dec963b210", null, false, false, "204723561288", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2009), 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "emir" },
                    { "e4c732da-9f37-4015-b12b-d2d858dfa03a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "440eb108-0a22-4e9c-a5fb-df0f43a92558", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2013), "c3f70794-26a5-4386-b6d6-09dec963b210", null, false, false, "204723561281", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1988), 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "emir" }
                });

            migrationBuilder.InsertData(
                table: "ProductPhotos",
                columns: new[] { "Id", "Alt", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "IpAddress", "IsActive", "IsDeleted", "Large", "Medium", "Position", "ProductId", "Small", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "85dfb6e4-908d-45c1-b414-a488b6891197", "Samsung Galaxy Note 9 512 GB Okyanus Mavisi", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2270), "username", null, null, null, null, true, false, "samsungnote9.jpg", "samsungnote9.jpg", 0, "4330ef04-db35-4358-936a-d4db324d4fed", "samsungnote9.jpg", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2270), "username" },
                    { "12c5d0df-7ac8-4a6c-8f59-aa4037940c1b", "iPhone 6 S 64 GB Gümüş", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2266), "username", null, null, null, null, true, false, "iPhone664.jpg", "iPhone664.jpg", 0, "0ff69f0d-76e1-4af0-b33d-e7fdee3975d0", "iPhone664.jpg", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2266), "username" },
                    { "c7e447b9-fcbe-43e7-a46c-1a578400fa8e", "50 Adet Siyah Tül Keseli Tespih ve Kadife Sunumluk", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2364), "username", null, null, null, null, true, false, "50adettesbihs.jpg", "50adettesbihs.jpg", 0, "48ffccbf-b72e-4328-a5eb-cf487863589c", "50adettesbihs.jpg", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2364), "username" },
                    { "f9a0eaa5-2934-4097-8c09-551d3cf8b48b", "50 Adet Mor Tül Keseli Tespih ve Kadife Sunumluk", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2304), "username", null, null, null, null, true, false, "50adettesbih.jpg", "50adettesbih.jpg", 0, "1db450c1-594b-4bed-b726-d4462a4d54f6", "50adettesbih.jpg", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2309), "username" },
                    { "7778feda-520c-4157-a80e-0bee5ee57511", "Kabe Desenli Yasin ve Tül Keseli Tespih Seti", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2300), "username", null, null, null, null, true, false, "kurantesbih.jpg", "kurantesbih.jpg", 0, "5e575e49-7724-4527-9ee9-15f4718c0778", "kurantesbih.jpg", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2300), "username" },
                    { "df2bd20c-176a-4392-a918-f0e8509c9161", "Yasin-i Şerif ve Bazı Sureler Kırmızı Kitap ", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2296), "username", null, null, null, null, true, false, "duakitabık.jpg", "duakitabık.jpg", 0, "700fe299-bb99-47a1-acd5-d614016a374e", "duakitabık.jpg", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2296), "username" },
                    { "077e4e64-313e-4d4e-a340-5c84e0a3d748", "Yasin-i Şerif ve Bazı Sureler Mavi Kitap ", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2291), "username", null, null, null, null, true, false, "duakitabım.jpg", "duakitabım.jpg", 0, "cd9d729e-b245-4606-b480-4e90b94a3882", "duakitabım.jpg", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2291), "username" },
                    { "54a82e8b-de71-4f99-9841-4431e78b7552", "Yasin-i Şerif ve Bazı Sureler Pembe Kitap ", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2287), "username", null, null, null, null, true, false, "duakitabıp.jpg", "duakitabıp.jpg", 0, "7fdad843-e55c-4003-8b6a-486344e6d8cb", "duakitabıp.jpg", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2287), "username" },
                    { "cf363e7a-b99a-425f-8d07-50487081049b", "iMac Pro Uzay Grisi", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2253), "username", null, null, null, null, true, false, "iMacPro.jpg", "iMacPro.jpg", 0, "7b4ff888-2e18-4490-b01a-76c4a7b3095b", "iMacPro.jpg", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2257), "username" },
                    { "3e4cc993-9f23-4bb7-a943-59c3cf7fc166", "MacBook Pro 2018 Silver ", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(1842), "username", null, null, null, null, true, false, "macBookPro2018.jpg", "macBookPro2018.jpg", 0, "35f09f0a-4f59-4c28-8b09-bbc6b083aa2d", "macBookPro2018.jpg", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(1851), "username" },
                    { "d5266161-dff1-4c09-9a36-d84ac5cc3b1b", "Apple AirPods Kulaklık ", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2274), "username", null, null, null, null, true, false, "airpods.jpg", "airpods.jpg", 0, "fe01d29b-f753-4b89-a6e8-a502de6cfbe1", "airpods.jpg", new DateTime(2019, 3, 29, 9, 43, 52, 254, DateTimeKind.Local).AddTicks(2274), "username" }
                });

            migrationBuilder.InsertData(
                table: "ProductQuestions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "Description", "IpAddress", "IsActive", "IsDeleted", "IsPublic", "ProductId", "QuestionCategoryId", "ShareDate", "StoreId", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[] { "5a08fa86-8ef2-4e9b-b690-58fd3569d0da", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Açıklama", null, false, false, true, "4330ef04-db35-4358-936a-d4db324d4fed", "c91699f8-0688-4bf5-926d-9f445191a97e", new DateTime(2019, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "6ad3fd8a-9b43-440d-bd83-fcf033101d9d", "Kargo firmanız hale ürünü getirmedi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ApprovedAt", "ApprovedBy", "Body", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "Email", "IpAddress", "IsActive", "IsApproved", "IsDeleted", "Name", "ProductId", "Rating", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "a19e279f-65b3-4b9d-b658-037c9b763aac", null, null, "Çok iyi bir notebook.", new DateTime(2019, 3, 29, 9, 43, 52, 255, DateTimeKind.Local).AddTicks(7670), "username", null, null, null, "cdemirci@outlook.com", null, true, false, false, "Cihan Demirci", "7b4ff888-2e18-4490-b01a-76c4a7b3095b", 0, new DateTime(2019, 3, 29, 9, 43, 52, 255, DateTimeKind.Local).AddTicks(7670), "username" },
                    { "c35776e9-c002-4af9-8553-eb9e466b8910", null, null, "Çok iyi bir notebook.", new DateTime(2019, 3, 29, 9, 43, 52, 255, DateTimeKind.Local).AddTicks(7662), "username", null, null, null, "ydemirci@outlook.com", null, true, false, false, "Yasin Demirci", "35f09f0a-4f59-4c28-8b09-bbc6b083aa2d", 0, new DateTime(2019, 3, 29, 9, 43, 52, 255, DateTimeKind.Local).AddTicks(7662), "username" },
                    { "86b27fee-aa1a-4552-9bcd-6c8100b11138", null, null, "Çok iyi bir telefon elimde şu an", new DateTime(2019, 3, 29, 9, 43, 52, 255, DateTimeKind.Local).AddTicks(7242), "username", null, null, null, "karmaillegal57@gmail.com", null, true, false, false, "Emir Demirci", "0ff69f0d-76e1-4af0-b33d-e7fdee3975d0", 0, new DateTime(2019, 3, 29, 9, 43, 52, 255, DateTimeKind.Local).AddTicks(7251), "username" },
                    { "a93dffde-741e-45bc-8aab-8976e03c172d", null, null, "Çok iyi bir telefon elimde şu an", new DateTime(2019, 3, 29, 9, 43, 52, 255, DateTimeKind.Local).AddTicks(7645), "username", null, null, null, "mdemirci@outlook.com", null, true, false, false, "Murat Demirci", "4330ef04-db35-4358-936a-d4db324d4fed", 0, new DateTime(2019, 3, 29, 9, 43, 52, 255, DateTimeKind.Local).AddTicks(7645), "username" },
                    { "ad673d9a-ff2d-4cb0-bcac-5587f08d2ffc", null, null, "Çok iyi bir kulaklık.", new DateTime(2019, 3, 29, 9, 43, 52, 255, DateTimeKind.Local).AddTicks(7675), "username", null, null, null, "medemirci@outlook.com", null, true, false, false, "Meryem Demirci", "fe01d29b-f753-4b89-a6e8-a502de6cfbe1", 0, new DateTime(2019, 3, 29, 9, 43, 52, 255, DateTimeKind.Local).AddTicks(7675), "username" }
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Conditions", "CouponNo", "CouponNumber", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "Discount", "EndDate", "ForStoreId", "IpAddress", "IsActive", "IsDeleted", "MinTotalPrice", "Name", "OrderId", "StartDate", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "b52b6f2d-b8af-4536-ab90-c3cbc57deedf", "5.500.00 TL üzeri alışverişlerde geçerlidir.", "8414727", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, 133m, new DateTime(2019, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "6ad3fd8a-9b43-440d-bd83-fcf033101d9d", null, false, false, 5.500m, "Size Özel 133 TL Kupon", "3349a57f-2dcb-4b9b-922f-7c134517bd47", new DateTime(2019, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "8d43b37c-47c2-4229-90c4-e0348c603890", "3.500.00 TL üzeri alışverişlerde geçerlidir.", "8514212", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, 90m, new DateTime(2019, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "f544e6dd-70c7-4c99-834e-8147e1bff9f1", null, false, false, 1.500m, "Size Özel 90 TL Kupon", "3f6a2da6-f4c8-48c3-a42c-f0e71e37ee4f", new DateTime(2019, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "AvailabilityCount", "BrandId", "CategoryId", "CreatedAt", "CreatedBy", "Culture", "DeletedAt", "DeletedBy", "IpAddress", "IsActive", "IsDeleted", "Name", "NewPrice", "OldPrice", "OrderId", "ProductId", "Quantity", "ShipperId", "ShortDescription", "StoreId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "75711118-3cf5-484d-910d-8897403583b0", 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Deneme", 0m, 0m, "3349a57f-2dcb-4b9b-922f-7c134517bd47", "4330ef04-db35-4358-936a-d4db324d4fed", 2, "dc20a22d-51d7-439c-9898-1015954cdbbd", "Açıklama", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "787b2292-70fa-4c94-b8b3-4e0ccea4a00a", 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Deneme", 0m, 0m, "3f6a2da6-f4c8-48c3-a42c-f0e71e37ee4f", "4330ef04-db35-4358-936a-d4db324d4fed", 1, "a54ae47b-f94b-4bf8-ab1c-fffabd092012", "Açıklama", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "b010d994-29ef-4f37-a175-da7f3d98159e", 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Deneme", 0m, 0m, "3f6a2da6-f4c8-48c3-a42c-f0e71e37ee4f", "7b4ff888-2e18-4490-b01a-76c4a7b3095b", 3, "8a8f0d2c-cc86-4d11-98d8-eb30847859a7", "Açıklama", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "a10f1ef4-9bb8-4378-acdc-d6303d594a4d", 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Deneme", 0m, 0m, "3f6a2da6-f4c8-48c3-a42c-f0e71e37ee4f", "35f09f0a-4f59-4c28-8b09-bbc6b083aa2d", 1, "dc20a22d-51d7-439c-9898-1015954cdbbd", "Açıklama", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "c96f1242-aeef-458b-95f5-3a1af309e286", 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Deneme", 0m, 0m, "51c16d53-3f56-4b7f-b652-37d546811f6b", "4330ef04-db35-4358-936a-d4db324d4fed", 2, "8a8f0d2c-cc86-4d11-98d8-eb30847859a7", "Açıklama", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "55d69686-2ae8-4060-8e78-8538d484cbe9", 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Deneme", 0m, 0m, "51c16d53-3f56-4b7f-b652-37d546811f6b", "0ff69f0d-76e1-4af0-b33d-e7fdee3975d0", 1, "a54ae47b-f94b-4bf8-ab1c-fffabd092012", "Açıklama", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "97d763e3-04ab-4fc3-ba6f-28742f582630", 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Deneme", 0m, 0m, "cb93a8b3-c1d6-4c2c-8878-ea91e7e6864c", "7b4ff888-2e18-4490-b01a-76c4a7b3095b", 1, "5a240eef-d844-4341-811e-3b2377920a5d", "Açıklama", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "7ace5a6d-1d8d-47db-939f-97d770746c12", 0, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, false, false, "Deneme", 0m, 0m, "e4c732da-9f37-4015-b12b-d2d858dfa03a", "fe01d29b-f753-4b89-a6e8-a502de6cfbe1", 2, "5a240eef-d844-4341-811e-3b2377920a5d", "Açıklama", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_ForStoreId",
                table: "Coupons",
                column: "ForStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_OrderId",
                table: "Coupons",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BrandId",
                table: "OrderItems",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CategoryId",
                table: "OrderItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ShipperId",
                table: "OrderItems",
                column: "ShipperId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_StoreId",
                table: "OrderItems",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InvoiceAddressId",
                table: "Orders",
                column: "InvoiceAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreId",
                table: "Orders",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_ParentId",
                table: "PostCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostPostCategories_PostCategoryId",
                table: "PostPostCategories",
                column: "PostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostPostCategories_PostId",
                table: "PostPostCategories",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_ColorId",
                table: "ProductColors",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_ProductId",
                table: "ProductColors",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuestions_ProductId",
                table: "ProductQuestions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuestions_QuestionCategoryId",
                table: "ProductQuestions",
                column: "QuestionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuestions_StoreId",
                table: "ProductQuestions",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Slides_SliderId",
                table: "Slides",
                column: "SliderId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreBrands_BrandId",
                table: "StoreBrands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreBrands_StoreId",
                table: "StoreBrands",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_ProductId",
                table: "Wishlists",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_UserName_ProductId_IsDeleted",
                table: "Wishlists",
                columns: new[] { "UserName", "ProductId", "IsDeleted" },
                unique: true,
                filter: "[UserName] IS NOT NULL AND [ProductId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "PostPostCategories");

            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "ProductPhotos");

            migrationBuilder.DropTable(
                name: "ProductQuestions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "StoreBrands");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "QuestionCategories");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
