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

namespace week06_SOAP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            method();
        }

        private void method()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            GetExchangeRatesRequestBody request = new GetExchangeRatesRequestBody();
            request.currencyNames = "EUR";
            request.startDate = "2020-01-01";
            request.endDate = "2020-06-30";
            var response = mnbService.GetExchangeRates(request);
            string result = response.GetExchangeRatesResult;
            //SaveResult(result);
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
