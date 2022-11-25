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
    public class ReviewContainerTest
    {

        [TestMethod]
        public void AddReview()
        {
            //Arrange
            ReviewContainerMock reviewContainerMock=new ReviewContainerMock();
            ReviewContainer reviewContainer=new(reviewContainerMock);
            Review_ review = new Review_()
            {
               ReviewID = 3,
               Review="Iedereen moet lezen!!"

            };
            //Act

         var result  = reviewContainer.AddReview(review);
          
            //Assert

            Assert.IsTrue(result);
            Assert.AreEqual(review.ReviewID,reviewContainerMock.reviews.Last().ReviewID);
            Assert.AreEqual("Iedereen moet lezen!!", reviewContainerMock.reviews.Last().Review);   
        



        }





    }
}
