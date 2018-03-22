﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using StoreControl.Infrastructure.Database.Context;
using StoreControl.Shared.Enum;
using System;

namespace StoreControl.Infrastructure.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180321230033_V201803211959")]
    partial class V201803211959
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoreControl.Infrastructure.Database.Models.CustomerAccount", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF")
                        .IsRequired();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime?>("LastDateTimeUpdate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.ToTable("CustomerAccount");
                });

            modelBuilder.Entity("StoreControl.Infrastructure.Database.Models.Purchase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Amount");

                    b.Property<DateTime>("CreationDate");

                    b.Property<Guid>("CustomerAccountID");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime?>("LastDateTimeUpdate");

                    b.HasKey("ID");

                    b.HasIndex("CustomerAccountID");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("StoreControl.Infrastructure.Database.Models.Purchase", b =>
                {
                    b.HasOne("StoreControl.Infrastructure.Database.Models.CustomerAccount", "CustomerAccount")
                        .WithMany()
                        .HasForeignKey("CustomerAccountID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}