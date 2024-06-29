namespace BibliotecaDigital.Core.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string GenderId { get; set; }
        public int AutorId { get; set; }
        public int Year { get; set; }

        //Navigation properties
        public Autor? Autor { get; set; }
        public Gender? Gender { get; set; }
    }
}
