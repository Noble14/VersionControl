using NUnit.Framework;
using System;
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
            TestCase("jelszo123",false),
            TestCase("valakik@gmail",false),
            TestCase("Valakigmail.com", false),
            TestCase("valaki@gmail.com",true)
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
    }
}
