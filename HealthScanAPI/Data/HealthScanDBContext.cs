using HealthScanAPI.Models.DatabaseModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Reflection.Emit;

public class HealthScanDBContext : DbContext
{
    public HealthScanDBContext() : base("name=HealthScanDB")
    {
        this.Configuration.LazyLoadingEnabled = false;
        this.Configuration.ProxyCreationEnabled = false;
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        CorporateEntityMapping(modelBuilder);
        BranchEntityMapping(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private void CorporateEntityMapping(DbModelBuilder modelBuilder)
    {
        var entity = modelBuilder.Entity<Corporate>();

        entity.ToTable("tblCorporate", "arabihra_hra");

        entity.HasKey(e => e.CorporateName);

        entity.Property(e => e.Cid)
            .HasColumnName("CID")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        entity.Property(e => e.CorporateName)
            .HasColumnName("CorporateName")
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.CorporateId)
            .HasColumnName("CorporateID")
            .IsRequired()
            .HasMaxLength(10);

        entity.Property(e => e.CorporateAddress)
            .HasColumnName("CorporateAddress")
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.CorporateCity)
            .HasColumnName("Corporatecity")
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.CorporateState)
            .HasColumnName("Corporatestate")
            .HasMaxLength(50);

        entity.Property(e => e.CorporatePin)
            .HasColumnName("Corporatepin")
            .HasMaxLength(50);

        entity.Property(e => e.CorporateCountry)
            .HasColumnName("CorporateCountry")
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.CorporateContactPerson)
            .HasColumnName("Corporatecperson")
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.CorporatePhone)
            .HasColumnName("Corporatephone")
            .HasMaxLength(50);

        entity.Property(e => e.CorporateMobile)
            .HasColumnName("Corporatemobile")
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.CorporateEmail)
            .HasColumnName("Corporateemail")
            .HasMaxLength(50);

        entity.Property(e => e.CorporateWebsite)
            .HasColumnName("Corporatewebsite")
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.CorporateScanType)
            .HasColumnName("Corporatescantype")
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.CorporateDays)
            .HasColumnName("CorporateDays")
            .IsRequired();

        entity.Property(e => e.CorporateStatus)
            .HasColumnName("Corporatestatus");

        entity.Property(e => e.CreateDate)
            .HasColumnName("Createdate");

        entity.Property(e => e.Remarks)
            .HasColumnName("Remarks")
            .HasMaxLength(50);
    }

    private void BranchEntityMapping(DbModelBuilder modelBuilder)
    {
        var entity = modelBuilder.Entity<Branch>();

        entity.ToTable("tblBranch", "arabihra_hra");

        entity.HasKey(e => e.BranchId);

        entity.Property(e => e.BranchId)
            .HasColumnName("BranchID")
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.BranchName)
            .HasColumnName("BranchName")
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.CorporateId)
            .HasColumnName("CorporateID")
            .IsRequired()
            .HasMaxLength(10);

        entity.Property(e => e.BranchAddress)
            .HasColumnName("BranchAddress")
            .HasMaxLength(100);

        entity.Property(e => e.BranchCity)
            .HasColumnName("Branchcity")
            .HasMaxLength(50);

        entity.Property(e => e.BranchState)
            .HasColumnName("Branchstate")
            .HasMaxLength(50);

        entity.Property(e => e.BranchPin)
            .HasColumnName("Branchpin")
            .HasMaxLength(50);

        entity.Property(e => e.BranchCountry)
            .HasColumnName("BranchCountry")
            .HasMaxLength(50);

        entity.Property(e => e.BranchPerson)
            .HasColumnName("Branchperson")
            .HasMaxLength(50);

        entity.Property(e => e.BranchPhone)
            .HasColumnName("Branchphone")
            .HasMaxLength(50);

        entity.Property(e => e.BranchMobile)
            .HasColumnName("Branchmobile")
            .HasMaxLength(50);

        entity.Property(e => e.BranchEmail)
            .HasColumnName("Branchemail")
            .HasMaxLength(50);

        entity.Property(e => e.BranchScanType)
            .HasColumnName("Branchscantype")
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.BranchDays)
            .HasColumnName("BranchDays")
            .IsRequired();

        entity.Property(e => e.BranchStatus)
            .HasColumnName("Branchstatus");

        entity.Property(e => e.CreateDate)
            .HasColumnName("Createdate");

        entity.Property(e => e.Remarks)
            .HasColumnName("Remarks")
            .HasMaxLength(50);

        entity.Property(e => e.EventType)
            .HasColumnName("EventType")
            .HasMaxLength(50);

        entity.Property(e => e.EventDate)
            .HasColumnName("EventDate")
            .HasMaxLength(10);

        entity.HasRequired<Corporate>(b => b.Corporate)
            .WithMany(c => c.Branches)
            .HasForeignKey(b => b.CorporateId)
            .WillCascadeOnDelete(false);
    }

    public DbSet<Corporate> Corporates { get; set; }
    public DbSet<Branch> Branches { get; set; } 
}