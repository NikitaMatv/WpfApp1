using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Classes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person person = new Person();
        Person personred = new Person();

        List<Person> people = new List<Person>()
        {
           new Person() { Name = "John Doe", Age = 30, City = "New York" },
           new Person() { Name = "Jane Doe", Age = 25, City = "London" },
           new Person() { Name = "Peter Smith", Age = 40, City = "Paris" }
        };

        public MainWindow()
        {
            InitializeComponent();
            LBUsers.ItemsSource = people.ToList();
            DataContext = person;

        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            people.Add(person);

            LBUsers.ItemsSource = people.ToList();

            person = new Person();
            DataContext = person;
        }


        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = LBUsers.SelectedItem as Person;
            if (selectedUser == null) 
            {
                return;
            }

            people.Remove(selectedUser);
            LBUsers.ItemsSource = people.ToList();
        }

        private void BRed_Click(object sender, RoutedEventArgs e)
        {
            LBUsers.ItemsSource = people.ToList();

            person = new Person();
            DataContext = person;
        }

        private void LBUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var selectedUser = LBUsers.SelectedItem as Person;
            if (selectedUser == null)
            {
                return;
            }

            personred = selectedUser;
            DataContext = selectedUser;
            
        }


        private void TBAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           if( Regex.IsMatch(e.Text, @"[0-9]")== false)
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, @"[А-яA-z]") == false)
            {
                e.Handled = true;
            }
        }

        private void BJson_Click(object sender, RoutedEventArgs e)
        {
           
            string fileName = "C:\\ddd\\Save.json";
            string jsonString = JsonSerializer.Serialize(people);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
