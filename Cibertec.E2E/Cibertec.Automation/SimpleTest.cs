using OpenQA.Selenium.Chrome;

namespace Cibertec.Automation
{
    public static class SimpleTest
    {

        public static void Navigate()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Close();
        }
    }
}
