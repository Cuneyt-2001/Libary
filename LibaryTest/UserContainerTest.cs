using Business;
using Interfaces.IDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryTest
{
    [TestClass]
    public class UserContainerTest
    {

        [TestMethod]
        public void AddUserAccount()
        {
            //Arrange

            UserContainerMock userContainerMock = new UserContainerMock();

            UserContainer userContainer = new(userContainerMock);
            User user = new User()
            {
                UserID = 3,
                Email = "admin@gmail.com",
                UserName = "admin",
                Password = "1234567800",
                Rol = true,
                Surname = "administrator"

            };


            //Act

            userContainer.CreateUserAccount(user);
            var result = userContainerMock.users.Count;

            //Assert
            Assert.AreEqual(3, result);
            Assert.AreEqual(user.UserID, userContainerMock.users.Last().UserID);
            Assert.AreEqual(user.Email, userContainerMock.users.Last().Email);
            Assert.AreEqual(user.UserName, userContainerMock.users.Last().UserName);
            Assert.AreEqual(user.Password, userContainerMock.users.Last().Password);
            Assert.AreEqual(user.Surname, userContainerMock.users.Last().Surname);



        }
        [TestMethod]
        public void GetUsers()
        {
            //Arrange

            UserContainerMock userContainerMock = new UserContainerMock();

            UserContainer userContainer = new(userContainerMock);



            //Act

            var users = userContainer.GetAllUsers();

            //Assert
            Assert.AreEqual(userContainerMock.users.Count, users.Count); ;
            for (int i = 0; i < users.Count; i++)
            {
                Assert.AreEqual(users[i].UserID, userContainerMock.users[i].UserID);  
                Assert.AreEqual(users[i].UserName, userContainerMock.users[i].UserName);
                Assert.AreEqual(users[i].Email, userContainerMock.users[i].Email);
                Assert.AreEqual(users[i].Rol, userContainerMock.users[i].Rol);

            }




        }
        [TestMethod]
        public void GetUserType()
        {

            //Arrange

            UserContainerMock userContainerMock = new UserContainerMock();

            UserContainer userContainer = new(userContainerMock);


            //Act
            var result = userContainer.GetUserType("Tim@gmail.com");
            var result2 = userContainer.GetUserType("cuneyt@gmail.com");




            //Assert
            Assert.AreEqual(result, userContainerMock.users[1].Rol);
            Assert.IsFalse(result);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void Getusersbyemail()
        {
            //Arrange

            UserContainerMock userContainerMock = new UserContainerMock();

            UserContainer userContainer = new(userContainerMock);


            //Act
            var result = userContainer.GetUserIdByEmail("Tim@gmail.com");
            var result2 = userContainer.GetUserIdByEmail("cuneyt@gmail.com");



            //Assert
            Assert.AreEqual(result, userContainerMock.users[1].UserID);
            Assert.AreEqual(result2, userContainerMock.users[0].UserID); 
        }


        [TestMethod]

        public void GetUserNameByEmail()
        {
            //Arrange

            UserContainerMock userContainerMock = new UserContainerMock();

            UserContainer userContainer = new(userContainerMock);


            //Act
            var result = userContainer.GetUserNameByEmail("Tim@gmail.com");
            var result2=userContainer.GetUserNameByEmail("cuneyt@gmail.com");


            //Assert
            Assert.AreEqual(result, userContainerMock.users[1].UserName);
            Assert.AreNotEqual(result2, userContainerMock.users[1].UserName);  

        }

        [TestMethod]
        public void Check_User_Information()
        {
            //Arrange

            UserContainerMock userContainerMock = new UserContainerMock();
            User user = new User(userContainerMock)
            {
                Email = "Tim@gmail.com",
                Password = "1234567890"
            };


            //Act
            var result = user.Checkinformation(user.Email, user.Password);


            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(user.Email, userContainerMock.users[1].Email);
            Assert.AreEqual(user.Password, userContainerMock.users[1].Password);    


        }





    }

}
