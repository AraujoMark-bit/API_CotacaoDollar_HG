using Newtonsoft.Json;

namespace CotaçãoDolar_API {

    public class Market {


        public Market() {

        this.Currency = new Currency();
        }

        [JsonProperty(PropertyName = "currencies")]
        public Currency Currency { get; set; }

    }
}
