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
    /// Логика взаимодействия для AddOrEditSubject.xaml
    /// </summary>
    public partial class AddOrEditSubject : Window
    {
        private Subject _currentSubject = new Subject();
        private int lectures = 0, practice = 0, laboratory = 0;
        public AddOrEditSubject(Subject subject)
        {
            InitializeComponent();
            if (subject != null)
                _currentSubject = subject;
            DataContext = _currentSubject;
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
                if (_currentSubject.SubjectId == 0)
                    StudyEntities1.GetContext().Subjects.Add(_currentSubject);
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
            if (string.IsNullOrWhiteSpace(_currentSubject.SubjectName))
                str.AppendLine("Поле Название предмета введено некорректно");

            if (!int.TryParse(TbLectures.Text, out lectures))
                str.AppendLine("Поле Объем лекций должно быть только числом");
            else if (lectures < 0)
                str.AppendLine("Объем лекций не может быть отрицательным");

            if (!int.TryParse(TbPractice.Text, out practice))
                str.AppendLine("Поле Объем практик должно быть только числом");
            else if (lectures < 0)
                str.AppendLine("Объем практик не может быть отрицательным");

            if (!int.TryParse(TbLaboratory.Text, out laboratory))
                str.AppendLine("Поле Объем лабораторных работ должно быть только числом");
            else if (lectures < 0)
                str.AppendLine("Объем лабораторных не может быть отрицательным");

            return str;
        }
    }
}
