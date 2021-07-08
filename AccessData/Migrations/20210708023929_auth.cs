using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessData.Migrations
{
    public partial class auth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Administrador" });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "Veterinario" });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 3, "Cliente" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellidos", "DNI", "Email", "Nombres", "Password", "RolId", "Sexo", "Telefono" },
                values: new object[] { 1, "apellidoAdmin", "42132132", "admin@gmail.com", "nombreAdmin", "33354741122871651676713774147412831195", 1, "M", "42573232" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellidos", "DNI", "Email", "Nombres", "Password", "RolId", "Sexo", "Telefono" },
                values: new object[] { 2, "apellidoVeterinario", "42142796", "veterinario@gmail.com", "nombreVeterinario", "2531186424245626725028323047721799563", 2, "F", "42546354" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellidos", "DNI", "Email", "Nombres", "Password", "RolId", "Sexo", "Telefono" },
                values: new object[] { 3, "apellidoCliente", "36235638", "cliente@gmail.com", "nombreCliente", "7313116017113123713422423133601351311481147", 3, "M", "42543532" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
