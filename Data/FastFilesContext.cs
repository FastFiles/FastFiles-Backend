using Microsoft.EntityFrameworkCore;
using FastFiles.Models;

namespace FastFiles.Data
{
    public class FastFilesContext : DbContext
    {
        public FastFilesContext(DbContextOptions<FastFilesContext> options) : base(options) {}
        
        public DbSet<User> Users { get; set; }

        public DbSet<Files> File {get; set;}  
        public DbSet<Folder> Folders { get; set; }
    }
}