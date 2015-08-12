
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using UnitTestProject.Pages;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class BasicFormTest
    {
        readonly BasicFormPage _basicFormPage;

        public BasicFormTest()
        {
            _basicFormPage = new BasicFormPage(new ChromeDriver());
        }

        [TestMethod]
        public void FailNewRegister()
        {
            var success = _basicFormPage.CreateNewRegister("", "", "", "", "", "", "", 0, "", "", "");
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void SuccessNewRegister()
        {
            var name = "Nicolas Takashi";
            var address = "Dorivaldo Francico Lória";
            var state = "São Paulo";
            var city = "Praia Grande";
            var zip = "11750-320";
            var phone = "+55 013 9.8833-0107";
            var email = "nicolas.tcs@hotmail.com";
            var age = 21;

            var success = _basicFormPage.CreateNewRegister(name, address, state, city, zip, phone, email, age, "Male", "5", "Small");
            Assert.IsTrue(success);
        }
    }
}
