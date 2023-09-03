using Company.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Company.Datalayer.Context
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }
        public DbSet<Employee> Employee { get; init; }
        public DbSet<Department> Department { get; init; }
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
            new { EmployeeId = 1, FirstName = "Test1", LastName = "Employee1", MiddleInitial = "A", Email = "Test1@EvolentHealth.com", Street = "Street1", City = "Pune", State = "Maharashtra", Zip = "411048", Title = "Senior SE", Salary = 5000.00m,  DepartmentId = 1, Age = 31, WorkLocation = WorkLocation.Hybrid },
            new { EmployeeId = 2, FirstName = "Test2", LastName = "Employee2", MiddleInitial = "B", Email = "Test2@EvolentHealth.com", Street = "Street2", City = "Hyderabad", State = "Telangana", Zip = "500001", Title = "Associate HR", Salary = 6000.00m, DepartmentId = 2, Age = 45 , WorkLocation = WorkLocation.Remote },
            new { EmployeeId = 3, FirstName = "Test3", LastName = "Employee3", MiddleInitial = "C", Email = "Test3@EvolentHealth.com", Street = "Street3", City = "Banglore", State = "Karnataka", Zip = "530068", Title = "Senior HR", Salary = 8000.00m, DepartmentId = 2, Age = 24, WorkLocation = WorkLocation.Hybrid },
            new { EmployeeId = 4, FirstName = "Test4", LastName = "Employee4", MiddleInitial = "D", Email = "Test4@EvolentHealth.com", Street = "Street4", City = "Amaravati", State = "Maharashtra", Zip = "444601", Title = "Architect", Salary = 10000.00m, DepartmentId = 1, Age = 55, WorkLocation = WorkLocation.InOffice });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Company;Integrated Security=True;");
        }
    }
}
