using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace angularNet.Models
{
    public partial class smart_financeContext : DbContext
    {
        public smart_financeContext()
        {
        }

        public smart_financeContext(DbContextOptions<smart_financeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountCategory> AccountCategory { get; set; }
        public virtual DbSet<AccountChart> AccountChart { get; set; }
        public virtual DbSet<AccountType> AccountType { get; set; }
        public virtual DbSet<BankAccounts> BankAccounts { get; set; }
        public virtual DbSet<BankTransactions> BankTransactions { get; set; }
        public virtual DbSet<CalendarPeriod> CalendarPeriod { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<ExchangeRate> ExchangeRate { get; set; }
        public virtual DbSet<GeneralLedger> GeneralLedger { get; set; }
        public virtual DbSet<Jornal> Jornal { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<SystemDefaults> SystemDefaults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=mikael;database=smart_finance; Trusted_Connection= True;");
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountCategory>(entity =>
            {
                entity.HasKey(e => e.AccCatId);

                entity.ToTable("account_category");

                entity.Property(e => e.AccCatId)
                    .HasColumnName("acc_cat_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<AccountChart>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("account_chart");

                entity.HasIndex(e => e.AccountCode)
                    .HasName("account_code_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.LocationId)
                    .HasName("fk_account_chart_location_idx");

                entity.Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                entity.Property(e => e.AccountCode)
                    .IsRequired()
                    .HasColumnName("account_code")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasColumnName("account_type")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LOCATION_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.SubAccountCode)
                    .HasColumnName("sub_account_code")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.AccountChart)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("fk_account_chart_location");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasKey(e => e.AccTypeId);

                entity.ToTable("account_type");

                entity.HasIndex(e => e.Category)
                    .HasName("fk_account_type_category_idx");

                entity.Property(e => e.AccTypeId)
                    .HasColumnName("acc_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.AccountType)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("fk_account_type_category");
            });

            modelBuilder.Entity<BankAccounts>(entity =>
            {
                entity.HasKey(e => e.BankId);

                entity.ToTable("bank_accounts");

                entity.Property(e => e.BankId).HasColumnName("BANK_ID");

                entity.Property(e => e.BankAccountCode)
                    .HasColumnName("bank_account_code")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.BankCreditAccount)
                    .HasColumnName("bank_credit_account")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.BankDebitAccount)
                    .HasColumnName("bank_debit_account")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<BankTransactions>(entity =>
            {
                entity.ToTable("bank_transactions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasColumnName("amount")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.BankAccountId)
                    .IsRequired()
                    .HasColumnName("bank_account_id")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Reconcield)
                    .HasColumnName("reconcield")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<CalendarPeriod>(entity =>
            {
                entity.HasKey(e => e.PeriodId);

                entity.ToTable("calendar_period");

                entity.Property(e => e.PeriodId).HasColumnName("PERIOD_ID");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.End)
                    .HasColumnName("end")
                    .HasColumnType("date");

                entity.Property(e => e.Start)
                    .HasColumnName("start")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("currency");

                entity.HasIndex(e => e.Abrevation)
                    .HasName("abrevation_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Country)
                    .HasName("country_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CurrencyId).HasColumnName("CURRENCY_ID");

                entity.Property(e => e.Abrevation)
                    .IsRequired()
                    .HasColumnName("abrevation")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Symbole)
                    .IsRequired()
                    .HasColumnName("symbole")
                    .HasColumnType("varchar(10)");
            });

            modelBuilder.Entity<ExchangeRate>(entity =>
            {
                entity.HasKey(e => e.RateId);

                entity.ToTable("exchange_rate");

                entity.Property(e => e.RateId).HasColumnName("RATE_ID");

                entity.Property(e => e.BuyRate).HasColumnName("buy_rate");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasColumnName("CURRENCY_CODE")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaleRate).HasColumnName("sale_rate");
            });

            modelBuilder.Entity<GeneralLedger>(entity =>
            {
                entity.HasKey(e => e.LedgerId);

                entity.ToTable("general_ledger");

                entity.Property(e => e.LedgerId).HasColumnName("LEDGER_ID");

                entity.Property(e => e.AccountId)
                    .IsRequired()
                    .HasColumnName("ACCOUNT_ID")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasColumnName("amount")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Jornal>(entity =>
            {
                entity.ToTable("jornal");

                entity.Property(e => e.JornalId).HasColumnName("JORNAL_ID");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasColumnName("amount")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Reference)
                    .HasColumnName("reference")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.LocationId)
                    .HasColumnName("LOCATION_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.ToTable("suppliers");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("SUPPLIER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("account_number")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.BankAccount)
                    .HasColumnName("bank_account")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.CreditLimit)
                    .HasColumnName("credit_limit")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Discription)
                    .HasColumnName("discription")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.PayableAccount)
                    .HasColumnName("payable_account")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.PayableDiscountAccount)
                    .HasColumnName("payable_discount_account")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.PurchaseAccount)
                    .HasColumnName("purchase_account")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.TaxIncluded)
                    .HasColumnName("tax_included")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<SystemDefaults>(entity =>
            {
                entity.ToTable("system_defaults");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.DataType)
                    .IsRequired()
                    .HasColumnName("data_type")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Length)
                    .IsRequired()
                    .HasColumnName("length")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");
            });
        }
    }
}
