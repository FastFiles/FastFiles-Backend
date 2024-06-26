using Microsoft.EntityFrameworkCore;
namespace FastFiles.Data
{
    public class FastFilesContext : DbContext
    {
        public FastFilesContext(DbContextOptions<FastFilesContext> options) : base(options)
        {

        }
        //Agregamos los modelos.
    }
}