using Coypu;
using Coypu.Drivers.Selenium;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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

    }
}
