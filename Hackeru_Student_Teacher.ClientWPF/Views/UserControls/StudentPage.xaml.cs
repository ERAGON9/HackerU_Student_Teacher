﻿using System;
using System.Collections.Generic;
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

namespace Hackeru_Student_Teacher.ClientWPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for StudentPage.xaml
    /// </summary>
    public partial class StudentPage : UserControl
    {
        public StudentPage()
        {
            InitializeComponent();
        }


        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Handle search as the text changes in the TextBox (instant search)
            string searchText = searchTextBox.Text;
            PerformSearch(searchText);
        }

        private void PerformSearch(string searchText)
        {
            //  search logic here

            // Update the UI with the search results (list box)

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchText = searchTextBox.Text;
            PerformSearch(searchText);
        }

        private void ShowExamsHistory_Click(object sender, RoutedEventArgs e)
        {
            //Content to exam history
        }
    }
}