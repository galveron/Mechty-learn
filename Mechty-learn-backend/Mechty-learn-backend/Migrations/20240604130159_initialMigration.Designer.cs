﻿// <auto-generated />
using System;
using Mechty_learn_backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mechty_learn_backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240604130159_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Mechty_learn_backend.Models.Adult", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<int?>("Adults3DModelId")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("Adults3DModelId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.Adults3DModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adults3DIconUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Adults3DModels");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LessonId")
                        .HasColumnType("integer");

                    b.Property<string>("ChapterDescription")
                        .HasColumnType("text");

                    b.Property<string>("ChapterTitle")
                        .HasColumnType("text");

                    b.HasKey("Id", "LessonId");

                    b.HasIndex("LessonId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.ChapterPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChapterId")
                        .HasColumnType("integer");

                    b.Property<int?>("ChapterLessonId")
                        .HasColumnType("integer");

                    b.Property<string>("ChapterPageDescription")
                        .HasColumnType("text");

                    b.Property<string>("ChapterPageTitle")
                        .HasColumnType("text");

                    b.HasKey("Id", "ChapterId");

                    b.HasIndex("ChapterId", "ChapterLessonId");

                    b.ToTable("ChapterPages");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.ChapterPage3DModel", b =>
                {
                    b.Property<int>("ChapterPageId")
                        .HasColumnType("integer");

                    b.Property<string>("ChapterPage3DModelUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ChapterPageChapterId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("ChapterPageId");

                    b.HasIndex("ChapterPageId", "ChapterPageChapterId")
                        .IsUnique();

                    b.ToTable("ChapterPage3DModels");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.ChapterPageSound", b =>
                {
                    b.Property<int>("ChapterPageId")
                        .HasColumnType("integer");

                    b.Property<int>("ChapterPageChapterId")
                        .HasColumnType("integer");

                    b.Property<string>("ChapterPageSoundUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("ChapterPageId");

                    b.HasIndex("ChapterPageId", "ChapterPageChapterId")
                        .IsUnique();

                    b.ToTable("ChapterPageSounds");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.ChapterPageText", b =>
                {
                    b.Property<int>("ChapterPageId")
                        .HasColumnType("integer");

                    b.Property<int>("ChapterPageChapterId")
                        .HasColumnType("integer");

                    b.Property<string>("ChapterPageTextUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("ChapterPageId");

                    b.HasIndex("ChapterPageId", "ChapterPageChapterId")
                        .IsUnique();

                    b.ToTable("ChapterPageTexts");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.EducationalModels.EducationalProcess.ChapterProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("KidId")
                        .HasColumnType("text");

                    b.Property<int>("ChapterId")
                        .HasColumnType("integer");

                    b.Property<int?>("ChapterLessonId")
                        .HasColumnType("integer");

                    b.Property<string>("KidAdultId")
                        .HasColumnType("text");

                    b.Property<int>("Progress")
                        .HasColumnType("integer");

                    b.HasKey("Id", "KidId", "ChapterId");

                    b.HasIndex("ChapterId", "ChapterLessonId")
                        .IsUnique();

                    b.HasIndex("KidId", "KidAdultId")
                        .IsUnique();

                    b.ToTable("ChapterProgresses");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.EducationalModels.EducationalProcess.LessonProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("KidId")
                        .HasColumnType("text");

                    b.Property<int>("LessonId")
                        .HasColumnType("integer");

                    b.Property<string>("KidAdultId")
                        .HasColumnType("text");

                    b.Property<int>("Progress")
                        .HasColumnType("integer");

                    b.HasKey("Id", "KidId", "LessonId");

                    b.HasIndex("LessonId")
                        .IsUnique();

                    b.HasIndex("KidId", "KidAdultId")
                        .IsUnique();

                    b.ToTable("LessonProgresses");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.Kid", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AdultId")
                        .HasColumnType("text");

                    b.Property<int>("KidProgress")
                        .HasColumnType("integer");

                    b.Property<int?>("Kids3DModelId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.HasKey("Id", "AdultId");

                    b.HasIndex("AdultId");

                    b.HasIndex("Kids3DModelId");

                    b.ToTable("Kids");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.Kids3DModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Kids3DIconUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Kids3DModels");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("LessonDescription")
                        .HasColumnType("text");

                    b.Property<string>("LessonTitle")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.Adult", b =>
                {
                    b.HasOne("Mechty_learn_backend.Models.Adults3DModel", null)
                        .WithMany("Adults")
                        .HasForeignKey("Adults3DModelId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.Chapter", b =>
                {
                    b.HasOne("Mechty_learn_backend.Models.Lesson", null)
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.ChapterPage", b =>
                {
                    b.HasOne("Mechty_learn_backend.Models.Chapter", null)
                        .WithMany()
                        .HasForeignKey("ChapterId", "ChapterLessonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.ChapterPage3DModel", b =>
                {
                    b.HasOne("Mechty_learn_backend.Models.ChapterPage", "ChapterPage")
                        .WithOne()
                        .HasForeignKey("Mechty_learn_backend.Models.ChapterPage3DModel", "ChapterPageId", "ChapterPageChapterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ChapterPage");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.ChapterPageSound", b =>
                {
                    b.HasOne("Mechty_learn_backend.Models.ChapterPage", "ChapterPage")
                        .WithOne()
                        .HasForeignKey("Mechty_learn_backend.Models.ChapterPageSound", "ChapterPageId", "ChapterPageChapterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ChapterPage");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.ChapterPageText", b =>
                {
                    b.HasOne("Mechty_learn_backend.Models.ChapterPage", "ChapterPage")
                        .WithOne()
                        .HasForeignKey("Mechty_learn_backend.Models.ChapterPageText", "ChapterPageId", "ChapterPageChapterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ChapterPage");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.EducationalModels.EducationalProcess.ChapterProgress", b =>
                {
                    b.HasOne("Mechty_learn_backend.Models.Chapter", "Chapter")
                        .WithOne()
                        .HasForeignKey("Mechty_learn_backend.Models.EducationalModels.EducationalProcess.ChapterProgress", "ChapterId", "ChapterLessonId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Mechty_learn_backend.Models.Kid", "Kid")
                        .WithOne()
                        .HasForeignKey("Mechty_learn_backend.Models.EducationalModels.EducationalProcess.ChapterProgress", "KidId", "KidAdultId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Chapter");

                    b.Navigation("Kid");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.EducationalModels.EducationalProcess.LessonProgress", b =>
                {
                    b.HasOne("Mechty_learn_backend.Models.Lesson", "Lesson")
                        .WithOne()
                        .HasForeignKey("Mechty_learn_backend.Models.EducationalModels.EducationalProcess.LessonProgress", "LessonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Mechty_learn_backend.Models.Kid", "Kid")
                        .WithOne()
                        .HasForeignKey("Mechty_learn_backend.Models.EducationalModels.EducationalProcess.LessonProgress", "KidId", "KidAdultId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Kid");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.Kid", b =>
                {
                    b.HasOne("Mechty_learn_backend.Models.Adult", null)
                        .WithMany("Kids")
                        .HasForeignKey("AdultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mechty_learn_backend.Models.Kids3DModel", null)
                        .WithMany("Kids")
                        .HasForeignKey("Kids3DModelId")
                        .OnDelete(DeleteBehavior.NoAction);
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
                    b.HasOne("Mechty_learn_backend.Models.Adult", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Mechty_learn_backend.Models.Adult", null)
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

                    b.HasOne("Mechty_learn_backend.Models.Adult", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Mechty_learn_backend.Models.Adult", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.Adult", b =>
                {
                    b.Navigation("Kids");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.Adults3DModel", b =>
                {
                    b.Navigation("Adults");
                });

            modelBuilder.Entity("Mechty_learn_backend.Models.Kids3DModel", b =>
                {
                    b.Navigation("Kids");
                });
#pragma warning restore 612, 618
        }
    }
}
