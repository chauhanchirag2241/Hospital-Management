using FluentMigrator;
namespace DataBase.DataBaseScripts
{
    [Migration(8)]
    public class M8_CreatePaitentTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            string tableName = "paitent";

            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                      .WithColumn("paitentid").AsInt64().PrimaryKey().Identity()
                      .WithColumn("firstname").AsString().NotNullable()
                      .WithColumn("lastname").AsString().NotNullable()
                      .WithColumn("mobileno").AsCustom("varchar(15)").NotNullable()
                      .WithColumn("emergencycontectno").AsCustom("varchar(15)").NotNullable()
                      .WithColumn("birthdate").AsDateTime().NotNullable()
                      .WithColumn("email").AsCustom("varchar(50)").NotNullable()
                      .WithColumn("gender").AsCustom("varchar(10)").NotNullable()
                      .WithColumn("address").AsString().NotNullable()
                      .WithColumn("bloodgroup").AsString().Nullable()
                      .WithColumn("medicalissue").AsString().NotNullable()
                      .WithColumn("doctorid").AsInt64().Nullable()
                      .WithColumn("visitedate").AsDateTime().NotNullable()
                      .WithColumn("timeingshift").AsString().NotNullable()
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
