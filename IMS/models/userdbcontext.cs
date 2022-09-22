using Microsoft.EntityFrameworkCore;

namespace IMS.models
{
    public class userdbcontext:DbContext
    {
        public DbSet<usermodel> Register { get; set; }


        public static string ConnectionString
        {
            get;
            set;
        }
        public void BuildConnectionString(string dbstring)
        {
            ConnectionString = dbstring;
        }
        public userdbcontext(DbContextOptions<userdbcontext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<usermodel>(eb =>

            {
                eb.HasKey("USERNAME");

            });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-NO86JCG;Initial Catalog=ganesha;Integrated Security=True");
            //Configuration.GetConnectionString("TO-DB"));
            if (!string.IsNullOrEmpty(ConnectionString)) optionsBuilder.UseSqlServer(ConnectionString);

        }

    }

}

