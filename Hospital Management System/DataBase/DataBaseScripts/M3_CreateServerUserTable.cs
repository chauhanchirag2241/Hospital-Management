﻿using FluentMigrator;

namespace DataBase.DataBaseScripts
{
    [Migration(3)]
    public class M3_CreateServerUserTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            string tableName = "serveruser";
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
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

                Create.ForeignKey("FK_serverrole_serverroleid")
                      .FromTable(tableName).ForeignColumn("serverroleid")
                      .ToTable("serverrole").PrimaryColumn("serverroleid");


                Create.ForeignKey("FK_serveruser_createdby")
                      .FromTable(tableName).ForeignColumn("createdby")
                      .ToTable("serveruser").PrimaryColumn("serveruserid");

                Create.ForeignKey("FK_serveruser_updatedby")
                      .FromTable(tableName).ForeignColumn("updatedby")
                      .ToTable("serveruser").PrimaryColumn("serveruserid");
            }
        }
    }
}
