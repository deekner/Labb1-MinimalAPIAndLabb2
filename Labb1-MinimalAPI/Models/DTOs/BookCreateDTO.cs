﻿namespace Labb1_MinimalAPI.Models.DTOs
{
    public class BookCreateDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool isAvailable { get; set; }
    }
}
