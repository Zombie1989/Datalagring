using Datalagring.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Datalagring.Contexts;

class DataContext : DbContext
{
    private readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Zombie\\Desktop\\Datalagring_inlämning\\Datalagring\\Datalagring\\Contexts\\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

    #region constructors
    public DataContext()
    {

    }

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    #endregion

    #region overrides 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString);
    }

    #endregion

    public DbSet<PersonEntity> Persons { get; set; } = null!;
    public DbSet<TaskEntity> Tasks { get; set; } = null!;
}
