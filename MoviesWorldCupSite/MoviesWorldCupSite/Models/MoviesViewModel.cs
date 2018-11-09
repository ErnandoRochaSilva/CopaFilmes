using System;

namespace MoviesWorldCupSite.Models
{
    public class MoviesViewModel
    {
        public String Id { get; set; }
        public String Titulo { get; set; }
        public int Ano { get; set; }
        public Decimal Nota { get; set; }
        public bool Campeao { get; set; }
    }
}