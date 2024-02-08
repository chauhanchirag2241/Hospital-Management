using FluentMigrator;


namespace DataBase.DataBaseScripts
{
    [Migration(11)]
    public class M11_CreateDepartmentTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            string tableName = "department";

            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                      .WithColumn("departmentid").AsInt64().PrimaryKey().Identity()
                      .WithColumn("departmentname").AsInt64().NotNullable()
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
