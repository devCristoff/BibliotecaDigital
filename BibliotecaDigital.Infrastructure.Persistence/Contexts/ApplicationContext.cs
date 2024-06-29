using BibliotecaDigital.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDigital.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Autor> Autors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region "Table Names"
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Autor>().ToTable("Autors");
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Gender>().ToTable("Genders");
            #endregion

            #region "Primary Keys"
            modelBuilder.Entity<Autor>().HasKey(autor => autor.Id);
            modelBuilder.Entity<Book>().HasKey(book => book.Id);
            modelBuilder.Entity<Gender>().HasKey(gender => gender.Id);
            modelBuilder.Entity<User>().HasKey(user => user.Id);
            #endregion

            #region "Relationships"

            #region Autor
            modelBuilder.Entity<Autor>()
                .HasMany(autor => autor.Books)
                .WithOne(book => book.Autor)
                .HasForeignKey(book => book.AutorId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Book
            modelBuilder.Entity<Gender>()
                .HasMany(gender => gender.Books)
                .WithOne(book => book.Gender)
                .HasForeignKey(book => book.GenderId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #endregion

            #region "Property configurations"

            #region Autor

            modelBuilder.Entity<Autor>().
                Property(autor => autor.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Autor>().
                Property(autor => autor.LastName)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Autor>().
                Property(autor => autor.Birthday)
                .IsRequired();

            #endregion

            #region User

            modelBuilder.Entity<User>().
                Property(user => user.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Autor>().
                Property(user => user.LastName)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<User>().
                Property(user => user.Email)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<User>().
                Property(user => user.Password)
                .IsRequired();

            #endregion

            #region Book

            modelBuilder.Entity<Book>().
                Property(book => book.Title)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Book>().
                Property(book => book.Description)
                .HasMaxLength(350)
                .IsRequired();

            modelBuilder.Entity<Book>().
                Property(book => book.Year)
                .IsRequired();

            #endregion

            #endregion

            #region "Default Data"
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = "Novel" },
                new Gender { Id = "Drama" },
                new Gender { Id = "Business" },
                new Gender { Id = "Personal growth" },
                new Gender { Id = "Literature" }
            );
            #endregion

        }
    }
}
