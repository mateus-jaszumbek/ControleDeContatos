using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ControleDeContatos.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() { }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<ContatoModel> tbcontatos { get; set; }
        public DbSet<UsuarioModel> tbusuarios { get; set; }

    }
}
