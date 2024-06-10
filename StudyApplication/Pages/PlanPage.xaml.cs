using StudyApplication.Entities;
using StudyApplication.Windows;
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


namespace StudyApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для PlanPage.xaml
    /// </summary>
    public partial class PlanPage : Page
    {
        public PlanPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DataGridPlan.ItemsSource = StudyEntities1.GetContext().Plans.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditPlan addOrEditPlan = new AddOrEditPlan(null);
            addOrEditPlan.Show();
        }

        private void BtnRedak_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPlan.SelectedItem is Plan plan)
            {
                AddOrEditPlan addOrEditPlan = new AddOrEditPlan(plan);
                addOrEditPlan.Show();
            }
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPlan.SelectedItem is Plan plan)
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить данную запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (result == MessageBoxResult.Yes)
                    {
                        StudyEntities1.GetContext().Plans.Remove(plan);
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
