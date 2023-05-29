using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Framework
{
    public class Report
    {
        public static void LogStep(string step)
        {
            Console.WriteLine(step);
        }
        public static void TakeScreenShot(IWebDriver driver)
        {

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Temp\Screenshot\filename.png", ScreenshotImageFormat.Png);
        }

    }
}
