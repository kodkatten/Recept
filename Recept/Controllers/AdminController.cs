using System.Web.Mvc;
using Recept.ViewModels;

namespace Recept.Controllers
{
    public interface IDataBaseSimulator
    {
        bool StoreData(IngredientViewModel ingredientViewModel);
    }
    public class AdminController : Controller
    {
        private readonly IDataBaseSimulator _dbSimulator;

        public AdminController(IDataBaseSimulator dbSimulator)
        {
            _dbSimulator = dbSimulator;
        }


        public AdminController()
        {
           
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddIngredienser(IngredientViewModel ingredientViewModel)
        {
            var isStored = _dbSimulator.StoreData(ingredientViewModel);

            if (isStored)
            {
                ingredientViewModel= new IngredientViewModel
                {
                    IsStored = true
                };
            }
            else
            {
                ingredientViewModel.IsStored = false;
            }

            return View(ingredientViewModel);
        }

        private void StoreInToDatabase(IngredientViewModel ingredientViewModel)
        {

        }
    }
}