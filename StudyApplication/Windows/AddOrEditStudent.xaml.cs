using StudyApplication.Entities;
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
using System.Windows.Shapes;

namespace StudyApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditStudent.xaml
    /// </summary>
    public partial class AddOrEditStudent : Window
    {
        private Student _currentStudent = new Student();
        public AddOrEditStudent(Student student)
        {
            InitializeComponent();
            if (student != null ) 
                _currentStudent = student;
            DataContext = _currentStudent;
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
                if (_currentStudent.StudentsId == 0)
                    StudyEntities1.GetContext().Students.Add(_currentStudent);
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
            if (string.IsNullOrWhiteSpace(_currentStudent.Surname))
                str.AppendLine("Поле Фамилия введено некорректно");
            if (string.IsNullOrWhiteSpace(_currentStudent.Name))
                str.AppendLine("Поле Имя введено некорректно");
            if (string.IsNullOrWhiteSpace(_currentStudent.Patrongmic))
                str.AppendLine("Поле Отчество введено некорректно");
            if (string.IsNullOrWhiteSpace(_currentStudent.Address))
                str.AppendLine("Поле Адрес введено некорректно");
            if (string.IsNullOrWhiteSpace(_currentStudent.Phone))
                str.AppendLine("Поле Номер телефона введено некорректно");
            return str;
        }
    }
}
