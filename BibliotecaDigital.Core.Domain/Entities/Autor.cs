using BibliotecaDigital.Core.Domain.Common;

namespace BibliotecaDigital.Core.Domain.Entities
{
    public class Autor : Person
    {
        public DateTime Birthday { get; set; }

        //Navigation properties
        public ICollection<Book>? Books { get; set; }
    }
}
