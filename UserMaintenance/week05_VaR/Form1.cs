using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week05_VaR.Entities;

namespace week05_VaR
{
    public partial class Form1 : Form
    {
        #region Osztályszintű változók

        List<Tick> ListOfTicks;
        PortfolioEntities context = new PortfolioEntities();
        List<PortfolioItem> Portfolio = new List<PortfolioItem>();

        #endregion

        public Form1()
        {
            InitializeComponent();
            ListOfTicks = context.Ticks.ToList();
            dataGridView1.DataSource = ListOfTicks;
            createPortfolio();
        }

        #region Methods

        private void createPortfolio()
        {
            Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;
        }

        #endregion
    }
}
