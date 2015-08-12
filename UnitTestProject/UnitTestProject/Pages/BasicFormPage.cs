
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace UnitTestProject.Pages
{
    public class BasicFormPage : BasePage
    {
        readonly IWebDriver _webDriver;
        readonly string pageAddress = "https://www.formsite.com/example/5k-10k-registration-form/";

        public BasicFormPage(IWebDriver webDriver)
            : base(webDriver)
        {
            _webDriver = webDriver;
        }

        public bool CreateNewRegister(string name, string address, string state, string city, string zip, string phone, string email, int age, string gender, string race, string tShirSize)
        {
            VisitBase(pageAddress);

            MaxMize();

            var inputName = _webDriver.FindElement(By.Name("RESULT_TextField-2"));
            inputName.SendKeys(name);

            var inputAddress = _webDriver.FindElement(By.Name("RESULT_TextField-3"));
            inputAddress.SendKeys(address);

            var inputState = _webDriver.FindElement(By.Name("RESULT_TextField-4"));
            inputState.SendKeys(state);

            var inputCity = _webDriver.FindElement(By.Name("RESULT_TextField-5"));
            inputCity.SendKeys(city);

            var inputZip = _webDriver.FindElement(By.Name("RESULT_TextField-6"));
            inputZip.SendKeys(zip);

            var inputPhone = _webDriver.FindElement(By.Name("RESULT_TextField-7"));
            inputPhone.SendKeys(phone);

            var inputEmail = _webDriver.FindElement(By.Name("RESULT_TextField-8"));
            inputEmail.SendKeys(email);

            var inputAge = _webDriver.FindElement(By.Name("RESULT_TextField-9"));
            inputAge.SendKeys(age.ToString());

            var genderResult = GenderParse(gender);
            IWebElement inputGender;
            if (genderResult == Gender.Male)
            {
                inputGender = _webDriver.FindElement(By.XPath("//*[@id='RESULT_RadioButton-10_0']"));
                inputGender.Click();
            }

            if (genderResult == Gender.Male)
            {
                inputGender = _webDriver.FindElement(By.XPath("//*[@id='RESULT_RadioButton-10_1']"));
                inputGender.Click();
            }

            var inputRace = _webDriver.FindElement(By.XPath("//*[@id='RESULT_RadioButton-11_1']"));
            inputRace.Click();

            var inputShirtSize = new SelectElement(_webDriver.FindElement(By.Name("RESULT_RadioButton-12")));
            inputShirtSize.SelectByText(tShirSize);

            var sendButton = _webDriver.FindElement(By.Name("Submit"));
            sendButton.Click();

            Thread.Sleep(1000);
            var success = !_webDriver.PageSource.Contains("Response Required");
            Thread.Sleep(1000);
            CloseBrowser();
            return success;
        }

        #region [ private ]
        private Gender GenderParse(string gender)
        {
            Gender genderEnum;
            if (string.IsNullOrEmpty(gender) == false)
            {
                 genderEnum = (Gender)Enum.Parse(typeof(Gender), gender);
                return genderEnum;
            }
            genderEnum = Gender.None;
            return genderEnum;
            
            
        }

        private enum Gender
        {
            Male,
            Female,
            None
        }
        #endregion
    }
}
