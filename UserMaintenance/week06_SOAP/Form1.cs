using System;
using System.ComponentModel;
using System.Windows.Forms;
using week06_SOAP.MnbServiceReference;
using System.IO;
using week06_SOAP.Entitties;
using System.Xml;
using System.Windows.Forms.DataVisualization.Charting;

namespace week06_SOAP
{
    public partial class Form1 : Form
    {
        #region Fields
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<string> Currencies = new BindingList<string>();
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
            GetCurrencies();
            ProcessXmlCurrencies(GetCurrencies());
            cbValuta.DataSource = Currencies;
            dataGridView1.DataSource = Rates;
            chartRateData.DataSource = Rates;
            RefreshData();
        }
        #endregion

        #region Private methods
        private void RefreshData()
        {
            Rates.Clear();
            ProcessXML(GetXML());
            ShowData();
        }

        private string GetXML()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            GetExchangeRatesRequestBody request = new GetExchangeRatesRequestBody();
            request.currencyNames = cbValuta.Text;
            request.startDate = dateTimePickerStart.Value.ToString("yyyy-MM-dd");
            request.endDate = dateTimePickerEnd.Value.ToString("yyyy-MM-dd");
            var response = mnbService.GetExchangeRates(request);
            string result = response.GetExchangeRatesResult;
            //SaveResult(result);
            return result;
        }
        private string GetCurrencies()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            GetCurrenciesRequestBody request = new GetCurrenciesRequestBody();
            var response = mnbService.GetCurrencies(request);
            string result = response.GetCurrenciesResult;
            //SaveResult(result);
            return result;
        }
        private void ProcessXmlCurrencies(string file)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(file);
            foreach (XmlElement item in ((XmlElement)xml.DocumentElement.ChildNodes[0]))
            {
                Currencies.Add(item.InnerText);
            }
        }
        private void ProcessXML(string file)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(file);
            foreach (XmlElement item in xml.DocumentElement)
            {
                RateData rd = new RateData();
                Rates.Add(rd);
                rd.date = DateTime.Parse(item.GetAttribute("date"));
                var s = item.ChildNodes;
                if (s[0] == null)
                {
                    continue;
                }
                rd.Currency = ((XmlElement)s[0]).GetAttribute("curr");
                decimal a = decimal.Parse(s[0].InnerText);
                decimal unit = decimal.Parse(((XmlElement)s[0]).GetAttribute("unit"));
                if (unit != 0)
                    rd.Value = a / unit;                
            }
        }
        private void ShowData()
        {
            var series = chartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "date";
            series.YValueMembers = "Value";
            chartRateData.Legends[0].Enabled = false;
            ChartArea chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisY.IsStartedFromZero = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisX.MajorGrid.Enabled = false;
            series.BorderWidth = 2;
        }

        private void SaveResult(string res)
        {
            SaveFileDialog svf = new SaveFileDialog();
            if (svf.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(svf.FileName))
                {
                    sw.WriteLine(res);
                }
            }
        }
        #endregion

        #region Menu event handlers
        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cbValuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion
    }
}
