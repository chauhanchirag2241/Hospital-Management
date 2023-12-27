using FluentMigrator;

namespace DataBase.DataBaseScripts
{
    public class M3_CreateServerUserTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("serveruser")
                 .WithColumn("serveruserid").AsInt64().PrimaryKey().Identity()
                 .WithColumn("serverroleid").AsInt64().NotNullable()
                 .WithColumn("username").AsString().NotNullable()
                 .WithColumn("password").AsString().NotNullable()
                 .WithColumn("mobileno").AsCustom("varchar(15)").Nullable()
                 .WithColumn("email").AsString().Nullable()
                 .WithColumn("isactive").AsBoolean().NotNullable()
                 .WithColumn("createdby").AsInt64().NotNullable()
                 .WithColumn("createdon").AsDateTime().NotNullable()
                 .WithColumn("updatedby").AsInt64().NotNullable()
                 .WithColumn("updatedon").AsDateTime().NotNullable();


        }
    }
}
