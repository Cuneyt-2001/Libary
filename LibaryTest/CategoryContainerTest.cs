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

            //Act

            categoryContainer.AddBookCategory(category.CategoryID,category.BookID);
            var result = categorycontainermock.bookcategories[2];

            //Assert

            Assert.AreEqual(3,categorycontainermock.bookcategories.Count());
            Assert.AreEqual(category.BookID,categorycontainermock.bookcategories[2].BookID);
            Assert.AreEqual(category.CategoryID,categorycontainermock.bookcategories[2].CategoryID);
        }
        [TestMethod]
        public void DeleteBookCategory()
        {
            //Arrange
            int categoryid = 2;
            CategoryContainerMock categorycontainermock = new CategoryContainerMock();
            CategoryContainer categorycontainer = new CategoryContainer(categorycontainermock);
            
            //Act
            categorycontainer.DeleteBookCategory( categoryid);
            var result = categorycontainermock.categories.Count;    
            //Assert
            Assert.AreEqual(1, result);





        }
        [TestMethod]

        public void AddCategory()
        {
            CategoryContainerMock categoryContainerMock = new CategoryContainerMock();

            CategoryContainer categorycontainer = new CategoryContainer(categoryContainerMock);

            Category category = new Category()
            {
                CategoryID = 3,
                CategoryName ="try"
            };


            //Act

            categorycontainer.AddCategory(category);
            var result = categoryContainerMock.categories.Count;

            //Assert
            Assert.AreEqual(3, result);
            Assert.AreEqual(category.CategoryName, categoryContainerMock.categories[2].CategoryName);


        }
        [TestMethod]
        public void GetBookCategoriesByBookId()
        {
            //Arrange

            CategoryContainerMock categorycontainermock = new CategoryContainerMock();
            CategoryContainer categorycontainer = new CategoryContainer(categorycontainermock);

            //Act
            var categorieslist = categorycontainer.GetBookCategoriesByBookId(4);
            var getbook = categorieslist[0];
            //Assert
            Assert.AreEqual(getbook.CategoryID, categorycontainermock.bookcategories[0].CategoryID);



        }

        [TestMethod]
        public void UpdateBookCategory()
        {
            //Arrange

            CategoryContainerMock categorycontainermock = new CategoryContainerMock();
            CategoryContainer categorycontainer = new CategoryContainer(categorycontainermock);


            BookCategory bookCategory = new BookCategory()
            {
                ID = 3,
                BookID = 4,
                CategoryID = 2,
               
            };
            
            //Act

          categorycontainer.UpdateBookCategory (bookCategory);


            //Assert
            Assert.AreEqual(bookCategory.BookID, categorycontainermock.bookcategories[2].BookID);
            Assert.AreEqual(bookCategory.CategoryID, categorycontainermock.bookcategories[2].CategoryID);





        }

        [TestMethod]
        public void GetAllCategoriesByID()
        {
            //To do
            ////Arrange

            //CategoryContainerMock categorycontainermock = new CategoryContainerMock();
            //CategoryContainer categorycontainer = new CategoryContainer(categorycontainermock);
            //Category category = new Category
            //{
            //    CategoryID = 3,
            //    CategoryName = "Try"
            //};

            ////Act
            //categorycontainer.AddCategory(category);
            ////Assert
            //Assert.AreEqual(category.CategoryID, categorycontainermock.bookcategories[2].CategoryID);



        }
    }
}
