using FluentMigrator;

namespace DataBase.DataBaseScripts
{
    [Migration(9)]
    public class M9_CreatePaitentVisiteTable : ForwardOnlyMigration
    {
        public override void Up()
        {

            string tableName = "paitentvisite";

            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                      .WithColumn("paitentvisiteid").AsInt64().PrimaryKey().Identity()
                      .WithColumn("paitentid").AsInt64().NotNullable()
                      .WithColumn("addedbyid").AsInt64().NotNullable()
                      .WithColumn("assigntoid").AsInt64().NotNullable()
                      .WithColumn("date").AsDateTime().NotNullable()
                      .WithColumn("description").AsCustom("varchar(max)").NotNullable()
                      .WithColumn("medicineids").AsCustom("varchar(255)").Nullable()
                      .WithColumn("reportid").AsInt64().Nullable()
                      .WithColumn("status").AsCustom("varchar(50)").NotNullable()
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

                Create.ForeignKey($"FK_{tableName}_paitentid")
                     .FromTable(tableName).ForeignColumn("paitentid")
                     .ToTable("paitent").PrimaryColumn("paitentid");

                Create.ForeignKey($"FK_{tableName}_assigntoid")
                     .FromTable(tableName).ForeignColumn("assigntoid")
                     .ToTable("employee").PrimaryColumn("employeeid");

                Create.ForeignKey($"FK_{tableName}_addedbyid")
                   .FromTable(tableName).ForeignColumn("addedbyid")
                   .ToTable("employee").PrimaryColumn("employeeid");
            }
        }
    }
}
