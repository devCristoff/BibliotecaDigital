using BibliotecaDigital.Core.Domain.Common;

namespace BibliotecaDigital.Core.Domain.Entities
{
    public class User : Person
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
