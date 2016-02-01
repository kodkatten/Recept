using System.Collections.Generic;

namespace Recept.Models
{
    public class Recept
    {
        public string Name { get; set; }
        public string Kcal { get; set; }
        public List<Ingredienser> Ingrediensers { get; set; }
    }
}