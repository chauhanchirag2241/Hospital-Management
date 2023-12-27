using FluentMigrator;

namespace DataBase.DataBaseScripts
{
    public class M2_CreateServerRoleTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("serverrole")
                .WithColumn("serverroleid").AsInt64().PrimaryKey().Identity()
                .WithColumn("serverrolename").AsString().NotNullable()
                .WithColumn("description").AsString().Nullable()
                .WithColumn("isactive").AsBoolean().NotNullable()
                .WithColumn("createdby").AsInt64().NotNullable()
                .WithColumn("createdon").AsDateTime().NotNullable()
                .WithColumn("updatedby").AsInt64().NotNullable()
                .WithColumn("updatedon").AsDateTime().NotNullable();

        }
    }
}
