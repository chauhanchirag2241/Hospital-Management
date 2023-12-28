using FluentMigrator;

namespace DataBase.DataBaseScripts
{
    [Migration(6)]
    public class M6_CreateHospitalTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            string tableName = "hospital";

            if(!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                      .WithColumn("hospitalid").AsInt64().PrimaryKey().Identity()
                      .WithColumn("hospitalcode").AsCustom("varchar(10)").NotNullable()
                      .WithColumn("hospitalname").AsString().NotNullable()
                      .WithColumn("shortname").AsCustom("varchar(10)").Nullable()
                      .WithColumn("address").AsString().Nullable()
                      .WithColumn("phone").AsCustom("varchar(15)").NotNullable().Unique()
                      .WithColumn("databasename").AsString().NotNullable()
                      .WithColumn("connectionstring").AsCustom("varchar(max)").NotNullable()
                      .WithColumn("hospitallogo").AsString().Nullable()
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
