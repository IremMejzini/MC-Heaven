using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MCApp.Models
{
    public partial class MCHeavenContext : DbContext
    {
        public MCHeavenContext()
        {
        }

        public MCHeavenContext(DbContextOptions<MCHeavenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAddress> TAddress { get; set; }
        public virtual DbSet<TCoupon> TCoupon { get; set; }
        public virtual DbSet<TDrink> TDrink { get; set; }
        public virtual DbSet<TIngredient> TIngredient { get; set; }
        public virtual DbSet<TOpenHour> TOpenHour { get; set; }
        public virtual DbSet<TOrder> TOrder { get; set; }
        public virtual DbSet<TOrderDetail> TOrderDetail { get; set; }
        public virtual DbSet<TPaymentMethod> TPaymentMethod { get; set; }
        public virtual DbSet<TReceive> TReceive { get; set; }
        public virtual DbSet<TShop> TShop { get; set; }
        public virtual DbSet<TShopDrink> TShopDrink { get; set; }
        public virtual DbSet<TSize> TSize { get; set; }
        public virtual DbSet<TUser> TUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-K9MBT2S7\\SQLCOURSE2019;Database=MCHeaven;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<TAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK_tAddress_AddressID");

                entity.ToTable("tAddress");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FlatNumber).HasMaxLength(6);

                entity.Property(e => e.HouseNumber)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TCoupon>(entity =>
            {
                entity.HasKey(e => e.CouponId)
                    .HasName("PK_tCoupon_CouponID");

                entity.ToTable("tCoupon");

                entity.Property(e => e.CouponId).HasColumnName("CouponID");

                entity.Property(e => e.TypeCoupon)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TDrink>(entity =>
            {
                entity.HasKey(e => e.DrinkId)
                    .HasName("PK_tDrink_DrinkID");

                entity.ToTable("tDrink");

                entity.HasIndex(e => e.DrinkName)
                    .HasName("AK_tDrink_DrinkName")
                    .IsUnique();

                entity.Property(e => e.DrinkId).HasColumnName("DrinkID");

                entity.Property(e => e.DrinkName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.ParentDrinkId).HasColumnName("ParentDrinkID");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.TDrink)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK_tDrink_tIngredient_tIngredientID");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.TDrink)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_tDrink_tSize_tSizeID");
            });

            modelBuilder.Entity<TIngredient>(entity =>
            {
                entity.HasKey(e => e.IngredientId)
                    .HasName("PK_tIngredient_IngredientID");

                entity.ToTable("tIngredient");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.NameIngredient)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TOpenHour>(entity =>
            {
                entity.HasKey(e => e.OpenHourId)
                    .HasName("PK_tOpenHour_OpenHourID");

                entity.ToTable("tOpenHour");

                entity.Property(e => e.OpenHourId).HasColumnName("OpenHourID");

                entity.Property(e => e.FromO)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.Property(e => e.ToO)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.TOpenHour)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_tOrder_OrderID");

                entity.ToTable("tOrder");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CouponId).HasColumnName("CouponID");

                entity.Property(e => e.PaymentMid).HasColumnName("PaymentMID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.TOrder)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_tOrder_tAddres_tAddressID");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.TOrder)
                    .HasForeignKey(d => d.CouponId)
                    .HasConstraintName("FK_tOrder_tCoupon_tCouponID");

                entity.HasOne(d => d.PaymentM)
                    .WithMany(p => p.TOrder)
                    .HasForeignKey(d => d.PaymentMid)
                    .HasConstraintName("FK_tOrder_tPaymentMethod_tPaymentMID");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.TOrder)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_tOrder_tShop_tShopID");
            });

            modelBuilder.Entity<TOrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDid)
                    .HasName("PK_OrderDetail_OrderDID");

                entity.ToTable("tOrderDetail");

                entity.Property(e => e.OrderDid).HasColumnName("OrderDID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ReceiveId).HasColumnName("ReceiveID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TOrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_tOrderDetail_tOrder_tOrderID");

                entity.HasOne(d => d.Receive)
                    .WithMany(p => p.TOrderDetail)
                    .HasForeignKey(d => d.ReceiveId)
                    .HasConstraintName("FK_tOrderDetail_tReceive_tReceiveID");
            });

            modelBuilder.Entity<TPaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentMid)
                    .HasName("PK_tPaymentMethod_PaymentMID");

                entity.ToTable("tPaymentMethod");

                entity.Property(e => e.PaymentMid).HasColumnName("PaymentMID");

                entity.Property(e => e.TypePayment)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TReceive>(entity =>
            {
                entity.HasKey(e => e.ReceiveId)
                    .HasName("PK_Receive_ReceiveID");

                entity.ToTable("tReceive");

                entity.Property(e => e.ReceiveId).HasColumnName("ReceiveID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PaymentMid).HasColumnName("PaymentMID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TReceive)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_tReceive_tOrder_tOrderID");

                entity.HasOne(d => d.PaymentM)
                    .WithMany(p => p.TReceive)
                    .HasForeignKey(d => d.PaymentMid)
                    .HasConstraintName("FK_tReceive_tPaymentMethod_tPaymentMID");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.TReceive)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_tReceive_tShop_tShopID");
            });

            modelBuilder.Entity<TShop>(entity =>
            {
                entity.HasKey(e => e.ShopId)
                    .HasName("PK_tShop_ShopID");

                entity.ToTable("tShop");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.NameShop)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.OpenHourId).HasColumnName("OpenHourID");
            });

            modelBuilder.Entity<TShopDrink>(entity =>
            {
                entity.HasKey(e => new { e.DrinkId, e.ShopId })
                    .HasName("PK_tShopDrink_tDrink_tShop");

                entity.ToTable("tShopDrink");

                entity.Property(e => e.DrinkId).HasColumnName("DrinkID");

                entity.Property(e => e.ShopId).HasColumnName("ShopID");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.TShopDrink)
                    .HasForeignKey(d => d.DrinkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tShopDrink_tDrink_tDrinkID");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.TShopDrink)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tShopDrink_tShop_tShopID");
            });

            modelBuilder.Entity<TSize>(entity =>
            {
                entity.HasKey(e => e.SizeId)
                    .HasName("PK_tSize_SizeID");

                entity.ToTable("tSize");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.TypeSize)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_tUser_UserID");

                entity.ToTable("tUser");

                entity.HasIndex(e => e.UserLogin)
                    .HasName("AK_tUser_UserLogin")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.PhoneNumber).HasMaxLength(11);

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.TUser)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_tUser_tAddress_tAddressID");
            });
        }
    }
}
