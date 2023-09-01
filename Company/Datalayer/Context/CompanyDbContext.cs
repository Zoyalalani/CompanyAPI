using Company.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Company.Datalayer.Context
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Combination of firstname, lastname, email address should be unique
            modelBuilder.Entity<Employee>()
                .HasIndex(e => new { e.FirstName, e.LastName, e.Email })
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);


            var department1 = new Department
            {
                DepartmentId = 1,
                Name = "Software Engineering",
            };

            var department2 = new Department
            {
                DepartmentId = 2,
                Name = "Human Resources",
            };

            modelBuilder.Entity<Department>().HasData(department1);
            modelBuilder.Entity<Department>().HasData(department2);

            modelBuilder.Entity<Employee>().HasData(
            new { EmployeeId = 1, FirstName = "Test", LastName = "Employee", MiddleInitial = "A", Email = "Test@EvolentHealth.com", Street = "Street1", City = "Pune", State = "MH", Zip = "411048", DepartmentId = 1, Age = 31 },
            new { EmployeeId = 2, FirstName = "Test2", LastName = "Employee2", MiddleInitial = "B", Email = "Test2@EvolentHealth.com", Street = "Street2", City = "Pune", State = "MH", Zip = "411048", AddressId = 2, DepartmentId = 2, Age = 31 },
            new { EmployeeId = 3, FirstName = "Test3", LastName = "Employee3", MiddleInitial = "C", Email = "Test3@EvolentHealth.com", Street = "Street3", City = "Pune", State = "MH", Zip = "411048", AddressId = 3, DepartmentId = 2, Age = 31 });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Company;Integrated Security=True;");
        }
    }
}
