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
using StudyApplication.Entities;
using StudyApplication.Pages;
using StudyApplication.Windows;


namespace StudyApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        public StudentsPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            StudyEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridStudent.ItemsSource = StudyEntities1.GetContext().Students.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditStudent addOrEditStudent = new AddOrEditStudent(null);
            addOrEditStudent.Show();
        }

        private void BtnRedak_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridStudent.SelectedItem is Student student)
            {
                AddOrEditStudent addOrEditStudent = new AddOrEditStudent(student);
                addOrEditStudent.Show();
            }
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridStudent.SelectedItem is Student student)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить данную запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        StudyEntities1.GetContext().Students.Remove(student);
                        StudyEntities1.GetContext().SaveChanges();
                        Page_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
                        MessageBox.Show("Запись удалена");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void BtnObnov_Click(object sender, RoutedEventArgs e)
        {
            Page_IsVisibleChanged(null, default(DependencyPropertyChangedEventArgs));
        }
    }
}
