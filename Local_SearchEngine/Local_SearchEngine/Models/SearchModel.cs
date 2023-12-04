namespace Local_SearchEngine.Models
{
    public class SearchModel
    {
        public string ID { get; set; } // Maps to nchar(10) in the database
        public string Name { get; set; } // Maps to char(10) in the database
        public string Title { get; set; } // Maps to nchar(10) in the database
        public string ServerHost { get; set; } // Maps to nchar(10) in the database, renamed for C# naming conventions
        public string OnlineGames { get; set; } // Maps to nchar(10) in the database, renamed for C# naming conventions
    }

}
