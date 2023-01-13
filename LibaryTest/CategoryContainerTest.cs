using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryTest
{
    [TestClass]
    public class CategoryContainerTest
    {
        [TestMethod]
        public void AddBookCategory()
        {
            //Arrange

            CategoryContainerMock categorycontainermock = new CategoryContainerMock();

            CategoryContainer categoryContainer = new CategoryContainer(categorycontainermock);
            BookCategory category = new BookCategory()
            {
                ID = 3,
                CategoryID = 1,
                BookID = 4,


            };

           // Act

          var result = categoryContainer.AddBookCategory(category.CategoryID, category.BookID);


           // Assert

            Assert.AreEqual(3, categorycontainermock.bookcategories.Count());
            Assert.AreEqual(category.BookID, categorycontainermock.bookcategories.Last().BookID);
            Assert.AreEqual(category.CategoryID, categorycontainermock.bookcategories.Last().CategoryID);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void DeleteBookCategory()
        {
            //Arrange
            int categoryid = 2;
            CategoryContainerMock categorycontainermock = new CategoryContainerMock();
            CategoryContainer categorycontainer = new CategoryContainer(categorycontainermock);

            //Act
          var deletedcategory=  categorycontainer.RemovecategoriesbyBookId(categoryid);
            var result = categorycontainermock.categories.Count;
            //Assert
            Assert.AreEqual(1, result);
            Assert.IsFalse(!deletedcategory);
       





        }
        [TestMethod]

        public void AddCategory()
        {
            //Arrange
            CategoryContainerMock categoryContainerMock = new CategoryContainerMock();

            CategoryContainer categorycontainer = new CategoryContainer(categoryContainerMock);

            Category category = new Category()
            {
                CategoryID = 3,
                CategoryName = "try"
            };


            //Act

           var addedcategory= categorycontainer.AddCategory(category);
            var result = categoryContainerMock.categories.Count;

            //Assert
            Assert.AreEqual(3, result);
            Assert.AreEqual(category.CategoryName, categoryContainerMock.categories[2].CategoryName);
            Assert.IsTrue(addedcategory);

        }

        [TestMethod]
        public void PreventDoublecategory()
        {
            //Arrange

            CategoryContainerMock categorycontainermock = new CategoryContainerMock();
            CategoryContainer categorycontainer = new CategoryContainer(categorycontainermock);

            //Act
            var categoryname = categorycontainer.PreventDoublecategory("Horror");
           
         
            //Assert

            Assert.IsFalse(categoryname);
            Assert.AreEqual("Horror", categorycontainermock.categories.FirstOrDefault().CategoryName);



        }
    }
}
