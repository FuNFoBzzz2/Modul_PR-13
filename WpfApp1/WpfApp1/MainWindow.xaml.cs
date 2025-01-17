﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private Entities1 dbContext = new Entities1();
        private Order order;
        private ObservableCollection<Order> orders = new ObservableCollection<Order>();

        private void LoadData()
        {
            orders = new ObservableCollection<Order>(dbContext.Order.ToList());
            order = orders.FirstOrDefault();
            Load.DataContext = order;
        }

        private void btnSaveDocument_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                IDocumentPaginatorSource idp = Load.Document;
                pd.PrintDocument(idp.DocumentPaginator, Title);
            }
        }
    }
}
