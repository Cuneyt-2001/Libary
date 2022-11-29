﻿using Business;
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




        }
        [TestMethod]
        public void GetUserType()
        {

            //Arrange

            UserContainerMock userContainerMock = new UserContainerMock();

            UserContainer userContainer = new(userContainerMock);


            //Act
            var result = userContainer.GetUserType("Tim@gmail.com");




            //Assert
            Assert.AreEqual(result, userContainerMock.users[1].Rol);
        }

        [TestMethod]
        public void Getusersbyemail()
        {
            //Arrange

            UserContainerMock userContainerMock = new UserContainerMock();

            UserContainer userContainer = new(userContainerMock);


            //Act
            var result = userContainer.GetUserIdByEmail("Tim@gmail.com");




            //Assert
            Assert.AreEqual(result, userContainerMock.users[1].UserID);
        }


        [TestMethod]

        public void GetUserNameByEmail()
        {
            //Arrange

            UserContainerMock userContainerMock = new UserContainerMock();

            UserContainer userContainer = new(userContainerMock);


            //Act
            var result = userContainer.GetUserNameByEmail("Tim@gmail.com");


            //Assert
            Assert.AreEqual(result, userContainerMock.users[1].UserName);

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


        }





    }

}
