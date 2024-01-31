using FluentMigrator;
namespace DataBase.DataBaseScripts
{
    [Migration(7)]
    public class M7_CreteEmployeeTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            string tableName = "employee";

            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                      .WithColumn("employeeid").AsInt64().PrimaryKey().Identity()
                      .WithColumn("departmentid").AsInt64().NotNullable()
                      .WithColumn("employeetype").AsString().NotNullable()
                      .WithColumn("employeecode").AsCustom("varchar(10)").Nullable()
                      .WithColumn("employeename").AsString().Nullable()
                      .WithColumn("gender").AsCustom("varchar(15)").NotNullable()
                      .WithColumn("mobileno").AsCustom("varchar(15)").NotNullable()
                      .WithColumn("email").AsCustom("varchar(50)").NotNullable()
                      .WithColumn("qualification").AsString().Nullable()
                      .WithColumn("jobspecification").AsString().Nullable()
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
