using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Windows.Forms;

namespace CotaçãoDolar_API {
    public partial class FrmCotacaoDolar : Form {
        

        public FrmCotacaoDolar() {
            InitializeComponent();
            var regiaoInfo = new RegionInfo("pt-BR");
        }

        private void FrmCotacaoDolar_Load(object sender, EventArgs e) {

        }

        private void btnSearch_Click(object sender, EventArgs e) {

            string strURL = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,USD&key=ace2c6e1";

            using (HttpClient client = new HttpClient()) {

                var response = client.GetAsync(strURL).Result;

                if (response.IsSuccessStatusCode) {

                    var result = response.Content.ReadAsStringAsync().Result;

                    Market market = JsonConvert.DeserializeObject<Market>(result);

                    lblBuy.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", market.Currency.Buy);
                    lblSell.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", market.Currency.Sell);
                    lblVar.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:P}", market.Currency.Variation);

                                       

                }

            }
        }
    }
}
