using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using Domen;
using DatabaseCommunication;

namespace Client
{
    public partial class Form1 : Form
    {
       Broker broker = new Broker();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Communication communication = new Communication();
            communication.startClient();
            fillComboProductInfo();                      
        }

        private void fillComboProductInfo()
        {
            List<ProductInfo> productList = broker.getAllProductInfo();

            if (productList.Count != 0)
            {
                foreach (ProductInfo pInfo in productList)
                {
                    if (cmbProductInfo.Items.Contains(pInfo) != true) //if pInfo doesn't exist in the list
                    {
                        cmbProductInfo.Items.Add(pInfo);
                    }
                }
                cmbProductInfo.DisplayMember = "Simbol";          
            }
        }

        private void fillInformationForProduct(ProductInfo pInfo)
        {          
            dgvProductOrders.DataSource = broker.getLastProductOrders(pInfo.Simbol);
            txtDisplayName.Text = pInfo.FullName;
            txtDisplayCurrency.Text = pInfo.Currency;
        }

        //getting average price for the chosen product
        private void getAveragePrice(string simbol)
        {
            decimal avgPrice = 0;
            List<ProductOrder> orderList = broker.getLastProductOrders(simbol);
            //check if there is productOrders in the list to disable devide with zero
            if (orderList.Count != 0)
            {
                foreach (ProductOrder pOrder in orderList)
                {
                    avgPrice += pOrder.Price;
                }
                avgPrice = avgPrice / orderList.Count;
                txtAveragePrice.Text = avgPrice.ToString();
            }
            else
            {
                txtAveragePrice.Text = avgPrice.ToString();
            }           
        }

        //creating cumulative quantity char for the chosen product
        private void createCumulativeQuantityChar(string simbol)
        {
            int cumulativeQunatity = 0;
            chartQuantity.Series.Clear();
            chartQuantity.Series.Add("Quantity");
            List<ProductOrder> orderList = broker.getLastProductOrders(simbol);

            foreach (ProductOrder pOrder in orderList)
            {
                cumulativeQunatity += pOrder.Quantity;
                this.chartQuantity.Series["Quantity"].Points.AddY((double)cumulativeQunatity);
            }
        }

        private void refreshData()
        {
            ProductInfo pInfo = cmbProductInfo.SelectedItem as ProductInfo;
            fillComboProductInfo();
            fillInformationForProduct(pInfo);
            getAveragePrice(pInfo.Simbol);
            createCumulativeQuantityChar(pInfo.Simbol); 
        }



        private void cmbProductInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshData();
        }

        //just test for the event to display data in real time 
        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            if (cmbProductInfo.SelectedItem != null)
            {
                refreshData();
            }
            else
            {
                MessageBox.Show("You must to choose simbol of the product.", "Message");
            }
        }

        private void cmbProductInfo_MouseEnter(object sender, EventArgs e)
        {
            fillComboProductInfo();
        }
    


    }
}
