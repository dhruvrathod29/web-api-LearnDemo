using Microsoft.EntityFrameworkCore;
using web_api_LearnDemo.Models.Domain;

namespace web_api_LearnDemo.Data
{
    public class StudentWebApiDbContext : DbContext
    {
        public StudentWebApiDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
                
        }

        public DbSet<Difficulty> Diffculties { get; set; }  
        public DbSet<Region> Regions { get; set; }   
        public DbSet<Walk> Walks { get; set; }  

        public DbSet<Contact> Contacts { get; set; }    

        
        
    }
}
