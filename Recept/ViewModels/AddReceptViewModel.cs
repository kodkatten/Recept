using Recept.Helpers;

namespace Recept.ViewModels
{
    public class IngredientViewModel
    {
        public string Substance { get; set; }
        public Unit Units { get; set; }
        public bool IsStored { get; set; }
    }
}