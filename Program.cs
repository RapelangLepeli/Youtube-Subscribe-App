using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YoutubeSubscribeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Getting Channel
            List<string> ChannelNames = new List<string>();
            foreach (var Name in GetChanellsFromFile())
            {
                ChannelNames.Add(Name);
            }

            DisplayItemsInList(ChannelNames);
            Confirmation("Channels added to list");

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //log-In
            LogIn(driver);
            Confirmation("Log-in to account");

            //Subscribe to channel
            for (int i = 1; i < ChannelNames.Count; i++)
            {
                SubscribeToChannel(driver, ChannelNames[i]);
                Confirmation("Subscribed to channel ");

            }

            Console.Write("Press any key to exit...");
            Console.ReadKey();

        }
        public static void LogIn(IWebDriver driver)
        {
           
                driver.Url = "https://www.youtube.com";

                IWebElement SigninButton = driver.FindElement(By.XPath("//*[@id=\"buttons\"]/ytd-button-renderer/a"));
                SigninButton.Click();
                Confirmation("Sign-in button clicked");

                string Email = "Enter Email google email address";
                string Pw = "Pass Word";

                IWebElement EmailTextBox = driver.FindElement(By.XPath("//*[@id=\"identifierId\"]"));
                EmailTextBox.SendKeys(Email);
                Confirmation("Email Input");

                IWebElement EmailNextButton = driver.FindElement(By.XPath("//*[@id=\"identifierNext\"]/div/button/span"));
                EmailNextButton.Click();
                Confirmation("Next to Pw button clicked");

                IWebElement PwTextBox = driver.FindElement(By.CssSelector(".whsOnd.zHQkBf"));
                PwTextBox.SendKeys(Pw);
                Confirmation("Pw Input");


                string Id = ".VfPpkd-LgbsSe.VfPpkd-LgbsSe-OWXEXe-k8QpJ.VfPpkd-LgbsSe-OWXEXe-dgl2Hf.nCP5yc.AjY5Oe.DuMIQc.qIypjc.TrZEUc.lw1w4b";
                IWebElement PwNextButton = driver.FindElement(By.CssSelector(Id));
                PwNextButton.Click();
                Confirmation("Log In Button clicked");
            

          
        }
        public static void SubscribeToChannel(IWebDriver driver, string Channel)
        {
                IWebElement SearchBar = driver.FindElement(By.TagName("input"));
                SearchBar.SendKeys(Channel);
                Confirmation("Name entered");

                
                IWebElement SearchButton = driver.FindElement(By.XPath("//*[@id=\"search-icon-legacy\"]"));
                SearchButton.Click();
                Confirmation("Search button clicked");

                IWebElement ChanellAvata = driver.FindElement(By.XPath("//*[@id=\"avatar-section\"]/a"));
                ChanellAvata.Click();
                Confirmation("Channel avata clicked");

                IWebElement VideosTab = driver.FindElement(By.XPath("//*[@id=\"tabsContent\"]/tp-yt-paper-tab[2]/div"));
                VideosTab.Click();
                Confirmation("Changed to videos tab");


            IWebElement sub =  driver.FindElement(By.Id("subscribe-button"));
            sub.Click();
            driver.FindElement(By.Name("Confirmation")).Click();
            Confirmation("Subscribe button clicked");

        }

        public static List<string> GetChanellsFromFile()
        {
            StreamReader reader = new StreamReader("A csv file containing youtube channels(Id,Link,Name)");
            List<List<string>> subs = new List<List<string>>();
            List<string> Names = new List<string>();

            while (!reader.EndOfStream)
            {
                string Line = reader.ReadLine();
                List<string> Fields = Line.Split(',').ToList() ;
                subs.Add(Fields);
            }

            int i = 0;
            foreach (var lstCHannels in subs)
            {
                foreach (var channelName in lstCHannels)
                {
                    i++;
                    if (i == 3)
                    {
                        Names.Add(channelName);
                    }
                }
                i = 0;
            }
            Names.RemoveAt(0);
            return Names;
        }
        public static void DisplayItemsInList(List<string> List)
        {
            foreach (var item in List)
            {
                Console.WriteLine(item);
            }
        }
        public static void Confirmation(string Event)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Event+" successfully.");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(2000);
        }



        /*
         * This is a selenuim project written in C# for chrome.
         * It Allows you to auto subscribe to a list of youtube channels stored in a csv file in a format (channel Id, Channel Link, Channel Name).
         * You can choose which attribute you want to use, but by default the program will use a channel name.
         *
         *When the program runs::
         * The first step is getting the list of channel names,
         * then opens up chrome and navigates to youtube,
         * signs in using your email and password,
         * redirects to youtube and enters the name of the youtube channel,
         * and then auto subscribes.
         * 
         * It Does not use your existing coockies but can be modified to use them.
         * 
         * This is by far, the most inefficient way to auto subscribe to a channel since the website is constantly being updated and technologies used changed.
         * 
         */
        
    }
}
