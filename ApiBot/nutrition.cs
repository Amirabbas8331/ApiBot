using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiBot
{
    internal class nutrition
    {
        public class Root
        {
            public string name { get; set; }
            public double calories { get; set; }
            public double serving_size_g { get; set; }
            public double fat_total_g { get; set; }
            public double fat_saturated_g { get; set; }
            public double protein_g { get; set; }
            public int sodium_mg { get; set; }
            public int potassium_mg { get; set; }
            public int cholesterol_mg { get; set; }
            public double carbohydrates_total_g { get; set; }
            public double fiber_g { get; set; }
            public double sugar_g { get; set; }
        }

    }
}