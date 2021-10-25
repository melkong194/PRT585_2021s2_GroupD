﻿// <auto-generated />
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Act", b =>
                {
                    b.Property<long>("ActID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Act_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Act_Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Act_Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Act_lat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Act_lng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Act_userID")
                        .HasColumnType("bigint");

                    b.Property<string>("Act_userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActID");

                    b.ToTable("Act");
                });

            modelBuilder.Entity("DAL.Entities.Event", b =>
                {
                    b.Property<long>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Event_End")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event_RecurrenceRule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event_Start")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Event_userID")
                        .HasColumnType("bigint");

                    b.Property<string>("Event_userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("DAL.Entities.Student", b =>
                {
                    b.Property<long>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Student_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<long>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("User_Account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Hour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
