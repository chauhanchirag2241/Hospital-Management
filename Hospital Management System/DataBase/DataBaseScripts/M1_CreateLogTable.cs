using FluentMigrator;

namespace DataBase
{
    [Migration(1)]
    public class AddLogTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            Create.Table("Log")
             .WithColumn("Id").AsInt64().PrimaryKey().Identity()
             .WithColumn("Text").AsString();
        }
    }
}
    