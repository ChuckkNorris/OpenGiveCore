using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OpenGiveCore.Server.Entities;

namespace OpenGiveCore.Server.Entities.Migrations
{
    [DbContext(typeof(LadotContext))]
    [Migration("20170523014957_approval")]
    partial class approval
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenGiveCore.Server.Entities.WorkOrderRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsApproved");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("RequestorEmail");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("WorkOrderRequests");
                });
        }
    }
}
