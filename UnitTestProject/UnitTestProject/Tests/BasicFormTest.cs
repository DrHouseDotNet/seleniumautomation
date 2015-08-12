
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
            var address = "Rua Para";
            var state = "São Paulo";
            var city = "Santos";
            var zip = "11750-415";
            var phone = "+55 013 9.9789-321";
            var email = "nicolas@hotmail.com";
            var age = 21;

            var success = _basicFormPage.CreateNewRegister(name, address, state, city, zip, phone, email, age, "Male", "5", "Small");
            Assert.IsTrue(success);
        }
    }
}
