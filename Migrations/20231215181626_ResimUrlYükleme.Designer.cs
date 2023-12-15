﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using udemyWeb1.Haberlesme;

#nullable disable

namespace udemyWeb1.Migrations
{
    [DbContext(typeof(UygulamaDbContext))]
    [Migration("20231215181626_ResimUrlYükleme")]
    partial class ResimUrlYükleme
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("udemyWeb1.Models.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bolum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DogumYili")
                        .HasColumnType("int");

                    b.Property<string>("DoktorAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PoliklinikTuruId")
                        .HasColumnType("int");

                    b.Property<string>("ResimUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unvan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PoliklinikTuruId");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("udemyWeb1.Models.PoliklinikTuru", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("PoliklinikTurleri");
                });

            modelBuilder.Entity("udemyWeb1.Models.Doktor", b =>
                {
                    b.HasOne("udemyWeb1.Models.PoliklinikTuru", "PoliklinikTuru")
                        .WithMany()
                        .HasForeignKey("PoliklinikTuruId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PoliklinikTuru");
                });
#pragma warning restore 612, 618
        }
    }
}
