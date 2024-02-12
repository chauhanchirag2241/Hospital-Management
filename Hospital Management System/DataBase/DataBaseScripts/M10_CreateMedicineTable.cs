using FluentMigrator;

namespace DataBase.DataBaseScripts
{
    [Migration(10)]
    public class M10_CreateMedicineTable : ForwardOnlyMigration
    {
        public override void Up()
        
        {
            string tableName = "medicine";

            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                      .WithColumn("medicineid").AsInt64().PrimaryKey().Identity()
                      .WithColumn("medicinename").AsString().NotNullable()
                      .WithColumn("amount").AsDecimal().NotNullable()
                      .WithColumn("medicinecount").AsInt64().NotNullable()
                      .WithColumn("discription").AsCustom("varchar(max)")                                            
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
