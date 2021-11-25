using NUnit.Framework;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;


namespace UnitTestExample.Test
{
    public class AccountControllerTextFixture
    {
        [
            Test,
            TestCase("jelszo123", false),
            TestCase("valakik@gmail", false),
            TestCase("Valakigmail.com", false),
            TestCase("valaki@gmail.com", true)
            ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            //Arrange
            AccountController ac = new AccountController();

            //Act
            bool l = ac.ValidateEmail(email);

            //Assert
            Assert.AreEqual(expectedResult, l);
        }
        [
            Test,
            TestCase("AzEnKutyamNeveSzamNelkul", false),
            TestCase("CSUPANAGYBETU2", false),
            TestCase("csupakisbetuvanitt2", false),
            TestCase("Rovid22", false),
            TestCase("PerfectPassword4", true)
        ]
        public void TestValidatePassword(string password, bool expectedResult)
        {
            //Arrange
            AccountController ac = new AccountController();

            //Act
            bool actualResult = ac.ValidatePassword(password);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test,
            TestCase("valaki@gmail.com", "Abcdefg123"),
            TestCase("masvalaki@gmail.com", "Jelszavacska1234")
            ]
        public void TestRegisterHappyPath(string email, string password)
        {
            //Arrange
            AccountController ac = new AccountController();

            //Act
            var account = ac.Register(email, password);

            //Assert
            Assert.AreEqual(email, account.Email);
            Assert.AreEqual(password, account.Password);
            Assert.AreNotEqual(Guid.Empty, account.ID);
        }

        [
            Test,
            TestCase("valaki@gmail.com", "AzEnKutyamNeveSzamNelkul"),
            TestCase("valakik@gmail", "PerfectPassword4"),
            TestCase("Valakigmail.com", "PerfectPassword4"),
            TestCase("valaki@gmail.com", "CSUPANAGYBETU2")
            ]

        public void TestRegisterValidateException(string email, string password)
        {
            //Arrange
            AccountController ac = new AccountController();

            //Act
            try
            {
                var account = ac.Register(email, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidationException>(ex);
            }

        }
    }
}
