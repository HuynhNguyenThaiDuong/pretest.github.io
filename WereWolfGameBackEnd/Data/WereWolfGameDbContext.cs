using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WereWolfGameBackEnd.Models;

namespace WereWolfGameBackEnd.Data;

public partial class WereWolfGameDbContext : DbContext
{
    public WereWolfGameDbContext()
    {
    }

    public WereWolfGameDbContext(DbContextOptions<WereWolfGameDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CharacterInGame> CharacterInGames { get; set; }

    public virtual DbSet<CharacterType> CharacterTypes { get; set; }

    public virtual DbSet<GameRoom> GameRooms { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<ItemCategory> ItemCategories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<ShopItem> ShopItems { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=database-wwgamedb.c6ejxwl6jwif.ap-southeast-2.rds.amazonaws.com,1433;User ID=admin;Password=m3tch3td1du0c;Database=WereWolfGameDB;Trusted_Connection=true;Encrypt=false;TrustServerCertificate=true;Integrated Security = false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.ToTable("Activity");

            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .HasColumnName("ActivityID");
            entity.Property(e => e.ActivityDescription).HasColumnType("text");
            entity.Property(e => e.ActivityType).HasMaxLength(50);
            entity.Property(e => e.CharacterId)
                .HasMaxLength(50)
                .HasColumnName("CharacterID");

            entity.HasOne(d => d.Character).WithMany(p => p.Activities)
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Activity_Character");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.ToTable("Character");

            entity.Property(e => e.CharacterId)
                .HasMaxLength(50)
                .HasColumnName("CharacterID");
            entity.Property(e => e.CharacterName).HasMaxLength(50);
            entity.Property(e => e.CharacterTypeId)
                .HasMaxLength(50)
                .HasColumnName("CharacterTypeID");
            entity.Property(e => e.Description).HasColumnType("text");

            entity.HasOne(d => d.CharacterType).WithMany(p => p.Characters)
                .HasForeignKey(d => d.CharacterTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Character_CharacterType");
        });

        modelBuilder.Entity<CharacterInGame>(entity =>
        {
            entity.HasKey(e => new { e.RoomId, e.CharacterId });

            entity.ToTable("CharacterInGame");

            entity.Property(e => e.RoomId)
                .HasMaxLength(50)
                .HasColumnName("RoomID");
            entity.Property(e => e.CharacterId)
                .HasMaxLength(50)
                .HasColumnName("CharacterID");
            entity.Property(e => e.PlayerId)
                .HasMaxLength(50)
                .HasColumnName("PlayerID");

            entity.HasOne(d => d.Character).WithMany(p => p.CharacterInGames)
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CharacterInGame_Character");

            entity.HasOne(d => d.Player).WithMany(p => p.CharacterInGames)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_CharacterInGame_Player");

            entity.HasOne(d => d.Room).WithMany(p => p.CharacterInGames)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CharacterInGame_GameRoom");
        });

        modelBuilder.Entity<CharacterType>(entity =>
        {
            entity.ToTable("CharacterType");

            entity.Property(e => e.CharacterTypeId)
                .HasMaxLength(50)
                .HasColumnName("CharacterTypeID");
            entity.Property(e => e.CharacterTypeName).HasMaxLength(50);
            entity.Property(e => e.Description).HasColumnType("text");
        });

        modelBuilder.Entity<GameRoom>(entity =>
        {
            entity.HasKey(e => e.RoomId);

            entity.ToTable("GameRoom");

            entity.Property(e => e.RoomId)
                .HasMaxLength(50)
                .HasColumnName("RoomID");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("Inventory");

            entity.Property(e => e.InventoryId)
                .HasMaxLength(50)
                .HasColumnName("InventoryID");
            entity.Property(e => e.ItemDescription).HasColumnType("text");
            entity.Property(e => e.ItemId)
                .HasMaxLength(50)
                .HasColumnName("ItemID");
            entity.Property(e => e.PlayerId)
                .HasMaxLength(50)
                .HasColumnName("PlayerID");

            entity.HasOne(d => d.Player).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK_Inventory_Player");
        });

        modelBuilder.Entity<ItemCategory>(entity =>
        {
            entity.ToTable("ItemCategory");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("ID");
            entity.Property(e => e.ItemCategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("OrderID");
            entity.Property(e => e.PlayerId)
                .HasMaxLength(50)
                .HasColumnName("PlayerID");

            entity.HasOne(d => d.Player).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Player");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId)
                .HasMaxLength(50)
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("OrderID");
            entity.Property(e => e.ShopItemId)
                .HasMaxLength(50)
                .HasColumnName("ShopItemID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderDetail_Order");

            entity.HasOne(d => d.ShopItem).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ShopItemId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_OrderDetail_ShopItem");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.ToTable("Player");

            entity.Property(e => e.PlayerId)
                .HasMaxLength(50)
                .HasColumnName("PlayerID");
            entity.Property(e => e.PlayerEmail).HasMaxLength(50);
            entity.Property(e => e.PlayerName).HasMaxLength(100);
            entity.Property(e => e.PlayerPassword).HasMaxLength(100);
        });

        modelBuilder.Entity<ShopItem>(entity =>
        {
            entity.ToTable("ShopItem");

            entity.Property(e => e.ShopItemId)
                .HasMaxLength(50)
                .HasColumnName("ShopItemID");
            entity.Property(e => e.CurrencyType).HasMaxLength(50);
            entity.Property(e => e.ItemCategoryId)
                .HasMaxLength(50)
                .HasColumnName("ItemCategoryID");
            entity.Property(e => e.ItemDescription).HasColumnType("text");

            entity.HasOne(d => d.ItemCategory).WithMany(p => p.ShopItems)
                .HasForeignKey(d => d.ItemCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShopItem_ItemCategory");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("Transaction");

            entity.Property(e => e.TransactionId)
                .HasMaxLength(50)
                .HasColumnName("TransactionID");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(50)
                .HasColumnName("ActivityID");
            entity.Property(e => e.WalletId)
                .HasMaxLength(50)
                .HasColumnName("WalletID");

            entity.HasOne(d => d.Activity).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK_Transaction_Activity");

            entity.HasOne(d => d.Wallet).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.WalletId)
                .HasConstraintName("FK_Transaction_Wallet");
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.ToTable("Wallet");

            entity.Property(e => e.WalletId)
                .HasMaxLength(50)
                .HasColumnName("WalletID");
            entity.Property(e => e.CurrencyType).HasMaxLength(50);
            entity.Property(e => e.PlayerId)
                .HasMaxLength(50)
                .HasColumnName("PlayerID");

            entity.HasOne(d => d.Player).WithMany(p => p.Wallets)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK_Wallet_Player");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
