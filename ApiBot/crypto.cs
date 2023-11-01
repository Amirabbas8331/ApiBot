using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace ApiBot
{
    internal class crypto
    {
        internal static async Task<string> CryptoAsync()
        {
            string str = "";

            using (HttpClient httpClient = new HttpClient())
            {
                string stringApi = "https://api.wallex.ir/v1/currencies/stats";



                HttpResponseMessage response = await httpClient.GetAsync(stringApi);
                if (response.IsSuccessStatusCode)
                {

                    string apiresponse = await response.Content.ReadAsStringAsync();
                    Apirespons apidata = JsonConvert.DeserializeObject<Apirespons>(apiresponse.ToString());

                    List<Result_Items> result_item = apidata.result;

                    foreach (var item in result_item)
                    {
                        str += $"\n{item.rank}:{item.name_en}";

                    }
                }

                return $"please choose the rank of each coin that you want:\n{str}";
            }
        }


        internal static async Task<string> CryptoAsync(int rank)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            using (HttpClient httpClient = new HttpClient())
            {
                string stringApi = "https://api.wallex.ir/v1/currencies/stats";



                HttpResponseMessage response = await httpClient.GetAsync(stringApi);
                if (response.IsSuccessStatusCode)
                {

                    string apiresponse = await response.Content.ReadAsStringAsync();
                    Apirespons apidata = JsonConvert.DeserializeObject<Apirespons>(apiresponse.ToString());

                    List<Result_Items> result_item = apidata.result;

                    if (result_item.Find(x => x.rank == rank) != null)
                    {
                        str += result_item.Find(x => x.rank == rank).price.ToString();
                        str2 += result_item.Find(x => x.rank == rank).type.ToString();
                        str3 += result_item.Find(x => x.rank == rank).created_at.ToString();
                        str4 += result_item.Find(x => x.rank == rank).name_en.ToString();
                    }
                    else
                    {
                        str += "not found";
                        str2 += "not found";
                        str3 += "not found";
                        str4 += "not found";

                    }

                }
                return $"name: {str4}\nprice : {str}\ntype : {str2}\ncreated_at : {str3}";

            }
        }

    }
}
   