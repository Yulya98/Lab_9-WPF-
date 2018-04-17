using System;
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
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity;
using System.Threading;

namespace Lab_8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UnitOfWork unitOfWork;

        public MainWindow()
        {
            InitializeComponent();
            unitOfWork = new UnitOfWork();
        }

        public void InputInUsersWord()
        {
            unitOfWork.Sql.DeleteFromUsersWords();
            unitOfWork.Save();
            unitOfWork.Sql.AddToUsersWordsFromLists(unitOfWork);
            unitOfWork.Save();
            DataTable table = WorkWithGrid.ShowToGridOsersWords(unitOfWork);
            Grid.ItemsSource = table.DefaultView;
        }

        public void ShowInGridUers()
        {
            DataTable table = WorkWithGrid.ShowUsers(unitOfWork);
            Grid.ItemsSource = table.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowInGridUers();
        }

        public void SaveInDatabaseUsers()
        {
            unitOfWork.Sql.AddToUsersAndCheck(TextName.Text, TextPassword.Text, unitOfWork);
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            SaveInDatabaseUsers();
        }

        public void DeleteFromTableUsers()
        {
                unitOfWork.Sql.DeleteFromUsers();
                unitOfWork.Save();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DeleteFromTableUsers();
        }

        public void SaveToTableWords()
        {
            unitOfWork.Sql.AddToWordsAndCheck(TextWord.Text, TextTrunslate.Text, unitOfWork);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SaveToTableWords();
        }

        public void DeleteFromTableWords()
        {
            unitOfWork.Sql.DeleteFromWords();
            unitOfWork.Save();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DeleteFromTableWords();
        }

        public void ShowToDataGridWords()
        {
            DataTable table = WorkWithGrid.ShowToGrid(unitOfWork);
            Grid.ItemsSource = table.DefaultView;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ShowToDataGridWords();
        }

        public void SortedOnOne2()
        {
            DataTable table = WorkWithGrid.SortedOn1(unitOfWork);
            Grid.ItemsSource = table.DefaultView;
        }

        private void SortedOnOne_Click(object sender, RoutedEventArgs e)
        {
            SortedOnOne2();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            InputInUsersWord();
        }

        public void SortedOnTwoParametrs()
        {
            DataTable table = WorkWithGrid.SortedOn2(unitOfWork);
            Grid.ItemsSource = table.DefaultView;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            SortedOnTwoParametrs();
        }

        public void Redirect()
        {
            QuerysToSql.CheckAndUpdate(inputId.Text, inputUserName.Text, inputPassword.Text, unitOfWork);
            unitOfWork.Save();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Redirect();
        }
    }
}

