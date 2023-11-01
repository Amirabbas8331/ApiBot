using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ApiBot;
using System.Globalization;
using System.Diagnostics.Eventing.Reader;
using static ApiBot.nutrition;

namespace ApiBot
{
    internal class Program
    {

        static TelegramBotClient client;
        static int updatesOffset;
        private static CancellationToken cancellationToken;

        static async Task Main()
        {
            client = new TelegramBotClient("6663054450:AAFscrJImgX2qIJzz9xT3ZvwE-w5zZ-UfTU");
            Console.WriteLine("started");
            int polpId;
            while (true)
            {
                var updates = await client.GetUpdatesAsync(updatesOffset);

                foreach (var update in updates)
                {
                    updatesOffset = update.Id + 1;
                    var message = update.Message != null ? update.Message : null;
                    var text = update.Message.Text != null ? update.Message.Text : null;
                    var chatId = update.Message.Chat.Id;
                    var messageid = update.Message.MessageId;
                    int number;
                    int before, before1 = 0;

                    if (message != null && text != null)
                    {
                        if (Regex.IsMatch(text, @"\/[SsTtAaRrTt]"))
                        {

                            await client.SendTextMessageAsync(chatId, $"Hello,welcome", replyToMessageId: messageid);

                        }

                        else if (text.Contains("Hi"))
                        {
                            await client.SendTextMessageAsync(chatId, "Hi", replyToMessageId: messageid);
                        }
                        else if (Regex.IsMatch(text, @"[FfUuCcKk]"))
                        {
                            await client.SendTextMessageAsync(chatId, "please speak correctly", replyToMessageId: messageid);

                        }
                        else if (text == "/crypto")
                        {


                            await client.SendTextMessageAsync(chatId, await crypto.CryptoAsync(), replyToMessageId: messageid);
                        }
                        else if (text == "/nutrition")
                        {
                            HttpClient Apiclient = new HttpClient();
                            string url = "https://api.api-ninjas.com/v1/nutrition?query=";
                            HttpResponseMessage respons = await Apiclient.GetAsync(url);
                            if (respons.IsSuccessStatusCode)
                            {
                                string nutrition = await respons.Content.ReadAsStringAsync();
                                Console.WriteLine(nutrition);
                                Console.WriteLine();
                                Root Deserialize = JsonConvert.DeserializeObject<Root>(nutrition);
                                
                            }
                            await client.SendTextMessageAsync(chatId, await crypto.CryptoAsync(), replyToMessageId: messageid);
                        }

                    }
                    else if ((int.TryParse(text, out number)) && message.MessageId == before1 + 2)
                    {

                        await client.SendTextMessageAsync(chatId, await crypto.CryptoAsync(int.Parse(text)), replyToMessageId: messageid);
                    }
                    else if (Regex.IsMatch(text, @"\/[TtIiMmEe]"))
                    {
                        await client.SendTextMessageAsync(chatId, DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"), replyToMessageId: messageid);

                    }
                    else if (text == "/photo")
                    {
                        Message message1 = await client.SendPhotoAsync
                             (chatId: chatId,
                             photo: "https://unsplash.com/photos/brown-tiger-close-up-photo-8Myh76_3M2U",
                             caption: "<b> Tiger</b>......<i>source</i>: <a href=\"https://unsplash.com\">unsplash</a>",
                             parseMode: ParseMode.Html,
                             cancellationToken: cancellationToken);
                    }
                    else if (text == "/animaton")
                    {
                        Message message2 = await client.SendAnimationAsync
                            (
                            chatId: chatId,
                             animation: "https://www.pexels.com/video/an-octagon-shaped-tunnel-2759484/",
                             caption: "wowww",
                             cancellationToken: cancellationToken
                            );
                    }
                    else if (text == "poll")
                    {
                        polpId = messageid + 1;
                        Console.WriteLine($"\npoll number:{polpId}!");
                        Message pollmessage = await client.SendPollAsync
                            (chatId: chatId,
                            question: "what is your favorite sport?",
                            options: new[]
                            {
                                    "Football",
                                    "Basketball",
                                    "Tenis"
                            },
                            cancellationToken: cancellationToken
                            );
                    }
                    else if (text == "location")
                    {

                        Message pollmessage = await client.SendVenueAsync
                            (chatId: chatId,
                           latitude: 50.0840172f,
                           longitude: 14.418288f,
                           title: "Rome",
                           address: "Rome, via Daqua 8,08089",

                            cancellationToken: cancellationToken
                            );

                    }

                }
            }
        }

    }
}
public class Apirespons
{

    public List<Result_Items> result { get; set; }


}
public class Result_Items
{
    public string key { get; set; }
    public string name { get; set; }
    public string name_en { get; set; }
    public int? rank { get; set; }
    public double? dominance { get; set; }
    public double? volume_24h { get; set; }
    public double? market_cap { get; set; }
    public double? ath { get; set; }
    public double? atl { get; set; }
    public double? ath_change_percentage { get; set; }
    public DateTime? ath_date { get; set; }
    public double? price { get; set; }
    public double? daily_high_price { get; set; }
    public double? daily_low_price { get; set; }
    public double? weekly_high_price { get; set; }
    public double? monthly_high_price { get; set; }
    public double? yearly_high_price { get; set; }
    public double? weekly_low_price { get; set; }
    public double? monthly_low_price { get; set; }
    public double? yearly_low_price { get; set; }
    public double? percent_change_1h { get; set; }
    public double? percent_change_24h { get; set; }
    public double? percent_change_7d { get; set; }
    public double? percent_change_14d { get; set; }
    public double? percent_change_30d { get; set; }
    public double? percent_change_60d { get; set; }
    public double? percent_change_200d { get; set; }
    public double? percent_change_1y { get; set; }
    public double? price_change_24h { get; set; }
    public double? price_change_7d { get; set; }
    public double? price_change_14d { get; set; }
    public double? price_change_30d { get; set; }
    public double? price_change_60d { get; set; }
    public double? price_change_200d { get; set; }
    public double? price_change_1y { get; set; }
    public double? max_supply { get; set; }
    public double? total_supply { get; set; }
    public double? circulating_supply { get; set; }
    public string type { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }
}








































//            await RunInBackground(TimeSpan.FromSeconds(4), () => currency());

//            async Task RunInBackground(TimeSpan time, Action period)
//            {
//                var periodicTimer = new PeriodicTimer(time);
//                while (await periodicTimer.WaitForNextTickAsync())
//                {
//                    period();
//                }
//            }
//            async Task currency()
//            {
//                HttpClient Apiclient = new HttpClient();
//                string url = "https://api.wallex.ir/v1/currencies/stats";
//                HttpResponseMessage respons = await Apiclient.GetAsync(url);
//                if (respons.IsSuccessStatusCode)
//                {
//                    string apirespons = await respons.Content.ReadAsStringAsync();
//                    Console.WriteLine(apirespons);
//                    Console.WriteLine();
//                    Root Deserialize = JsonConvert.DeserializeObject<Root>(apirespons);
//                    List<Data> data = Deserialize.data;
//                    foreach (var item in data)
//                    {
//                        Console.WriteLine($"key:{item.key}");
//                        Console.WriteLine($"name:{item.name}");
//                        Console.WriteLine($"price:{item.price}");
//                        Console.WriteLine($"daily_high_price:{item.daily_high_price}");
//                        Console.WriteLine($"daily_low_price:{item.daily_low_price}");
//                        Console.WriteLine($"percent_change_1h:{item.percent_change_1h}");
//                        Console.WriteLine($"percent_change_24h:{item.percent_change_24h}");
//                        Console.WriteLine($" price_change_200d:{item.price_change_200d}");

//                        double? crypto = item.price + item.percent_change_1h;
//                        double? crypto2 = item.price - item.percent_change_1h;
//                        crypto = item.daily_high_price;
//                        crypto2 = item.daily_low_price;
//                        item.price_change_30d = (item.price_change_7d + item.daily_high_price) * 5;
//                        item.price_change_200d = item.percent_change_200d * item.price;
//                        Console.WriteLine(crypto);
//                        Console.WriteLine(crypto2);
//                        Console.WriteLine(item.price_change_60d);
//                        Console.WriteLine(item.price_change_200d);


//                    }

//                }
//            }
//        }

//    }

//    internal class PeriodicTimer
//    {
//        private TimeSpan time;

//        public PeriodicTimer(TimeSpan time)
//        {
//            this.time = time;
//        }

//        internal Task<bool> WaitForNextTickAsync()
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class Data
//    {
//        public string key { get; set; }
//        public string name { get; set; }
//        public string name_en { get; set; }
//        public int? rank { get; set; }
//        public double? dominance { get; set; }
//        public double? volume_24h { get; set; }
//        public double? market_cap { get; set; }
//        public double? ath { get; set; }
//        public double? atl { get; set; }
//        public double? ath_change_percentage { get; set; }
//        public DateTime? ath_date { get; set; }
//        public double price { get; set; }
//        public double? daily_high_price { get; set; }
//        public double? daily_low_price { get; set; }
//        public double? weekly_high_price { get; set; }
//        public double? monthly_high_price { get; set; }
//        public double? yearly_high_price { get; set; }
//        public double? weekly_low_price { get; set; }
//        public double? monthly_low_price { get; set; }
//        public double? yearly_low_price { get; set; }
//        public double? percent_change_1h { get; set; }
//        public double? percent_change_24h { get; set; }
//        public double? percent_change_7d { get; set; }
//        public double? percent_change_14d { get; set; }
//        public double? percent_change_30d { get; set; }
//        public double? percent_change_60d { get; set; }
//        public double? percent_change_200d { get; set; }
//        public double? percent_change_1y { get; set; }
//        public double? price_change_24h { get; set; }
//        public double? price_change_7d { get; set; }
//        public double? price_change_14d { get; set; }
//        public double? price_change_30d { get; set; }
//        public double? price_change_60d { get; set; }
//        public double? price_change_200d { get; set; }
//        public double? price_change_1y { get; set; }
//        public double? max_supply { get; set; }
//        public double? total_supply { get; set; }
//        public double? circulating_supply { get; set; }
//        public string type { get; set; }
//        public DateTime created_at { get; set; }
//        public DateTime updated_at { get; set; }
//    }

//    public class ResultInfo
//    {
//        public int page { get; set; }
//        public int per_page { get; set; }
//        public int count { get; set; }
//        public int total_count { get; set; }
//    }

//    public class Root
//    {
//        public List<Data> data { get; set; }
//        public string message { get; set; }
//        public bool success { get; set; }
//        public string provider { get; set; }
//        public ResultInfo result_info { get; set; }
//    }

//}
































