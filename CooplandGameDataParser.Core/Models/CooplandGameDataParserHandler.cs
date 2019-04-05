using CooplandGameDataParser.Core.Abstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using CooplandGameDataParser.Core.Args;

namespace CooplandGameDataParser.Core.Models
{
    public class CooplandGameDataParserHandler
        : ICooplandGameDataParserHandler
    {
        readonly string _url = "https://coop-land.ru/base/370-baza-setevyh-i-kooperativnyh-igr-sayta-coop-landru.html";
        readonly IWebDriver _webDriver;

        public event EventHandler<CooplandGameDataArgs> OnGameReceived;

        public CooplandGameDataParserHandler()
        {
            _webDriver = new ChromeDriver(@"E:\");
        }

        public async Task StartAsync()
        {
            _webDriver.Url = _url;

            var selectElement = _webDriver.FindElement(By.Name("example_length"));
            var selectDropButton = new SelectElement(selectElement);
            selectDropButton.SelectByValue("-1");

            var gamesinfo = _webDriver.FindElements(By.XPath(@"//tr[@role='row']//td[@class='dt-gametitle sorting_1']//a"));
            var gameUrls = gamesinfo
                .Select(t => t.GetAttribute("href"))
                .ToArray();

            foreach (var gameurl in gameUrls)
            {
                _webDriver.Url = gameurl;
                 
                var mainGameInfo = _webDriver.FindElements(By.XPath("//div[@class='full-story-content']/span")).FirstOrDefault().Text;

                if (mainGameInfo == null)
                    throw new Exception("mainGameInfo was null, maybe cant get tags");

                var gameInfoArray = mainGameInfo.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                GameInfoModel gameInfoModel = new GameInfoModel
                {
                    Name = _webDriver.FindElement(By.Id("news-title")).Text,
                    Rate = _webDriver.FindElement(By.ClassName("rate")).Text,
                    Release = gameInfoArray[0].Replace("▶Дата выпуска: ", string.Empty),
                    Developer = gameInfoArray[1].Replace("▶ Разработчик, издатель: ", string.Empty),
                    Genre = gameInfoArray[2].Replace("▶Жанр: ", string.Empty),
                    Platform = gameInfoArray[3].Replace("▶Платформа: ", string.Empty),
                    Language = gameInfoArray[4].Replace("▶Язык: ", string.Empty),
                    Description = gameInfoArray.Skip(6).Take(5).Aggregate(string.Empty, (t,k) => t + k)
                };

                OnGameReceived?.Invoke(this, new CooplandGameDataArgs { Game = gameInfoModel });
            }
        }
    }
}
