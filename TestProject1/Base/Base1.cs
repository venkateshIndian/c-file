﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Screenshots;

namespace TestProject1.Base
{
     public class Base1
    {

        public ExtentReports extent;
        public ExtentTest test;
        public IWebDriver driver;









        [OneTimeSetUp]
        public void Init()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter("C:\\Users\\BV\\source\\repos\\TestProject1\\TestProject1\\ExtentReports\\Demo.html");
            extent.AttachReporter(htmlReporter);

        }
        [TearDown]
        public void GetResult()
        {



            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;



            if (status == TestStatus.Failed)
            {
                string screenShotPath = GetScreenshot.Capture(driver, "ScreenShotName");
                test.Log(Status.Fail, stackTrace + errorMessage);
                test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(screenShotPath));
            }



        }








        [OneTimeTearDown]
        public void Endreport()
        {
            driver.Quit();
            extent.Flush();

        }
    }




}

