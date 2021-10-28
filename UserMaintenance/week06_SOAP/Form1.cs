using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        #endregion

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Rates;
            chartRateData.DataSource = Rates;
            ProcessXML(GetXML());
            ShowData();
        }

        private string GetXML()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            GetExchangeRatesRequestBody request = new GetExchangeRatesRequestBody();
            request.currencyNames = "EUR";
            request.startDate = "2020-01-01";
            request.endDate = "2020-06-30";
            var response = mnbService.GetExchangeRates(request);
            string result = response.GetExchangeRatesResult;
            //SaveResult(result);
            return result;
        }
        private void ProcessXML(string file)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(file);
            foreach (XmlElement item in xml.DocumentElement)
            {
                RateData rd = new RateData();
                rd.date = DateTime.Parse(item.GetAttribute("date"));
                var s = item.ChildNodes;
                rd.Currency = ((XmlElement)s[0]).GetAttribute("curr");
                decimal a = decimal.Parse(s[0].InnerText);
                decimal unit = decimal.Parse(((XmlElement)s[0]).GetAttribute("unit"));
                if (unit != 0)
                    rd.Value = a / unit;
                Rates.Add(rd);
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
    }
}
