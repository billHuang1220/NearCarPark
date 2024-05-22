using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarPark.DatabaseContext;

public partial class CarParkDbContext : DbContext
{
    public CarParkDbContext()
    {
    }

    public CarParkDbContext(DbContextOptions<CarParkDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarParkAnalyst> CarParkAnalysts { get; set; }

    public virtual DbSet<CarParkInfoDetail> CarParkInfoDetails { get; set; }

    public virtual DbSet<CarParkInfoRealTime> CarParkInfoRealTimes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=carParkDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarParkAnalyst>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CarParkAnalyst");

            entity.Property(e => e.Car6001).HasColumnName("Car_6001");
            entity.Property(e => e.Car6002).HasColumnName("Car_6002");
            entity.Property(e => e.Car6003).HasColumnName("Car_6003");
            entity.Property(e => e.Car6004).HasColumnName("Car_6004");
            entity.Property(e => e.Car6005).HasColumnName("Car_6005");
            entity.Property(e => e.Car6006).HasColumnName("Car_6006");
            entity.Property(e => e.Car6007).HasColumnName("Car_6007");
            entity.Property(e => e.Car6008).HasColumnName("Car_6008");
            entity.Property(e => e.Car6009).HasColumnName("Car_6009");
            entity.Property(e => e.Car6010).HasColumnName("Car_6010");
            entity.Property(e => e.Car6011).HasColumnName("Car_6011");
            entity.Property(e => e.Car6012).HasColumnName("Car_6012");
            entity.Property(e => e.Car6013).HasColumnName("Car_6013");
            entity.Property(e => e.Car6014).HasColumnName("Car_6014");
            entity.Property(e => e.Car6015).HasColumnName("Car_6015");
            entity.Property(e => e.Car6018).HasColumnName("Car_6018");
            entity.Property(e => e.Car6019).HasColumnName("Car_6019");
            entity.Property(e => e.Car6020).HasColumnName("Car_6020");
            entity.Property(e => e.Car6022).HasColumnName("Car_6022");
            entity.Property(e => e.Car6023).HasColumnName("Car_6023");
            entity.Property(e => e.Car6024).HasColumnName("Car_6024");
            entity.Property(e => e.Car6025).HasColumnName("Car_6025");
            entity.Property(e => e.Car6026).HasColumnName("Car_6026");
            entity.Property(e => e.Car6027).HasColumnName("Car_6027");
            entity.Property(e => e.Car6028).HasColumnName("Car_6028");
            entity.Property(e => e.Car6029).HasColumnName("Car_6029");
            entity.Property(e => e.Car6030).HasColumnName("Car_6030");
            entity.Property(e => e.Car6031).HasColumnName("Car_6031");
            entity.Property(e => e.Car6032).HasColumnName("Car_6032");
            entity.Property(e => e.Car6033).HasColumnName("Car_6033");
            entity.Property(e => e.Car6034).HasColumnName("Car_6034");
            entity.Property(e => e.Car6035).HasColumnName("Car_6035");
            entity.Property(e => e.Car6037).HasColumnName("Car_6037");
            entity.Property(e => e.Car6038).HasColumnName("Car_6038");
            entity.Property(e => e.Car6039).HasColumnName("Car_6039");
            entity.Property(e => e.Car6040).HasColumnName("Car_6040");
            entity.Property(e => e.Car6041).HasColumnName("Car_6041");
            entity.Property(e => e.Car6042).HasColumnName("Car_6042");
            entity.Property(e => e.Car6043).HasColumnName("Car_6043");
            entity.Property(e => e.Car6045).HasColumnName("Car_6045");
            entity.Property(e => e.Car7044).HasColumnName("Car_7044");
            entity.Property(e => e.Car7050).HasColumnName("Car_7050");
            entity.Property(e => e.Car7051).HasColumnName("Car_7051");
            entity.Property(e => e.Car7052).HasColumnName("Car_7052");
            entity.Property(e => e.Car7053).HasColumnName("Car_7053");
            entity.Property(e => e.Car7054).HasColumnName("Car_7054");
            entity.Property(e => e.Car7055).HasColumnName("Car_7055");
            entity.Property(e => e.Car7056).HasColumnName("Car_7056");
            entity.Property(e => e.Car7057).HasColumnName("Car_7057");
            entity.Property(e => e.Car7058).HasColumnName("Car_7058");
            entity.Property(e => e.Car7059).HasColumnName("Car_7059");
            entity.Property(e => e.Car7060).HasColumnName("Car_7060");
            entity.Property(e => e.Car7061).HasColumnName("Car_7061");
            entity.Property(e => e.Car7062).HasColumnName("Car_7062");
            entity.Property(e => e.Car7063).HasColumnName("Car_7063");
            entity.Property(e => e.Car7064).HasColumnName("Car_7064");
            entity.Property(e => e.Car7065).HasColumnName("Car_7065");
            entity.Property(e => e.Car7066).HasColumnName("Car_7066");
            entity.Property(e => e.Car7067).HasColumnName("Car_7067");
            entity.Property(e => e.Car7068).HasColumnName("Car_7068");
            entity.Property(e => e.Car7069).HasColumnName("Car_7069");
            entity.Property(e => e.Car7070).HasColumnName("Car_7070");
            entity.Property(e => e.Car7071).HasColumnName("Car_7071");
            entity.Property(e => e.Car7072).HasColumnName("Car_7072");
            entity.Property(e => e.Car7073).HasColumnName("Car_7073");
            entity.Property(e => e.Car7074).HasColumnName("Car_7074");
            entity.Property(e => e.Car7075).HasColumnName("Car_7075");
            entity.Property(e => e.Car7076).HasColumnName("Car_7076");
            entity.Property(e => e.Car7077).HasColumnName("Car_7077");
            entity.Property(e => e.Car7078).HasColumnName("Car_7078");
            entity.Property(e => e.Car7079).HasColumnName("Car_7079");
            entity.Property(e => e.Car7081).HasColumnName("Car_7081");
            entity.Property(e => e.Mb6001).HasColumnName("MB_6001");
            entity.Property(e => e.Mb6002).HasColumnName("MB_6002");
            entity.Property(e => e.Mb6003).HasColumnName("MB_6003");
            entity.Property(e => e.Mb6004).HasColumnName("MB_6004");
            entity.Property(e => e.Mb6005).HasColumnName("MB_6005");
            entity.Property(e => e.Mb6006).HasColumnName("MB_6006");
            entity.Property(e => e.Mb6007).HasColumnName("MB_6007");
            entity.Property(e => e.Mb6008).HasColumnName("MB_6008");
            entity.Property(e => e.Mb6009).HasColumnName("MB_6009");
            entity.Property(e => e.Mb6010).HasColumnName("MB_6010");
            entity.Property(e => e.Mb6011).HasColumnName("MB_6011");
            entity.Property(e => e.Mb6012).HasColumnName("MB_6012");
            entity.Property(e => e.Mb6013).HasColumnName("MB_6013");
            entity.Property(e => e.Mb6014).HasColumnName("MB_6014");
            entity.Property(e => e.Mb6015).HasColumnName("MB_6015");
            entity.Property(e => e.Mb6018).HasColumnName("MB_6018");
            entity.Property(e => e.Mb6019).HasColumnName("MB_6019");
            entity.Property(e => e.Mb6020).HasColumnName("MB_6020");
            entity.Property(e => e.Mb6022).HasColumnName("MB_6022");
            entity.Property(e => e.Mb6023).HasColumnName("MB_6023");
            entity.Property(e => e.Mb6024).HasColumnName("MB_6024");
            entity.Property(e => e.Mb6025).HasColumnName("MB_6025");
            entity.Property(e => e.Mb6026).HasColumnName("MB_6026");
            entity.Property(e => e.Mb6027).HasColumnName("MB_6027");
            entity.Property(e => e.Mb6028).HasColumnName("MB_6028");
            entity.Property(e => e.Mb6029).HasColumnName("MB_6029");
            entity.Property(e => e.Mb6030).HasColumnName("MB_6030");
            entity.Property(e => e.Mb6031).HasColumnName("MB_6031");
            entity.Property(e => e.Mb6032).HasColumnName("MB_6032");
            entity.Property(e => e.Mb6033).HasColumnName("MB_6033");
            entity.Property(e => e.Mb6034).HasColumnName("MB_6034");
            entity.Property(e => e.Mb6035).HasColumnName("MB_6035");
            entity.Property(e => e.Mb6037).HasColumnName("MB_6037");
            entity.Property(e => e.Mb6038).HasColumnName("MB_6038");
            entity.Property(e => e.Mb6039).HasColumnName("MB_6039");
            entity.Property(e => e.Mb6040).HasColumnName("MB_6040");
            entity.Property(e => e.Mb6041).HasColumnName("MB_6041");
            entity.Property(e => e.Mb6042).HasColumnName("MB_6042");
            entity.Property(e => e.Mb6043).HasColumnName("MB_6043");
            entity.Property(e => e.Mb6045).HasColumnName("MB_6045");
            entity.Property(e => e.Mb7044).HasColumnName("MB_7044");
            entity.Property(e => e.Mb7050).HasColumnName("MB_7050");
            entity.Property(e => e.Mb7051).HasColumnName("MB_7051");
            entity.Property(e => e.Mb7052).HasColumnName("MB_7052");
            entity.Property(e => e.Mb7053).HasColumnName("MB_7053");
            entity.Property(e => e.Mb7054).HasColumnName("MB_7054");
            entity.Property(e => e.Mb7055).HasColumnName("MB_7055");
            entity.Property(e => e.Mb7056).HasColumnName("MB_7056");
            entity.Property(e => e.Mb7057).HasColumnName("MB_7057");
            entity.Property(e => e.Mb7058).HasColumnName("MB_7058");
            entity.Property(e => e.Mb7059).HasColumnName("MB_7059");
            entity.Property(e => e.Mb7060).HasColumnName("MB_7060");
            entity.Property(e => e.Mb7061).HasColumnName("MB_7061");
            entity.Property(e => e.Mb7062).HasColumnName("MB_7062");
            entity.Property(e => e.Mb7063).HasColumnName("MB_7063");
            entity.Property(e => e.Mb7064).HasColumnName("MB_7064");
            entity.Property(e => e.Mb7065).HasColumnName("MB_7065");
            entity.Property(e => e.Mb7066).HasColumnName("MB_7066");
            entity.Property(e => e.Mb7067).HasColumnName("MB_7067");
            entity.Property(e => e.Mb7068).HasColumnName("MB_7068");
            entity.Property(e => e.Mb7069).HasColumnName("MB_7069");
            entity.Property(e => e.Mb7070).HasColumnName("MB_7070");
            entity.Property(e => e.Mb7071).HasColumnName("MB_7071");
            entity.Property(e => e.Mb7072).HasColumnName("MB_7072");
            entity.Property(e => e.Mb7073).HasColumnName("MB_7073");
            entity.Property(e => e.Mb7074).HasColumnName("MB_7074");
            entity.Property(e => e.Mb7075).HasColumnName("MB_7075");
            entity.Property(e => e.Mb7076).HasColumnName("MB_7076");
            entity.Property(e => e.Mb7077).HasColumnName("MB_7077");
            entity.Property(e => e.Mb7078).HasColumnName("MB_7078");
            entity.Property(e => e.Mb7079).HasColumnName("MB_7079");
            entity.Property(e => e.Mb7081).HasColumnName("MB_7081");
            entity.Property(e => e.TimeIndex).HasColumnName("Time_Index");
        });

        modelBuilder.Entity<CarParkInfoDetail>(entity =>
        {
            entity.HasKey(e => e.CpId).HasName("PK__CarParkI__7F18CA882FB2CA8F");

            entity.ToTable("CarParkInfoDetail");

            entity.Property(e => e.CpId)
                .ValueGeneratedNever()
                .HasColumnName("CP_ID");
            entity.Property(e => e.CarParkEntryC).HasMaxLength(500);
            entity.Property(e => e.CarParkEntryE)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.CarParkEntryP).HasMaxLength(500);
            entity.Property(e => e.ContactNo).HasMaxLength(500);
            entity.Property(e => e.DsccX)
                .HasMaxLength(500)
                .HasColumnName("DSCC_X");
            entity.Property(e => e.DsccY)
                .HasMaxLength(500)
                .HasColumnName("DSCC_Y");
            entity.Property(e => e.HcarPriceC)
                .HasMaxLength(500)
                .HasColumnName("Hcar_price_C");
            entity.Property(e => e.HcarPriceE)
                .HasMaxLength(500)
                .HasColumnName("Hcar_price_E");
            entity.Property(e => e.HcarPriceP)
                .HasMaxLength(500)
                .HasColumnName("Hcar_price_P");
            entity.Property(e => e.Height).HasMaxLength(500);
            entity.Property(e => e.LcarPriceC)
                .HasMaxLength(500)
                .HasColumnName("Lcar_price_C");
            entity.Property(e => e.LcarPriceE)
                .HasMaxLength(500)
                .HasColumnName("Lcar_price_E");
            entity.Property(e => e.LcarPriceP)
                .HasMaxLength(500)
                .HasColumnName("Lcar_price_P");
            entity.Property(e => e.LocationC).HasMaxLength(500);
            entity.Property(e => e.LocationE)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LocationP).HasMaxLength(500);
            entity.Property(e => e.MotoPriceC)
                .HasMaxLength(500)
                .HasColumnName("moto_price_C");
            entity.Property(e => e.MotoPriceE)
                .HasMaxLength(500)
                .HasColumnName("moto_price_E");
            entity.Property(e => e.MotoPriceP)
                .HasMaxLength(500)
                .HasColumnName("moto_price_P");
            entity.Property(e => e.NameC).HasMaxLength(500);
            entity.Property(e => e.NameE).HasMaxLength(1000);
            entity.Property(e => e.NameP).HasMaxLength(500);
            entity.Property(e => e.RemarkPriceC)
                .HasMaxLength(1000)
                .HasColumnName("remark_price_C");
            entity.Property(e => e.RemarkPriceE)
                .HasMaxLength(1000)
                .HasColumnName("remark_price_E");
            entity.Property(e => e.RemarkPriceP)
                .HasMaxLength(1000)
                .HasColumnName("remark_price_P");
            entity.Property(e => e.SubdistrictC)
                .HasMaxLength(500)
                .HasColumnName("subdistrict_C");
            entity.Property(e => e.SubdistrictE)
                .HasMaxLength(500)
                .HasColumnName("subdistrict_E");
            entity.Property(e => e.SubdistrictP)
                .HasMaxLength(500)
                .HasColumnName("subdistrict_P");
            entity.Property(e => e.XCoords).HasColumnName("X_coords");
            entity.Property(e => e.YCoords).HasColumnName("Y_coords");
            entity.Property(e => e.ZoneC)
                .HasMaxLength(500)
                .HasColumnName("zone_C");
            entity.Property(e => e.ZoneE)
                .HasMaxLength(500)
                .HasColumnName("zone_E");
            entity.Property(e => e.ZoneP)
                .HasMaxLength(500)
                .HasColumnName("zone_P");
        });

        modelBuilder.Entity<CarParkInfoRealTime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarParkI__3214EC274032CA74");

            entity.ToTable("CarParkInfoRealTime");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CarCnt).HasColumnName("Car_CNT");
            entity.Property(e => e.CpEname)
                .HasMaxLength(255)
                .HasColumnName("CP_EName");
            entity.Property(e => e.CpPname)
                .HasMaxLength(255)
                .HasColumnName("CP_PName");
            entity.Property(e => e.MbCnt).HasColumnName("MB_CNT");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Time).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
