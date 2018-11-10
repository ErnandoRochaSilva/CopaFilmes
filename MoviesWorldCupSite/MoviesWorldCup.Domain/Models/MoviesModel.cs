using System;

namespace MoviesWorldCup.Domain.Models
{
    public class MoviesModel
    {
        public String Id { get; set; }
        public String Titulo { get; set; }
        public int Ano { get; set; }
        public Decimal Nota { get; set; }
        public bool Campeao { get; set; }
        public bool Success { get; set; }
        public int Ordem { get; set; } = 0;
    }
}
