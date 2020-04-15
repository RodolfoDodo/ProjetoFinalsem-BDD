using Coypu;
using Coypu.Drivers.Selenium;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace google_net.Cammon
{
    public class Basetest
    {
        protected BrowserSession Browser;

        [SetUp]
        public void Setup()
        {
            var sessionConfigurationForChromeHeadless = new SessionConfiguration()
            {
                Driver = typeof(CustomChromeHeadlessWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome,
                // AppHost = "https://specflow.org/", // whatever url you want
                Timeout = TimeSpan.FromSeconds(2)
            };
            Browser = new BrowserSession(sessionConfigurationForChromeHeadless);
            Browser.ResizeTo(1124, 850);

        }

        public void TakeScreenshot()
        {
            var resultId = TestContext.CurrentContext.Test.ID;

            var shortpath = Environment.CurrentDirectory + "\\Screenshots";

            if (!Directory.Exists(shortpath))
            {
                Directory.CreateDirectory(shortpath);
            }

            var screenshots = $"{shortpath}\\{resultId}.png";

            Browser.SaveScreenshot(screenshots);
            TestContext.AddTestAttachment(screenshots);
        }


        [TearDown]
        public void Finish()
        {
            try
            {
                TakeScreenshot();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao captura imagem ;(");
                throw new Exception(e.Message);
            }
            finally
            {
                Browser.Dispose();
            }

        }
    }
 }
