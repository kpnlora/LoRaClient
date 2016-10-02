using System;
using Betabit.Lora.Nuget.Example.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;


namespace Betabit.Lora.Nuget.Example.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20160323094924_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Betabit.Lora.Nuget.Example.Models.Device", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("RoomID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Betabit.Lora.Nuget.Example.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Betabit.Lora.Nuget.Example.Models.Device", b =>
                {
                    b.HasOne("Betabit.Lora.Nuget.Example.Models.Room")
                        .WithMany()
                        .HasForeignKey("RoomID");
                });
        }
    }
}
