namespace candidatas_library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidatas",
                c => new
                    {
                        pkCandidata = c.Int(nullable: false, identity: true),
                        dtAnioConvocatoria = c.DateTime(nullable: false, precision: 0),
                        sNombreCompleto = c.String(nullable: false, maxLength: 60, unicode: false, storeType: "nvarchar"),
                        dtFechaNacimiento = c.DateTime(nullable: false, precision: 0),
                        sDescripcion = c.String(nullable: false, maxLength: 150, unicode: false, storeType: "nvarchar"),
                        sCorreoElectronico = c.String(nullable: false, maxLength: 40, unicode: false, storeType: "nvarchar"),
                        sCurp = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        sNivelEstudios = c.String(nullable: false, maxLength: 20, unicode: false, storeType: "nvarchar"),
                        sFotografiaRostro = c.String(unicode: false),
                        bStatus = c.Boolean(nullable: false),
                        iLike = c.Int(nullable: false),
                        fkMunicipio_pkMunicipio = c.Int(),
                        fkUsuario_pkUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.pkCandidata)
                .ForeignKey("dbo.Municipios", t => t.fkMunicipio_pkMunicipio)
                .ForeignKey("dbo.Usuarios", t => t.fkUsuario_pkUsuario)
                .Index(t => t.fkMunicipio_pkMunicipio)
                .Index(t => t.fkUsuario_pkUsuario);
            
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        pkMunicipio = c.Int(nullable: false, identity: true),
                        sNombre = c.String(nullable: false, maxLength: 40, unicode: false, storeType: "nvarchar"),
                        sLogotipo = c.String(unicode: false),
                        sDescripcion = c.String(nullable: false, maxLength: 150, unicode: false, storeType: "nvarchar"),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkMunicipio);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        pkUsuario = c.Int(nullable: false, identity: true),
                        iEmpleadoUsuario = c.Int(nullable: false),
                        sPassword = c.String(nullable: false, maxLength: 100, unicode: false, storeType: "nvarchar"),
                        bStatus = c.Boolean(nullable: false),
                        fkRoles_pkRoles = c.Int(),
                    })
                .PrimaryKey(t => t.pkUsuario)
                .ForeignKey("dbo.Roles", t => t.fkRoles_pkRoles)
                .Index(t => t.fkRoles_pkRoles);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        pkRoles = c.Int(nullable: false, identity: true),
                        sNombre = c.String(nullable: false, maxLength: 100, unicode: false, storeType: "nvarchar"),
                        sDescripcion = c.String(nullable: false, maxLength: 150, unicode: false, storeType: "nvarchar"),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkRoles);
            
            CreateTable(
                "dbo.PermisosNegadosRol",
                c => new
                    {
                        pkPermisosNegadosRol = c.Int(nullable: false, identity: true),
                        bStatus = c.Boolean(nullable: false),
                        fkPermiso_pkPermiso = c.Int(),
                        fkRol_pkRoles = c.Int(),
                    })
                .PrimaryKey(t => t.pkPermisosNegadosRol)
                .ForeignKey("dbo.Permisos", t => t.fkPermiso_pkPermiso)
                .ForeignKey("dbo.Roles", t => t.fkRol_pkRoles)
                .Index(t => t.fkPermiso_pkPermiso)
                .Index(t => t.fkRol_pkRoles);
            
            CreateTable(
                "dbo.Permisos",
                c => new
                    {
                        pkPermiso = c.Int(nullable: false, identity: true),
                        sModulo = c.String(nullable: false, maxLength: 40, unicode: false, storeType: "nvarchar"),
                        sDescripcion = c.String(nullable: false, maxLength: 150, unicode: false, storeType: "nvarchar"),
                        bStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.pkPermiso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "fkRoles_pkRoles", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegadosRol", "fkRol_pkRoles", "dbo.Roles");
            DropForeignKey("dbo.PermisosNegadosRol", "fkPermiso_pkPermiso", "dbo.Permisos");
            DropForeignKey("dbo.Candidatas", "fkUsuario_pkUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Candidatas", "fkMunicipio_pkMunicipio", "dbo.Municipios");
            DropIndex("dbo.Usuarios", new[] { "fkRoles_pkRoles" });
            DropIndex("dbo.PermisosNegadosRol", new[] { "fkRol_pkRoles" });
            DropIndex("dbo.PermisosNegadosRol", new[] { "fkPermiso_pkPermiso" });
            DropIndex("dbo.Candidatas", new[] { "fkUsuario_pkUsuario" });
            DropIndex("dbo.Candidatas", new[] { "fkMunicipio_pkMunicipio" });
            DropTable("dbo.Permisos");
            DropTable("dbo.PermisosNegadosRol");
            DropTable("dbo.Roles");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Municipios");
            DropTable("dbo.Candidatas");
        }
    }
}
