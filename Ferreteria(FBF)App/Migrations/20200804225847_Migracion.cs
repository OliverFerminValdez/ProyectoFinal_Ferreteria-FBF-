using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferreteria_FBF_App.Migrations
{
    public partial class Migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(maxLength: 30, nullable: false),
                    Cedula = table.Column<string>(maxLength: 11, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Dirección = table.Column<string>(maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(maxLength: 12, nullable: false),
                    LimiteCredito = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobroId);
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    InventarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuplidorId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TotalInventario = table.Column<double>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.InventarioId);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripción = table.Column<string>(maxLength: 30, nullable: false),
                    Unidad = table.Column<string>(maxLength: 30, nullable: false),
                    MarcaId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    PrecioUnitario = table.Column<double>(nullable: false),
                    Inventario = table.Column<int>(nullable: false),
                    ValorInventario = table.Column<double>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    SuplidorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.SuplidorId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    NivelAcceso = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Usuario = table.Column<string>(maxLength: 30, nullable: false),
                    Contraseña = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    ITBIS = table.Column<double>(nullable: false),
                    Descuentos = table.Column<double>(nullable: false),
                    TotalGeneral = table.Column<double>(nullable: false),
                    Comentario = table.Column<string>(nullable: true),
                    CantidadProductos = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                });

            migrationBuilder.CreateTable(
                name: "InventarioDetalle",
                columns: table => new
                {
                    InventarioDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventarioId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    costo = table.Column<double>(nullable: false),
                    Inventario = table.Column<int>(nullable: false),
                    ValorInventario = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioDetalle", x => x.InventarioDetalleId);
                    table.ForeignKey(
                        name: "FK_InventarioDetalle_Inventarios_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventarios",
                        principalColumn: "InventarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentasDetalle",
                columns: table => new
                {
                    VentasDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasDetalle", x => x.VentasDetalleId);
                    table.ForeignKey(
                        name: "FK_VentasDetalle_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Apellido", "Contraseña", "Email", "NivelAcceso", "Nombre", "Telefono", "Usuario" },
                values: new object[] { 1, "FB", "UwBvAGwAdQBjAGkAbwBuAGUAcwBGAEIA", "FerreteriaFBF@gmail.com", "Administrador", "Soluciones", "8095883505", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_InventarioDetalle_InventarioId",
                table: "InventarioDetalle",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_VentaId",
                table: "VentasDetalle",
                column: "VentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "InventarioDetalle");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Suplidores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "VentasDetalle");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
