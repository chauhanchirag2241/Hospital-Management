using FluentMigrator;

namespace DataBase.DataBaseScripts
{
    [Migration(10)]
    public class M10_CreatePaitentVisiteDetailTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            string tableName = "paitentvisitedetail";

            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                      .WithColumn("paitentvisitedetailid").AsInt64().PrimaryKey().Identity()
                      .WithColumn("paitentvisiteid").AsInt64().NotNullable()
                      .WithColumn("addedbyid").AsInt64().NotNullable()
                      .WithColumn("date").AsDateTime().NotNullable()
                      .WithColumn("discription").AsCustom("varchar(max)").NotNullable()
                      .WithColumn("medicineid").AsCustom("varchar(255)").NotNullable()
                      .WithColumn("reportid").AsInt64().Nullable()
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

                Create.ForeignKey($"FK_{tableName}_paitentvisiteid")
                     .FromTable(tableName).ForeignColumn("paitentvisiteid")
                     .ToTable("paitentvisite").PrimaryColumn("paitentvisiteid");

                Create.ForeignKey($"FK_{tableName}_addedbyid")
                     .FromTable(tableName).ForeignColumn("addedbyid")
                     .ToTable("employee").PrimaryColumn("employeeid");
            }
        }
    }
}
