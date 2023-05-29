using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Pages
{
    public class RemoveItemPopUp:BasePopUp
    {
        
        private IWebElement yesButton => popup.FindElement(By.XPath(".//div[@class=\"modal-footer\"]/a[text()=\"Yes\"]"));
        private IWebElement noButton => popup.FindElement(By.XPath(".//div[@class=\"modal-footer\"]/a[text()=\"No\"]"));

        public RemoveItemPopUp(IWebDriver driver) : base(driver) { }      
       
        public void ClickYes() => yesButton.Click();        
        public void ClickNo() => noButton.Click();
        
    }
}
