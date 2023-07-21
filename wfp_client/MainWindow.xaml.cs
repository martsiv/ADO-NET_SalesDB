﻿using data_access_sales;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wfp_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SalesManager manager = null;
        public MainWindow()
        {
            InitializeComponent();
            string connStr = ConfigurationManager.ConnectionStrings["ConnectionStringSalesDB"].ConnectionString;
            manager = new(connStr);

            gridSales.ItemsSource = manager.GetAllSales();
            gridSellers.ItemsSource = manager.GetAllSellers();
            gridBuyers.ItemsSource= manager.GetAllBuyers();
        }
    }
}
