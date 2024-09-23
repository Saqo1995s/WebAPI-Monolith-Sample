using System.IO;
using IUniversity.Common.Constants;
using IUniversity.Common.Models;
using IUniversity.Common.Models.Tokens;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IUniversity.Core
{
    public class CoreDbContext : IdentityDbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        #region DbSets

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<CourseAssignment> CourseAssignments { get; set; }
        public virtual DbSet<TeacherAssignment> TeacherAssignments { get; set; }


        //Creating and configuring database context
        #endregion

        #region DbContext Builder

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CoreDbContext>
        {
            public CoreDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(Directory.GetCurrentDirectory() + "/../IUniversity.WebApi/appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<CoreDbContext>();
                var connectionString = configuration.GetConnectionString(DatabaseConstants.WebApiCoreDatabaseName);
                builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("IUniversity.Core"));

                return new CoreDbContext(builder.Options);
            }
        }

        #endregion
    }
}
