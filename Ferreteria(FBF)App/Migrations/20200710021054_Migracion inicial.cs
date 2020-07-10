using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferreteria_FBF_App.Migrations
{
    public partial class Migracioninicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Cedula = table.Column<string>(maxLength: 11, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Dirección = table.Column<string>(nullable: false),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                name: "Marcas",
                columns: table => new
                {
                    MarcaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: false),
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
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripción = table.Column<string>(nullable: false),
                    Unidad = table.Column<string>(nullable: false),
                    MarcaId = table.Column<int>(nullable: false),
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
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Usuario = table.Column<string>(nullable: false),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                name: "CobroDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    Monto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobroDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CobroDetalle_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentasDetalle",
                columns: table => new
                {
                    VentasDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                table: "Clientes",
                columns: new[] { "ClienteId", "Apellido", "Balance", "Cedula", "Dirección", "Email", "LimiteCredito", "Nombre", "Telefono", "UsuarioId" },
                values: new object[] { 1, "Fermin", 2000.0, "00000000000", "Castillo", "Correo.com", 5000.0, "Oliver", "0000000000", 1 });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Apellido", "Balance", "Cedula", "Dirección", "Email", "LimiteCredito", "Nombre", "Telefono", "UsuarioId" },
                values: new object[] { 2, "Rodriguez", 2000.0, "00000000000", "Castillo", "Correo.com", 5000.0, "Antonio", "0000000000", 1 });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentaId", "CantidadProductos", "ClienteId", "Comentario", "Descuentos", "Fecha", "ITBIS", "Tipo", "Total", "TotalGeneral", "UsuarioId" },
                values: new object[] { 1, 2, 1, null, 0.0, new DateTime(2020, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.0, "Credito", 100.0, 200.0, 1 });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentaId", "CantidadProductos", "ClienteId", "Comentario", "Descuentos", "Fecha", "ITBIS", "Tipo", "Total", "TotalGeneral", "UsuarioId" },
                values: new object[] { 2, 2, 1, null, 0.0, new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.0, "Credito", 100.0, 200.0, 1 });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentaId", "CantidadProductos", "ClienteId", "Comentario", "Descuentos", "Fecha", "ITBIS", "Tipo", "Total", "TotalGeneral", "UsuarioId" },
                values: new object[] { 3, 2, 2, null, 0.0, new DateTime(2020, 7, 9, 22, 10, 53, 896, DateTimeKind.Local).AddTicks(4634), 18.0, "Credito", 100.0, 200.0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CobroDetalle_ClienteId",
                table: "CobroDetalle",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_VentaId",
                table: "VentasDetalle",
                column: "VentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobroDetalle");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "VentasDetalle");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
