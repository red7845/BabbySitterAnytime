﻿// <auto-generated />
using System;
using BabbySitterAnytime.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BabbySitterAnytime.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240421165425_seedAreas")]
    partial class seedAreas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AppointmentStatus")
                        .HasColumnType("int");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("BabySitterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndingTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BabySitterId");

                    b.HasIndex("ClientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.Area", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Areas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3f363c0f-1c10-4eba-85a0-4300d7ca5672"),
                            Name = "Syntagma"
                        },
                        new
                        {
                            Id = new Guid("0c652d85-eec8-43bc-b3eb-f699479f5d2c"),
                            Name = "Plaka"
                        },
                        new
                        {
                            Id = new Guid("5f3b3580-0f36-4e95-a53a-943ea3e1c3d5"),
                            Name = "Monastiraki"
                        },
                        new
                        {
                            Id = new Guid("6dd6eb55-247b-4cb4-8244-4e67e926e2b6"),
                            Name = "Kolonaki"
                        },
                        new
                        {
                            Id = new Guid("487b1f39-9f34-4525-8990-233a4371ab4d"),
                            Name = "Exarchia"
                        },
                        new
                        {
                            Id = new Guid("a2d3aa6e-1094-49d5-b53b-f0904c5f1233"),
                            Name = "Psiri"
                        },
                        new
                        {
                            Id = new Guid("9a55f52e-e66f-47b4-8cc8-63c8e7151931"),
                            Name = "Gazi"
                        },
                        new
                        {
                            Id = new Guid("bf3b356a-9a65-42b4-92e1-871fb2195751"),
                            Name = "Pangrati"
                        },
                        new
                        {
                            Id = new Guid("1ddaee68-f7d1-46a6-9fe5-ad1002be7de9"),
                            Name = "Metaxourgeio"
                        },
                        new
                        {
                            Id = new Guid("5f736a16-3d54-46aa-803f-bf61d5fced7b"),
                            Name = "Koukaki"
                        },
                        new
                        {
                            Id = new Guid("37b2faee-a946-4adf-8836-e69bf110e95e"),
                            Name = "Kypseli"
                        },
                        new
                        {
                            Id = new Guid("18f2615e-69f4-4ba7-8f82-3136a804c82f"),
                            Name = "Thissio"
                        },
                        new
                        {
                            Id = new Guid("95959dee-8cd4-483c-86db-2eeedafb77c8"),
                            Name = "Petralona"
                        },
                        new
                        {
                            Id = new Guid("cafbcd71-da01-4f3f-a407-6c983f063818"),
                            Name = "Neapoli"
                        },
                        new
                        {
                            Id = new Guid("689c2951-0d36-4052-80b8-d6a087664fb8"),
                            Name = "Lykavittos"
                        },
                        new
                        {
                            Id = new Guid("77752e25-cb26-4591-a692-0fa737094de7"),
                            Name = "Neos Kosmos"
                        },
                        new
                        {
                            Id = new Guid("ce26b961-79db-466a-bc0b-749fa443c8ef"),
                            Name = "Agios Dimitrios"
                        },
                        new
                        {
                            Id = new Guid("76c3ed33-0f68-442e-97bf-62d2d6243a41"),
                            Name = "Piraeus"
                        },
                        new
                        {
                            Id = new Guid("cf2084ec-d2ff-43aa-883e-88dbbff1200f"),
                            Name = "Marousi"
                        },
                        new
                        {
                            Id = new Guid("b3f8983f-7aa1-4c0d-a6b1-453854e49791"),
                            Name = "Chalandri"
                        },
                        new
                        {
                            Id = new Guid("aa8ced0d-7452-4086-b041-63bfad21493d"),
                            Name = "Glyfada"
                        },
                        new
                        {
                            Id = new Guid("f93a1fea-ae0e-4007-9201-a069c9067184"),
                            Name = "Vouliagmeni"
                        },
                        new
                        {
                            Id = new Guid("de7d4735-4223-4f17-aa36-48a29bf86033"),
                            Name = "Ilisia"
                        },
                        new
                        {
                            Id = new Guid("4adf3b99-0d31-4ad6-9abd-2b8b32326b6d"),
                            Name = "Ano Patisia"
                        },
                        new
                        {
                            Id = new Guid("8002ec0a-d952-4a9f-ac30-b7e1aa4aebe8"),
                            Name = "Kato Patisia"
                        },
                        new
                        {
                            Id = new Guid("54a58b24-da99-41a4-97ae-e0588545ffa5"),
                            Name = "Zografou"
                        },
                        new
                        {
                            Id = new Guid("b77c315f-50f6-4e2e-a636-95591f6b4bf2"),
                            Name = "Aghia Paraskevi"
                        },
                        new
                        {
                            Id = new Guid("ab1a0f88-feae-48f4-995f-6395e433102a"),
                            Name = "Galatsi"
                        },
                        new
                        {
                            Id = new Guid("1587750d-a197-4d3d-bd82-61c0314ba787"),
                            Name = "Omonia"
                        },
                        new
                        {
                            Id = new Guid("ed0a8e2e-03a6-40e0-9bf9-0a0524857971"),
                            Name = "Sepolia"
                        },
                        new
                        {
                            Id = new Guid("04b7a02b-b9c0-4bae-ac3e-d1753088739e"),
                            Name = "Ano Ilisia"
                        },
                        new
                        {
                            Id = new Guid("ea7b6df5-a821-43ef-acb9-c81e5a5d01da"),
                            Name = "Elliniko"
                        },
                        new
                        {
                            Id = new Guid("75243e70-e22d-4d88-963d-280a1f575fa7"),
                            Name = "Peristeri"
                        },
                        new
                        {
                            Id = new Guid("aeda50e4-50ce-4015-b059-072dda7b7308"),
                            Name = "Kallithea"
                        },
                        new
                        {
                            Id = new Guid("13657cef-3d29-4150-b5ac-b5e0792f1f85"),
                            Name = "Moschato"
                        },
                        new
                        {
                            Id = new Guid("ba6c8d6a-b7c5-4bcb-9f22-bc249ac6fd6f"),
                            Name = "Tavros"
                        },
                        new
                        {
                            Id = new Guid("50480c85-9487-4a47-a31f-3fc2624889d0"),
                            Name = "Nikaia"
                        },
                        new
                        {
                            Id = new Guid("40d18919-aae2-487d-9511-a039b254d018"),
                            Name = "Agios Ioannis Rentis"
                        },
                        new
                        {
                            Id = new Guid("e0f6dbe3-d23a-42cb-9c91-f902fe52d387"),
                            Name = "Kifisia"
                        },
                        new
                        {
                            Id = new Guid("6c34a6de-ebe1-4c23-8dd9-fd56d96eac92"),
                            Name = "Vrilissia"
                        },
                        new
                        {
                            Id = new Guid("39cb9db7-d70e-4c14-83b9-d50dda1816c1"),
                            Name = "Melissia"
                        },
                        new
                        {
                            Id = new Guid("fbf31f4a-e9d6-4353-8b07-9f5f1a78687e"),
                            Name = "Agios Stefanos"
                        },
                        new
                        {
                            Id = new Guid("a6d85545-7d8c-46ef-b37b-85c6b883b09a"),
                            Name = "Ano Liosia"
                        },
                        new
                        {
                            Id = new Guid("40aa9582-4ac9-4ccf-bafe-94595dd6b8c5"),
                            Name = "Varvakeios"
                        },
                        new
                        {
                            Id = new Guid("5d1ce6bc-7562-468b-9bbf-e10bb5b921e1"),
                            Name = "Ambelokipi"
                        },
                        new
                        {
                            Id = new Guid("9937c217-a408-46fc-9a3a-c1056a03888e"),
                            Name = "Gyzi"
                        },
                        new
                        {
                            Id = new Guid("8ebb7374-1f19-4d00-bea5-9602124000e2"),
                            Name = "Psychiko"
                        },
                        new
                        {
                            Id = new Guid("38bd6914-0161-4878-b1ab-750951ae9097"),
                            Name = "Filothei"
                        },
                        new
                        {
                            Id = new Guid("e99fb141-7365-4385-87fd-927f93e2250c"),
                            Name = "Argyroupoli"
                        },
                        new
                        {
                            Id = new Guid("18ad1b27-0071-47e1-92a7-95d21aed578e"),
                            Name = "Alimos"
                        },
                        new
                        {
                            Id = new Guid("af3e9ef6-fbb9-4711-bdce-42be570f5aea"),
                            Name = "Palaio Faliro"
                        },
                        new
                        {
                            Id = new Guid("06885121-ae03-4217-bf2a-718e58dc3de2"),
                            Name = "Kaisariani"
                        },
                        new
                        {
                            Id = new Guid("9079ea1a-c399-41c2-b7aa-402b3bed2141"),
                            Name = "Votanikos"
                        },
                        new
                        {
                            Id = new Guid("09fa55b1-88b5-4717-b60f-4ffc3c3815c3"),
                            Name = "Kerameikos"
                        },
                        new
                        {
                            Id = new Guid("ef1f665c-5f53-434a-8482-8aee380964d6"),
                            Name = "Rizoupoli"
                        },
                        new
                        {
                            Id = new Guid("cecda879-819e-426b-b45a-83b33567b01d"),
                            Name = "Aghios Eleftherios"
                        },
                        new
                        {
                            Id = new Guid("72cfaa46-a09c-4a4f-9cf6-b9f889ab6f99"),
                            Name = "Nea Smyrni"
                        },
                        new
                        {
                            Id = new Guid("14e54e2d-28f2-48ae-904c-87d63df47eca"),
                            Name = "Aghios Artemios"
                        },
                        new
                        {
                            Id = new Guid("10012220-3c2d-4a39-bc7a-a40c4d0df4aa"),
                            Name = "Ano Petralona"
                        },
                        new
                        {
                            Id = new Guid("d8781e34-00df-4c3e-9fb8-ebe435cf0465"),
                            Name = "Kaminia"
                        });
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.Babysitter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Babysitters");
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.CurriculumVitae", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BabySitterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BabySitterId")
                        .IsUnique();

                    b.ToTable("CurriculumVitaes");
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BabysitterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BabysitterId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.Appointment", b =>
                {
                    b.HasOne("BabbySitterAnytime.DataBaseModels.Babysitter", "Babysitter")
                        .WithMany("Appointments")
                        .HasForeignKey("BabySitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BabbySitterAnytime.DataBaseModels.Customer", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Babysitter");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.Babysitter", b =>
                {
                    b.HasOne("BabbySitterAnytime.DataBaseModels.User", "User")
                        .WithOne("Babysitter")
                        .HasForeignKey("BabbySitterAnytime.DataBaseModels.Babysitter", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.CurriculumVitae", b =>
                {
                    b.HasOne("BabbySitterAnytime.DataBaseModels.Babysitter", "Babysitter")
                        .WithOne("CurriculumVitae")
                        .HasForeignKey("BabbySitterAnytime.DataBaseModels.CurriculumVitae", "BabySitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Babysitter");
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.Customer", b =>
                {
                    b.HasOne("BabbySitterAnytime.DataBaseModels.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("BabbySitterAnytime.DataBaseModels.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.Rating", b =>
                {
                    b.HasOne("BabbySitterAnytime.DataBaseModels.Babysitter", "Babysitter")
                        .WithMany("Ratings")
                        .HasForeignKey("BabysitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Babysitter");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BabbySitterAnytime.DataBaseModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BabbySitterAnytime.DataBaseModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BabbySitterAnytime.DataBaseModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BabbySitterAnytime.DataBaseModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.Babysitter", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("CurriculumVitae")
                        .IsRequired();

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.Customer", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("BabbySitterAnytime.DataBaseModels.User", b =>
                {
                    b.Navigation("Babysitter")
                        .IsRequired();

                    b.Navigation("Customer")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
