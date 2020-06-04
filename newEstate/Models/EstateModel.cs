using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newEstate.Models
{
    using Newtonsoft.Json;

    public class EstateModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "longtitude")]
        public float Longitude { get; set; }

        [JsonProperty(PropertyName = "latitute")]
        public float Latitute { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "area")]
        public decimal Area { get; set; }

        [JsonProperty(PropertyName = "postingdate")]
        public DateTime PostingDate { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "photopath")]
        public string PhotoPath { get; set; }
    }

    public class SearchInputModel
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }

    public class IndexPageViewModel
    {
        public SearchInputModel SearchInput { get; set; }
        public List<EstateModel> estateModels { get; set; }
    }
}
