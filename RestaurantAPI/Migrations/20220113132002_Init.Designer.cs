// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantAPI.Entities;

namespace RestaurantAPI.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20220113132002_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RestaurantAPI.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("RestaurantAPI.Entities.Dish", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RestaurantID");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("RestaurantAPI.Entities.Restaurant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasDelivery")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("RestaurantAPI.Entities.Dish", b =>
                {
                    b.HasOne("RestaurantAPI.Entities.Restaurant", "restaurant")
                        .WithMany("Dishes")
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("restaurant");
                });

            modelBuilder.Entity("RestaurantAPI.Entities.Restaurant", b =>
                {
                    b.HasOne("RestaurantAPI.Entities.Address", "Address")
                        .WithOne("Restaurant")
                        .HasForeignKey("RestaurantAPI.Entities.Restaurant", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("RestaurantAPI.Entities.Address", b =>
                {
                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantAPI.Entities.Restaurant", b =>
                {
                    b.Navigation("Dishes");
                });
#pragma warning restore 612, 618
        }
    }
}
