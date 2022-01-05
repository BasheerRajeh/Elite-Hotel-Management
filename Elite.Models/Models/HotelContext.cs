using System;
using Elite.AppDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled. If
// you have enabled NRTs for your project, then un-comment the following line: #nullable disable

namespace Elite.AppDbContext
{
    public partial class HotelContext : IdentityDbContext<ApplicationUser, IdentityRole, string> //DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Feature> Feature { get; set; }
        public virtual DbSet<FoodCat> FoodCat { get; set; }
        public virtual DbSet<FoodItem> FoodItem { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomStatus> RoomStatus { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceCat> ServiceCat { get; set; }
        public virtual DbSet<SpecialService> SpecialService { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Hotel;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PricePerNight).HasColumnType("decimal(19, 4)");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Value).HasMaxLength(128);
            });

            modelBuilder.Entity<FoodCat>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<FoodItem>(entity =>
            {
                entity.HasIndex(e => e.FoodCatId);

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.FoodCat)
                    .WithMany(p => p.FoodItem)
                    .HasForeignKey(d => d.FoodCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FoodItem_FoodCat");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.FoodItemId);

                entity.HasIndex(e => e.ReservationId);

                entity.Property(e => e.OrderNum)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Time)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.FoodItem)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.FoodItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_FoodItem");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Reservation");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasIndex(e => e.FeatureId);

                entity.HasIndex(e => e.RoomId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.Package)
                    .HasForeignKey(d => d.FeatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Package_Feature");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Package)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Package_Room");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasIndex(e => e.RoomId);

                entity.Property(e => e.Checkout).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.RequestDate).HasColumnType("date");

                entity.Property(e => e.ReservationNum)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_Room");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasIndex(e => e.CategoryId);

                entity.HasIndex(e => e.HotelId);

                entity.HasIndex(e => e.RoomStatusId);

                entity.Property(e => e.Num)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Category");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Hotel");

                entity.HasOne(d => d.RoomStatus)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.RoomStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_RoomStatus");
            });

            modelBuilder.Entity<RoomStatus>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Value).HasMaxLength(128);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");
            });

            modelBuilder.Entity<ServiceCat>(entity =>
            {
                entity.HasIndex(e => e.CategoryId);

                entity.HasIndex(e => e.ServiceId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ServiceCat)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceCat_Category");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceCat)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceCat_Service");
            });

            modelBuilder.Entity<SpecialService>(entity =>
            {
                entity.HasIndex(e => e.ReservationId);

                entity.HasIndex(e => e.ServiceCatId);

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.SpecialService)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecialService_Reservation");

                entity.HasOne(d => d.ServiceCat)
                    .WithMany(p => p.SpecialService)
                    .HasForeignKey(d => d.ServiceCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpecialService_ServiceCat");
            });

            base.OnModelCreating(modelBuilder);
        }

        //private partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}