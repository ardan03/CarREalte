using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarRealte.DB;

public partial class RetailAutoContext : DbContext
{
    public RetailAutoContext()
    {
    }

    public RetailAutoContext(DbContextOptions<RetailAutoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BodyType> BodyTypes { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarDetail> CarDetails { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Transmission> Transmissions { get; set; }

    public virtual DbSet<Аренда> Арендаs { get; set; }

    public virtual DbSet<Должность> Должностьs { get; set; }

    public virtual DbSet<Клиент> Клиентs { get; set; }

    public virtual DbSet<Клиенты> Клиентыs { get; set; }

    public virtual DbSet<Пользователи> Пользователиs { get; set; }

    public virtual DbSet<ПользователиИДолжности> ПользователиИДолжностиs { get; set; }

    public virtual DbSet<ПользователиИИнформация> ПользователиИИнформацияs { get; set; }

    public virtual DbSet<ПредставлениеАренда> ПредставлениеАрендаs { get; set; }

    public virtual DbSet<Сотрудник> Сотрудникs { get; set; }

    public virtual DbSet<Тарифы> Тарифыs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-2AHKDIC;Database=RetailAuto;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BodyType>(entity =>
        {
            entity.HasKey(e => e.BodyTypeId).HasName("PK__BodyType__3667A71CFA45F9B5");

            entity.Property(e => e.BodyTypeId)
                .ValueGeneratedNever()
                .HasColumnName("body_type_id");
            entity.Property(e => e.BodyTypeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("body_type_name");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brands__5E5A8E274A240D45");

            entity.Property(e => e.BrandId)
                .ValueGeneratedNever()
                .HasColumnName("brand_id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("brand_name");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.LicensePlate).HasName("PK__Cars__F72CD56F5BC3E263");

            entity.Property(e => e.LicensePlate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("license_plate");
            entity.Property(e => e.Availability).HasColumnName("availability");
            entity.Property(e => e.ColorId).HasColumnName("color_id");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.TransmissionId).HasColumnName("transmission_id");

            entity.HasOne(d => d.Color).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK__Cars__color_id__44FF419A");

            entity.HasOne(d => d.Model).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("FK__Cars__model_id__4316F928");

            entity.HasOne(d => d.Transmission).WithMany(p => p.Cars)
                .HasForeignKey(d => d.TransmissionId)
                .HasConstraintName("FK__Cars__transmissi__440B1D61");
        });

        modelBuilder.Entity<CarDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CarDetails");

            entity.Property(e => e.Availability).HasColumnName("availability");
            entity.Property(e => e.BodyTypeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("body_type_name");
            entity.Property(e => e.BrandName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("brand_name");
            entity.Property(e => e.ColorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("color_name");
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("license_plate");
            entity.Property(e => e.ModelName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("model_name");
            entity.Property(e => e.TransmissionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("transmission_type");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__Color__1143CECB4682D3A9");

            entity.ToTable("Color");

            entity.Property(e => e.ColorId)
                .ValueGeneratedNever()
                .HasColumnName("color_id");
            entity.Property(e => e.ColorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("color_name");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("PK__Models__DC39CAF44112F53E");

            entity.Property(e => e.ModelId)
                .ValueGeneratedNever()
                .HasColumnName("model_id");
            entity.Property(e => e.BodyTypeId).HasColumnName("body_type_id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.ModelName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("model_name");

            entity.HasOne(d => d.BodyType).WithMany(p => p.Models)
                .HasForeignKey(d => d.BodyTypeId)
                .HasConstraintName("FK__Models__body_typ__3C69FB99");

            entity.HasOne(d => d.Brand).WithMany(p => p.Models)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Models__brand_id__3B75D760");
        });

        modelBuilder.Entity<Transmission>(entity =>
        {
            entity.HasKey(e => e.TransmissionId).HasName("PK__Transmis__91095309235110FB");

            entity.ToTable("Transmission");

            entity.Property(e => e.TransmissionId)
                .ValueGeneratedNever()
                .HasColumnName("transmission_id");
            entity.Property(e => e.TransmissionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("transmission_type");
        });

        modelBuilder.Entity<Аренда>(entity =>
        {
            entity.HasKey(e => e.IdАренды).HasName("PK__Аренда__E5F69C74A2C74F52");

            entity.ToTable("Аренда");

            entity.Property(e => e.IdАренды).HasColumnName("id_Аренды");
            entity.Property(e => e.Автомобиль)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.АвтомобильNavigation).WithMany(p => p.Арендаs)
                .HasForeignKey(d => d.Автомобиль)
                .HasConstraintName("FK__Аренда__Автомоби__7F2BE32F");

            entity.HasOne(d => d.ПользовательNavigation).WithMany(p => p.Арендаs)
                .HasForeignKey(d => d.Пользователь)
                .HasConstraintName("FK__Аренда__Пользова__00200768");

            entity.HasOne(d => d.ТарифNavigation).WithMany(p => p.Арендаs)
                .HasForeignKey(d => d.Тариф)
                .HasConstraintName("FK__Аренда__Тариф__01142BA1");
        });

        modelBuilder.Entity<Должность>(entity =>
        {
            entity.HasKey(e => e.IdДолжности).HasName("PK__Должност__15DEC241C593EDEF");

            entity.ToTable("Должность");

            entity.Property(e => e.IdДолжности).HasColumnName("id_Должности");
            entity.Property(e => e.Должность1)
                .HasMaxLength(50)
                .HasColumnName("Должность");
            entity.Property(e => e.Зарплата).HasColumnType("decimal(15, 2)");
        });

        modelBuilder.Entity<Клиент>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Клиент");

            entity.Property(e => e.IdПользователя).HasColumnName("id_Пользователя");
            entity.Property(e => e.ВодительскоеУдостоверение)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Водительское удостоверение");
            entity.Property(e => e.Имя).HasMaxLength(100);
            entity.Property(e => e.Логин).HasMaxLength(50);
            entity.Property(e => e.НомерТелефона)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Номер телефона");
            entity.Property(e => e.Пароль).HasMaxLength(50);
            entity.Property(e => e.Фамилия).HasMaxLength(100);
        });

        modelBuilder.Entity<Клиенты>(entity =>
        {
            entity.HasKey(e => e.IdКлиента).HasName("PK__Клиенты__7481052660A78D16");

            entity.ToTable("Клиенты");

            entity.Property(e => e.IdКлиента).HasColumnName("id_Клиента");
            entity.Property(e => e.IdПользователя).HasColumnName("id_Пользователя");
            entity.Property(e => e.ВодительскоеУдостоверение)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Водительское удостоверение");
            entity.Property(e => e.НомерТелефона)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Номер телефона");

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.Клиентыs)
                .HasForeignKey(d => d.IdПользователя)
                .HasConstraintName("FK__Клиенты__id_Поль__5FB337D6");
        });

        modelBuilder.Entity<Пользователи>(entity =>
        {
            entity.HasKey(e => e.IdПользователя).HasName("PK__Пользова__1E6A6F374410447C");

            entity.ToTable("Пользователи");

            entity.Property(e => e.IdПользователя).HasColumnName("id_Пользователя");
            entity.Property(e => e.Имя).HasMaxLength(100);
            entity.Property(e => e.Логин).HasMaxLength(50);
            entity.Property(e => e.Пароль).HasMaxLength(50);
            entity.Property(e => e.Фамилия).HasMaxLength(100);
        });

        modelBuilder.Entity<ПользователиИДолжности>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Пользователи_и_должности");

            entity.Property(e => e.IdПользователя).HasColumnName("id_Пользователя");
            entity.Property(e => e.Должность).HasMaxLength(50);
            entity.Property(e => e.Зарплата).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Имя).HasMaxLength(100);
            entity.Property(e => e.Логин).HasMaxLength(50);
            entity.Property(e => e.Пароль).HasMaxLength(50);
            entity.Property(e => e.Фамилия).HasMaxLength(100);
        });

        modelBuilder.Entity<ПользователиИИнформация>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Пользователи_и_информация");

            entity.Property(e => e.IdПользователя).HasColumnName("id_Пользователя");
            entity.Property(e => e.ВодительскоеУдостоверение)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Водительское удостоверение");
            entity.Property(e => e.Имя).HasMaxLength(100);
            entity.Property(e => e.Логин).HasMaxLength(50);
            entity.Property(e => e.НомерТелефона)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("Номер телефона");
            entity.Property(e => e.Пароль).HasMaxLength(50);
            entity.Property(e => e.Фамилия).HasMaxLength(100);
        });

        modelBuilder.Entity<ПредставлениеАренда>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Представление_Аренда");

            entity.Property(e => e.Имя).HasMaxLength(100);
            entity.Property(e => e.Марка)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Модель)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.НазваниеАренды)
                .HasMaxLength(255)
                .HasColumnName("Название_аренды");
            entity.Property(e => e.Фамилия).HasMaxLength(100);
            entity.Property(e => e.ЦенаАренды)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("Цена_аренды");
        });

        modelBuilder.Entity<Сотрудник>(entity =>
        {
            entity.HasKey(e => e.IdСотрудника).HasName("PK__Сотрудни__F2D52D60EBBD2BC7");

            entity.ToTable("Сотрудник");

            entity.Property(e => e.IdСотрудника).HasColumnName("id_Сотрудника");
            entity.Property(e => e.IdПользователя).HasColumnName("id_Пользователя");

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.Сотрудникs)
                .HasForeignKey(d => d.IdПользователя)
                .HasConstraintName("FK__Сотрудник__id_По__6477ECF3");

            entity.HasOne(d => d.ДолжностьNavigation).WithMany(p => p.Сотрудникs)
                .HasForeignKey(d => d.Должность)
                .HasConstraintName("FK__Сотрудник__Должн__656C112C");
        });

        modelBuilder.Entity<Тарифы>(entity =>
        {
            entity.HasKey(e => e.IdТарифа).HasName("PK__Тарифы__5EB77FB6CC8D092A");

            entity.ToTable("Тарифы");

            entity.Property(e => e.IdТарифа).HasColumnName("id_Тарифа");
            entity.Property(e => e.Название).HasMaxLength(255);
            entity.Property(e => e.Стоимость).HasColumnType("decimal(15, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
