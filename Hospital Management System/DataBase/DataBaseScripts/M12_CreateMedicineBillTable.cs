using FluentMigrator;

namespace DataBase.DataBaseScripts
{
    [Migration(12)]
    public class M12_CreateMedicineBillTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            string tableName = "medicinebill";

            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                      .WithColumn("billid").AsInt64().PrimaryKey().Identity()
                      .WithColumn("paitentvisiteid").AsInt64().NotNullable()
                      .WithColumn("paitentid").AsInt64().NotNullable()
                      .WithColumn("medicineid").AsInt64().NotNullable()
                      .WithColumn("medicinename").AsString().NotNullable()
                      .WithColumn("quantity").AsDecimal().NotNullable()
                      .WithColumn("amount").AsDecimal().NotNullable()
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
