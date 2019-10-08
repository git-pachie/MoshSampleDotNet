namespace SampleMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateFavoriteFoods : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO[dbo].[CodeFavoriteFoods]([FoodName],[SortOption]) VALUES('Chicken Adobo' ,'0')");
            Sql("INSERT INTO[dbo].[CodeFavoriteFoods]([FoodName],[SortOption]) VALUES('Chicken Inasal' ,'1')");
            Sql("INSERT INTO[dbo].[CodeFavoriteFoods]([FoodName],[SortOption]) VALUES('Pork Adobo' ,'2')");
            Sql("INSERT INTO[dbo].[CodeFavoriteFoods]([FoodName],[SortOption]) VALUES('Pork Nilaga' ,'3')");
            Sql("INSERT INTO[dbo].[CodeFavoriteFoods]([FoodName],[SortOption]) VALUES('Chopsey' ,'4')");
            Sql("INSERT INTO[dbo].[CodeFavoriteFoods]([FoodName],[SortOption]) VALUES('Ginsang Ampalaya' ,'5')");
        }
        
        public override void Down()
        {
        }
    }
}
