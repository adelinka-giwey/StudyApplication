using StudyApplication.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudyApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditPlan.xaml
    /// </summary>

    public partial class AddOrEditPlan : Window
    {

        private Plan _currentPlan = new Plan();
        public AddOrEditPlan(Plan plan)
        {
            InitializeComponent();
            if (plan != null)
                _currentPlan = plan;
            DataContext = _currentPlan;
            StudentCB.ItemsSource = StudyEntities1.GetContext().Students.ToList();
            SubjectCB.ItemsSource = StudyEntities1.GetContext().Subjects.ToList();

            List<int> GradeList = new List<int>() {2, 3, 4, 5};
            GradeCB.ItemsSource = GradeList;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                StringBuilder error = CheckField();
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                    return;
                }
                _currentPlan.Grade = (int)GradeCB.SelectedItem;
                if (_currentPlan.PlanId == 0)
                {
                    StudyEntities1.GetContext().Plans.Add(_currentPlan);
                }
                StudyEntities1.GetContext().SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private StringBuilder CheckField()
        {
            StringBuilder str = new StringBuilder();
            if (StudentCB.SelectedItem == null)
                str.AppendLine("Выберите студента");
            if (SubjectCB.SelectedItem == null)
                str.AppendLine("Выберите предмет");
            if (GradeCB.SelectedItem == null)
                str.AppendLine("Выберите оценку");
            return str;
        }
    }
}