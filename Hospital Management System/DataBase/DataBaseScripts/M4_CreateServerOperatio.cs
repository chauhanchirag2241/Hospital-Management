using FluentMigrator;

namespace DataBase.DataBaseScripts
{
    [Migration(4)]
    public class M4_CreateServerOperatio : ForwardOnlyMigration
    {
        public override void Up()
        {
            string tableName = "serveroperation";
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                      .WithColumn("serveroperationid").AsInt64().PrimaryKey().Identity()
                      .WithColumn("operationname").AsString().NotNullable()
                      .WithColumn("optype").AsInt64().NotNullable()
                      .WithColumn("parentid").AsInt64().Nullable()
                      .WithColumn("iconname").AsString().NotNullable()
                      .WithColumn("operationindex").AsInt64().Nullable()
                      .WithColumn("description").AsString().Nullable()
                      .WithColumn("href").AsString().NotNullable()
                      .WithColumn("isactive").AsBoolean().NotNullable()
                      .WithColumn("createdby").AsInt64().NotNullable()
                      .WithColumn("createdon").AsDateTime().NotNullable()
                      .WithColumn("updatedby").AsInt64().NotNullable()
                      .WithColumn("updatedon").AsDateTime().NotNullable();

                Create.ForeignKey($"FK_{tableName}_createdby")
                      .FromTable(tableName).ForeignColumn("createdby")
                      .ToTable("serveruser").PrimaryColumn("serveruserid");

                Create.ForeignKey($"FK_{tableName}_updatedby")
                      .FromTable(tableName).ForeignColumn("updatedby")
                      .ToTable("serveruser").PrimaryColumn("serveruserid");
            }
        }
    }
}
