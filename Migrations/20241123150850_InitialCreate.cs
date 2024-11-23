using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace corvus_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coin",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    str_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    symbol = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    web_slug = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    market_cap = table.Column<long>(type: "bigint", nullable: false),
                    market_cap_rank = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    volume_24h = table.Column<decimal>(type: "numeric", nullable: false),
                    fully_diluted_valuation = table.Column<long>(type: "bigint", nullable: false),
                    circulating_supply = table.Column<decimal>(type: "numeric", nullable: false),
                    total_supply = table.Column<decimal>(type: "numeric", nullable: false),
                    max_supply = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "coin_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coin_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contract_address",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contract_address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "image",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    path = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "link",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_link", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "platform",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_platform", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    password_hash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "historical_data_15min",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coin_id = table.Column<int>(type: "integer", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    market_cap = table.Column<long>(type: "bigint", nullable: false),
                    volume_24h = table.Column<decimal>(type: "numeric", nullable: false),
                    high = table.Column<decimal>(type: "numeric", nullable: false),
                    low = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historical_data_15min", x => x.id);
                    table.ForeignKey(
                        name: "FK_historical_data_15min_coin_coin_id",
                        column: x => x.coin_id,
                        principalTable: "coin",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historical_data_1d",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coin_id = table.Column<int>(type: "integer", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    market_cap = table.Column<long>(type: "bigint", nullable: false),
                    volume_24h = table.Column<decimal>(type: "numeric", nullable: false),
                    high = table.Column<decimal>(type: "numeric", nullable: false),
                    low = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historical_data_1d", x => x.id);
                    table.ForeignKey(
                        name: "FK_historical_data_1d_coin_coin_id",
                        column: x => x.coin_id,
                        principalTable: "coin",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historical_data_1h",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coin_id = table.Column<int>(type: "integer", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    market_cap = table.Column<long>(type: "bigint", nullable: false),
                    volume_24h = table.Column<decimal>(type: "numeric", nullable: false),
                    high = table.Column<decimal>(type: "numeric", nullable: false),
                    low = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historical_data_1h", x => x.id);
                    table.ForeignKey(
                        name: "FK_historical_data_1h_coin_coin_id",
                        column: x => x.coin_id,
                        principalTable: "coin",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historical_data_5min",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coin_id = table.Column<int>(type: "integer", nullable: false),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    market_cap = table.Column<long>(type: "bigint", nullable: false),
                    volume_24h = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historical_data_5min", x => x.id);
                    table.ForeignKey(
                        name: "FK_historical_data_5min_coin_coin_id",
                        column: x => x.coin_id,
                        principalTable: "coin",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "coin_category_relation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coin_id = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coin_category_relation", x => x.id);
                    table.ForeignKey(
                        name: "FK_coin_category_relation_coin_category_category_id",
                        column: x => x.category_id,
                        principalTable: "coin_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_coin_category_relation_coin_coin_id",
                        column: x => x.coin_id,
                        principalTable: "coin",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "coin_contract_address_relation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coin_id = table.Column<int>(type: "integer", nullable: false),
                    contract_address_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coin_contract_address_relation", x => x.id);
                    table.ForeignKey(
                        name: "FK_coin_contract_address_relation_coin_coin_id",
                        column: x => x.coin_id,
                        principalTable: "coin",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_coin_contract_address_relation_contract_address_contract_ad~",
                        column: x => x.contract_address_id,
                        principalTable: "contract_address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "coin_image_relation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coin_id = table.Column<int>(type: "integer", nullable: false),
                    image_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coin_image_relation", x => x.id);
                    table.ForeignKey(
                        name: "FK_coin_image_relation_coin_coin_id",
                        column: x => x.coin_id,
                        principalTable: "coin",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_coin_image_relation_image_image_id",
                        column: x => x.image_id,
                        principalTable: "image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "coin_link_relation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coin_id = table.Column<int>(type: "integer", nullable: false),
                    link_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coin_link_relation", x => x.id);
                    table.ForeignKey(
                        name: "FK_coin_link_relation_coin_coin_id",
                        column: x => x.coin_id,
                        principalTable: "coin",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_coin_link_relation_link_link_id",
                        column: x => x.link_id,
                        principalTable: "link",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "coin_platform_relation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    coin_id = table.Column<int>(type: "integer", nullable: false),
                    platform_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coin_platform_relation", x => x.id);
                    table.ForeignKey(
                        name: "FK_coin_platform_relation_coin_coin_id",
                        column: x => x.coin_id,
                        principalTable: "coin",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_coin_platform_relation_platform_platform_id",
                        column: x => x.platform_id,
                        principalTable: "platform",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_coin_watchlist",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    coin_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_coin_watchlist", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_coin_watchlist_coin_coin_id",
                        column: x => x.coin_id,
                        principalTable: "coin",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_coin_watchlist_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_coin_str_id",
                table: "coin",
                column: "str_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_coin_category_relation_category_id",
                table: "coin_category_relation",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_coin_category_relation_coin_id",
                table: "coin_category_relation",
                column: "coin_id");

            migrationBuilder.CreateIndex(
                name: "IX_coin_contract_address_relation_coin_id",
                table: "coin_contract_address_relation",
                column: "coin_id");

            migrationBuilder.CreateIndex(
                name: "IX_coin_contract_address_relation_contract_address_id",
                table: "coin_contract_address_relation",
                column: "contract_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_coin_image_relation_coin_id",
                table: "coin_image_relation",
                column: "coin_id");

            migrationBuilder.CreateIndex(
                name: "IX_coin_image_relation_image_id",
                table: "coin_image_relation",
                column: "image_id");

            migrationBuilder.CreateIndex(
                name: "IX_coin_link_relation_coin_id",
                table: "coin_link_relation",
                column: "coin_id");

            migrationBuilder.CreateIndex(
                name: "IX_coin_link_relation_link_id",
                table: "coin_link_relation",
                column: "link_id");

            migrationBuilder.CreateIndex(
                name: "IX_coin_platform_relation_coin_id",
                table: "coin_platform_relation",
                column: "coin_id");

            migrationBuilder.CreateIndex(
                name: "IX_coin_platform_relation_platform_id",
                table: "coin_platform_relation",
                column: "platform_id");

            migrationBuilder.CreateIndex(
                name: "IX_historical_data_15min_coin_id",
                table: "historical_data_15min",
                column: "coin_id");

            migrationBuilder.CreateIndex(
                name: "IX_historical_data_1d_coin_id",
                table: "historical_data_1d",
                column: "coin_id");

            migrationBuilder.CreateIndex(
                name: "IX_historical_data_1h_coin_id",
                table: "historical_data_1h",
                column: "coin_id");

            migrationBuilder.CreateIndex(
                name: "IX_historical_data_5min_coin_id",
                table: "historical_data_5min",
                column: "coin_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_coin_watchlist_coin_id",
                table: "user_coin_watchlist",
                column: "coin_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_coin_watchlist_user_id",
                table: "user_coin_watchlist",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coin_category_relation");

            migrationBuilder.DropTable(
                name: "coin_contract_address_relation");

            migrationBuilder.DropTable(
                name: "coin_image_relation");

            migrationBuilder.DropTable(
                name: "coin_link_relation");

            migrationBuilder.DropTable(
                name: "coin_platform_relation");

            migrationBuilder.DropTable(
                name: "historical_data_15min");

            migrationBuilder.DropTable(
                name: "historical_data_1d");

            migrationBuilder.DropTable(
                name: "historical_data_1h");

            migrationBuilder.DropTable(
                name: "historical_data_5min");

            migrationBuilder.DropTable(
                name: "user_coin_watchlist");

            migrationBuilder.DropTable(
                name: "coin_category");

            migrationBuilder.DropTable(
                name: "contract_address");

            migrationBuilder.DropTable(
                name: "image");

            migrationBuilder.DropTable(
                name: "link");

            migrationBuilder.DropTable(
                name: "platform");

            migrationBuilder.DropTable(
                name: "coin");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
