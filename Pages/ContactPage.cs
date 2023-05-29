using JupiterToysAutomation.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Pages
{
    public class ContactPage:BasePage
    {

        public ContactPage() { }

        public ContactPage(IWebDriver _driver) 
        {
            this._driver = _driver;
        }

        IWebElement txtForename => _driver.FindElement(By.Id("forename"));
        IWebElement txtSurname => _driver.FindElement(By.Id("surname"));
        IWebElement txtEmail => _driver.FindElement(By.Id("email"));
        IWebElement txtTelephone => _driver.FindElement(By.Id("telephone"));
        IWebElement txtMessage => _driver.FindElement(By.Id("message"));
        IWebElement bntSubmit => _driver.FindElement(By.ClassName("btn-contact"));
        IWebElement foreNameErrorMessage => _driver.FindElement(By.Id("forename-err"));
        IWebElement surNameErrorMessage => _driver.FindElement(By.Id("email-err"));
        IWebElement messageErrorMessage => _driver.FindElement(By.Id("message-err"));
        IWebElement submitSuccessMessage => _driver.FindElement(By.CssSelector("div.alert-success"));


        public void FillContactDetails(ContactDetails contact)
        {
            SetForeName(contact.ForeName);
            SetSurName(contact.SurName);
            SetEmail(contact.Email);
            SetMessage(contact.Message);
        }

        //One Line method
        public void SetForeName(string forename)=> txtForename.SendKeys(forename);
        
        public void SetSurName(String surName) => txtSurname.SendKeys(surName);
       
        public void SetEmail(String email) => txtEmail.SendKeys(email);

        public void SetTelephone(int telephone) => txtTelephone.SendKeys(telephone.ToString());

        public void SetMessage(String message) => txtMessage.SendKeys(message);
       
        public String GetForeNameError() => foreNameErrorMessage.Text;
        public String GetEmailError() => surNameErrorMessage.Text;
        public String GetMessageError() => messageErrorMessage.Text;

        public String GetSubmitSuccessMessage() => submitSuccessMessage.Text;

        public void ClickContactSubmitButtom()=> bntSubmit.Click();
   
       
    }
}
