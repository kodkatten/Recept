using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using Recept.Controllers;
using Recept.Helpers;
using Recept.ViewModels;

namespace Recept.UnitTests
{
    [TestFixture]
    public class AddIngredienser
    {
        [Test]
        public void IngredienseStoredInDd()
        {
            var dataBaseSimulator = Substitute.For<IDataBaseSimulator>();
            dataBaseSimulator.StoreData(Arg.Any<IngredientViewModel>()).Returns(true);

            var adminController = new AdminController(dataBaseSimulator);

            var ingredientViewModel = new IngredientViewModel
            {
                Substance = "Coke", Units = Unit.L
            };

            var result = adminController.AddIngredienser(ingredientViewModel) as ViewResult;
            if (result != null)
            {
                var viewModel = (IngredientViewModel)result.ViewData.Model;
                Assert.IsTrue(viewModel.IsStored, "isStored");
                Assert.IsNull(viewModel.Substance,"Substance");
                Assert.AreEqual(viewModel.Units,Unit.Dl);
            }
        }

        [Test]
        public void IngredienseIsNotStoredInDd()
        {
            //Arrange
            var dataBaseSimulator = Substitute.For<IDataBaseSimulator>();
            dataBaseSimulator.StoreData(Arg.Any<IngredientViewModel>()).Returns(false);

            var adminController = new AdminController(dataBaseSimulator);

            var ingredientViewModel = new IngredientViewModel
            {
                Substance = "Coke",
                Units = Unit.L
            };

            //Act
            var result = adminController.AddIngredienser(ingredientViewModel) as ViewResult;
            
            //Assert
            var viewModel = (IngredientViewModel) result.ViewData.Model;
            Assert.IsFalse(viewModel.IsStored, "inNotStored");
            Assert.AreEqual(viewModel.Substance, "Coke", "Substance");
            Assert.AreEqual(viewModel.Units, Unit.L, "units");
        }
        
    }
}
