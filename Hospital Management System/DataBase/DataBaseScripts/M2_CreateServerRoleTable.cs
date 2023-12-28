using FluentMigrator;

namespace DataBase.DataBaseScripts
{
    [Migration(2)]
    public class M2_CreateServerRoleTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            string tableName = "serverrole";
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                      .WithColumn("serverroleid").AsInt64().PrimaryKey().Identity()
                      .WithColumn("serverrolename").AsString().NotNullable()
                      .WithColumn("description").AsString().Nullable()
                      .WithColumn("isactive").AsBoolean().NotNullable()
                      .WithColumn("createdby").AsInt64().NotNullable()
                      .WithColumn("createdon").AsDateTime().NotNullable()
                      .WithColumn("updatedby").AsInt64().NotNullable()
                      .WithColumn("updatedon").AsDateTime().NotNullable();

                //Create.ForeignKey("FK_serveruser_serveruserid")
                //      .FromTable(tableName).ForeignColumn("createdby")
                //      .ToTable("serveruser").PrimaryColumn("serveruserid");

                //Create.ForeignKey("FK_serveruser_serveruserid")
                //      .FromTable(tableName).ForeignColumn("updatedby")
                //      .ToTable("serveruser").PrimaryColumn("serveruserid");
            }
        }
    }
}
