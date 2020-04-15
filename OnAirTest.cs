using System;
using System.Threading;
using Coypu;
using Coypu.Drivers.Selenium;
using google_net.Cammon;
using NUnit.Framework;

namespace google_net
{
    public class OnAirTest : Basetest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Browser.Visit("https://www.google.com.br/");
            Thread.Sleep(3000);

            Assert.AreEqual("Google", Browser.Title);

        }
    }
}