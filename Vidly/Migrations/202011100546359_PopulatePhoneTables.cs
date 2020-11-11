namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePhoneTables : DbMigration
    {
        public override void Up()
        {

            Sql("insert into Manufacturers (name) values ('Samsung')");
            Sql("insert into Manufacturers (name) values ('Apple')");
            Sql("insert into Manufacturers (name) values ('Xiami')");
            Sql("insert into Manufacturers (name) values ('Redmi')");


            Sql("insert into Models (name) values ('Note23 Pro')");
            Sql("insert into Models (name) values ('Rino3 Fone 4')");
            Sql("insert into Models (name) values ('iPhone X ')");
            Sql("insert into Models (name) values ('Mate 36 Pro')");
            Sql("insert into Models (name) values ('iPhone 7')");
            Sql("insert into Models (name) values ('Samsung Note 10')");
            Sql("insert into Models (name) values ('Samsung Galaxy S20')");
            Sql("insert into Models (name) values ('OnePlus 8')");




            Sql("insert into Materials (name) values ('Plastic')");
            Sql("insert into Materials (name) values ('Aluminium')");



            Sql("insert into Colors (name) values ('Green')");
            Sql("insert into Colors (name) values ('Whitesmoke')");
            Sql("insert into Colors (name) values ('Red')");
            Sql("insert into Colors (name) values ('Blue')");
            Sql("insert into Colors (name) values ('Night Blue')");
            Sql("insert into Colors (name) values ('Asphalt Grey')");
            Sql("insert into Colors (name) values ('Black')");

            Sql("insert into OS (name) values ('Android 8')");
            Sql("insert into OS(name) values ('Android 8.3')");
            Sql("insert into OS(name) values ('Android 9')");
            Sql("insert into OS(name) values ('Android 12')");
            Sql("insert into OS(name) values ('Android 10')");
            Sql("insert into OS(name) values ('IOS 9')");
            Sql("insert into OS(name) values ('IOS 10')");
            Sql("insert into OS(name) values ('IOS 11')");
            Sql("insert into OS(name) values ('IOS 12S')");
        }
        
        public override void Down()
        {
        }
    }
}
