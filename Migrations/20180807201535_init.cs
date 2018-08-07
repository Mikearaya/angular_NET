using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace angularNet.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account_category",
                columns: table => new
                {
                    acc_cat_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(45)", nullable: false),
                    active = table.Column<string>(type: "varchar(45)", nullable: false, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_category", x => x.acc_cat_id);
                });

            migrationBuilder.CreateTable(
                name: "bank_accounts",
                columns: table => new
                {
                    BANK_ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(45)", nullable: false),
                    bank_account_code = table.Column<string>(type: "varchar(45)", nullable: true),
                    bank_credit_account = table.Column<string>(type: "varchar(45)", nullable: true),
                    bank_debit_account = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank_accounts", x => x.BANK_ID);
                });

            migrationBuilder.CreateTable(
                name: "bank_transactions",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bank_account_id = table.Column<string>(type: "varchar(45)", nullable: false),
                    amount = table.Column<string>(type: "varchar(45)", nullable: false),
                    reconcield = table.Column<sbyte>(type: "tinyint(4)", nullable: false, defaultValueSql: "'0'"),
                    person_id = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank_transactions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "calendar_period",
                columns: table => new
                {
                    PERIOD_ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    start = table.Column<DateTime>(type: "date", nullable: false),
                    end = table.Column<DateTime>(type: "date", nullable: false),
                    active = table.Column<sbyte>(type: "tinyint(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calendar_period", x => x.PERIOD_ID);
                });

            migrationBuilder.CreateTable(
                name: "currency",
                columns: table => new
                {
                    CURRENCY_ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(45)", nullable: false),
                    abrevation = table.Column<string>(type: "varchar(45)", nullable: false),
                    symbole = table.Column<string>(type: "varchar(10)", nullable: false),
                    country = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency", x => x.CURRENCY_ID);
                });

            migrationBuilder.CreateTable(
                name: "exchange_rate",
                columns: table => new
                {
                    RATE_ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CURRENCY_CODE = table.Column<string>(type: "varchar(45)", nullable: false),
                    buy_rate = table.Column<float>(nullable: false),
                    sale_rate = table.Column<float>(nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exchange_rate", x => x.RATE_ID);
                });

            migrationBuilder.CreateTable(
                name: "general_ledger",
                columns: table => new
                {
                    LEDGER_ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ACCOUNT_ID = table.Column<string>(type: "varchar(45)", nullable: false),
                    amount = table.Column<string>(type: "varchar(45)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_general_ledger", x => x.LEDGER_ID);
                });

            migrationBuilder.CreateTable(
                name: "jornal",
                columns: table => new
                {
                    JORNAL_ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    amount = table.Column<string>(type: "varchar(45)", nullable: false),
                    reference = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jornal", x => x.JORNAL_ID);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    LOCATION_ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.LOCATION_ID);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    SUPPLIER_ID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(45)", nullable: false),
                    discription = table.Column<string>(type: "varchar(45)", nullable: true),
                    payable_account = table.Column<string>(type: "varchar(45)", nullable: true),
                    payable_discount_account = table.Column<string>(type: "varchar(45)", nullable: true),
                    purchase_account = table.Column<string>(type: "varchar(45)", nullable: true),
                    tax_included = table.Column<sbyte>(type: "tinyint(4)", nullable: false, defaultValueSql: "'0'"),
                    credit_limit = table.Column<int>(type: "int(11)", nullable: true),
                    account_number = table.Column<string>(type: "varchar(45)", nullable: true),
                    bank_account = table.Column<string>(type: "varchar(45)", nullable: true),
                    active = table.Column<sbyte>(type: "tinyint(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.SUPPLIER_ID);
                });

            migrationBuilder.CreateTable(
                name: "system_defaults",
                columns: table => new
                {
                    ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(45)", nullable: false),
                    category = table.Column<string>(type: "varchar(45)", nullable: false),
                    data_type = table.Column<string>(type: "varchar(45)", nullable: false),
                    length = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_system_defaults", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "account_type",
                columns: table => new
                {
                    acc_type_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    category = table.Column<int>(type: "int(11)", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    active = table.Column<string>(type: "varchar(45)", nullable: false, defaultValueSql: "'1'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_type", x => x.acc_type_id);
                    table.ForeignKey(
                        name: "fk_account_type_category",
                        column: x => x.category,
                        principalTable: "account_category",
                        principalColumn: "acc_cat_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account_chart",
                columns: table => new
                {
                    account_code = table.Column<string>(type: "varchar(30)", nullable: false),
                    sub_account_code = table.Column<string>(type: "varchar(45)", nullable: true),
                    name = table.Column<string>(type: "varchar(45)", nullable: false),
                    active = table.Column<sbyte>(type: "tinyint(4)", nullable: false, defaultValueSql: "'1'"),
                    LOCATION_ID = table.Column<int>(type: "int(11)", nullable: false),
                    ACCOUNT_ID = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    account_type = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_chart", x => x.ACCOUNT_ID);
                    table.ForeignKey(
                        name: "fk_account_chart_location",
                        column: x => x.LOCATION_ID,
                        principalTable: "location",
                        principalColumn: "LOCATION_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "account_code_UNIQUE",
                table: "account_chart",
                column: "account_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_account_chart_location_idx",
                table: "account_chart",
                column: "LOCATION_ID");

            migrationBuilder.CreateIndex(
                name: "fk_account_type_category_idx",
                table: "account_type",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "abrevation_UNIQUE",
                table: "currency",
                column: "abrevation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "country_UNIQUE",
                table: "currency",
                column: "country",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name_UNIQUE",
                table: "currency",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name_UNIQUE",
                table: "location",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_chart");

            migrationBuilder.DropTable(
                name: "account_type");

            migrationBuilder.DropTable(
                name: "bank_accounts");

            migrationBuilder.DropTable(
                name: "bank_transactions");

            migrationBuilder.DropTable(
                name: "calendar_period");

            migrationBuilder.DropTable(
                name: "currency");

            migrationBuilder.DropTable(
                name: "exchange_rate");

            migrationBuilder.DropTable(
                name: "general_ledger");

            migrationBuilder.DropTable(
                name: "jornal");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "system_defaults");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "account_category");
        }
    }
}
