using JupiterToysAutomation.Data;
using JupiterToysAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace JupiterToysAutomation.Tests
{
    public class ContactTests:BaseTest
    {
       
        [Test]
        public void ContactSubmissionSucessTest()
        {
            HomePage homepage = new HomePage(_driver);
            ContactPage contactpage = homepage.ClickConact();
            ContactDetails contact = new ContactDetails("Siva","Kemburaju","siva@gmail.com",12345678,"Please add more items to your shop");
            contactpage.FillContactDetails(contact);
            contactpage.ClickContactSubmitButtom();            
            Assert.AreEqual($"Thanks {contact.ForeName}, we appreciate your feedback.", contactpage.GetSubmitSuccessMessage());
        }
    }
}
