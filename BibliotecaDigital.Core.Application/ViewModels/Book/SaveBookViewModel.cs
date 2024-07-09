using BibliotecaDigital.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDigital.Core.Application.ViewModels.Book
{
    public  class SaveBookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string GenderId { get; set; }
        public int AutorId { get; set; }
        public int Year { get; set; }
    }
}
