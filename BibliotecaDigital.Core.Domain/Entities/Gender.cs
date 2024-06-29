namespace BibliotecaDigital.Core.Domain.Entities
{
    public class Gender
    {
        public string Id { get; set; }

        //Navigation properties
        public ICollection<Book>? Books { get; set; }
    }
}
