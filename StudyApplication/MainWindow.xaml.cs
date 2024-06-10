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
using StudyApplication.Pages;
using StudyApplication.Entities;

namespace StudyApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new StudentsPage();
        }

        private void BtnStudents_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new StudentsPage();
        }

        private void BtnSubject_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new SubjectPage();
        }

        private void BtnPlan_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PlanPage();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
