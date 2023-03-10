// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Persistence;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebApi.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntry", b =>
                {
                    b.Property<int>("AuditEntryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuditEntryID"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(6);

                    b.Property<string>("EntitySetName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnOrder(1);

                    b.Property<string>("EntityTypeName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnOrder(2);

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<string>("StateName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnOrder(4);

                    b.HasKey("AuditEntryID");

                    b.ToTable("AuditEntries");
                });

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntryProperty", b =>
                {
                    b.Property<int>("AuditEntryPropertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuditEntryPropertyID"));

                    b.Property<int>("AuditEntryID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("NewValueFormatted")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NewValue")
                        .HasColumnOrder(5);

                    b.Property<string>("OldValueFormatted")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("OldValue")
                        .HasColumnOrder(4);

                    b.Property<string>("PropertyName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnOrder(3);

                    b.Property<string>("RelationName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnOrder(2);

                    b.HasKey("AuditEntryPropertyID");

                    b.HasIndex("AuditEntryID");

                    b.ToTable("AuditEntryProperties");
                });

            modelBuilder.Entity("WebApi.Domain.Product", b =>
                {
                    b.HasOne("WebApi.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntryProperty", b =>
                {
                    b.HasOne("Z.EntityFramework.Plus.AuditEntry", "Parent")
                        .WithMany("Properties")
                        .HasForeignKey("AuditEntryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("WebApi.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntry", b =>
                {
                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
