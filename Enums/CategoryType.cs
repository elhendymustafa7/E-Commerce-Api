namespace E_Commerce_Api.Enums
{
    public static class CategoryType
    {
        public static HashSet<Category> CategoryTypeList()
        {
            HashSet<Category> x = new HashSet<Category>();
            x.Add(new Category { Name = "Electronics"  , Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "Computers", Description = "Computers Computers Computers Computers" });
            x.Add(new Category { Name = "SmartHome", Description = "SmartHome SmartHome SmartHome SmartHome" });
            x.Add(new Category { Name = "ArtsAndCrafts", Description = "ArtsAndCrafts ArtsAndCrafts ArtsAndCrafts ArtsAndCrafts" });
            x.Add(new Category { Name = "Automotive", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "Baby", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "BeautyAndPersonalCare", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "WomenFashion", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "MenFashion", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "GirlsFashion", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "BoysFashion", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "HealthAndHousehold", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "IndustrialAndScientific", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "Luggage", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "MoviesAndTelevision", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "PetSupplies", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "Software", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "SportsAndOutdoors", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "ToolsAndHomeImprovement", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "ToysAndGames", Description = "Electronics Electronics Electronics Electronics" });
            x.Add(new Category { Name = "VideoGames", Description = $"" });


            return x;
        }
    }
}
