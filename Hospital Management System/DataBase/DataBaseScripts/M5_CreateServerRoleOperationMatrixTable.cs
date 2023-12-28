using FluentMigrator;

namespace DataBase.DataBaseScripts
{
    [Migration(5)]
    public class M5_CreateServerRoleOperationMatrixTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            string tableName = "serverroleoperationmatrix";
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                      .WithColumn("serverroleoperationmatrixid").AsInt64().PrimaryKey().Identity()
                      .WithColumn("serverroleid").AsInt64().NotNullable()
                      .WithColumn("serveroperationid").AsInt64().NotNullable()
                      .WithColumn("viewop").AsBoolean().NotNullable()
                      .WithColumn("addop").AsBoolean().NotNullable()
                      .WithColumn("editop").AsBoolean().NotNullable()
                      .WithColumn("deleteop").AsBoolean().NotNullable()
                      .WithColumn("isactive").AsBoolean().NotNullable()
                      .WithColumn("createdby").AsInt64().NotNullable()
                      .WithColumn("createdon").AsDateTime().NotNullable()
                      .WithColumn("updatedby").AsInt64().NotNullable()
                      .WithColumn("updatedon").AsDateTime().NotNullable();

                Create.ForeignKey($"FK_{tableName}_serverroleid")
                      .FromTable(tableName).ForeignColumn("serverroleid")
                      .ToTable("serverrole").PrimaryColumn("serverroleid");

                Create.ForeignKey($"FK_{tableName}_serveroperationid")
                      .FromTable(tableName).ForeignColumn("serveroperationid")
                      .ToTable("serveroperation").PrimaryColumn("serveroperationid");

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
