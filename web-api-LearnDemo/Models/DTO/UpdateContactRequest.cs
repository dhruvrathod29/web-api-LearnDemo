﻿namespace web_api_LearnDemo.Models.DTO
{
    public class UpdateContactRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
    }
}
