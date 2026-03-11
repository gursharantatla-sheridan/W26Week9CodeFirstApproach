using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace W26Week9CodeFirstApproach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SchoolContext db = new SchoolContext();

        public MainWindow()
        {
            InitializeComponent();
            LoadStandards();
        }

        private void LoadStandards()
        {
            var standards = db.Standards.ToList();
            cmbStandard.ItemsSource = standards;
            cmbStandard.DisplayMemberPath = "StandardName";
            cmbStandard.SelectedValuePath = "StandardId";
        }

        private void LoadStudents()
        {
            var students = (from s in db.Students
                            select new { s.StudentId, s.StudentName, s.Standard!.StandardName }).ToList();

            grdStudents.ItemsSource = students;
        }

        private void btnLoadStudents_Click(object sender, RoutedEventArgs e)
        {
            LoadStudents();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Student std = new Student();
            std.StudentName = txtName.Text;
            std.StandardId = (int)cmbStandard.SelectedValue;

            db.Students.Add(std);
            db.SaveChanges();

            LoadStudents();
            MessageBox.Show("New student added");
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var std = db.Students.Find(id);

            if (std != null)
            {
                txtName.Text = std.StudentName;
                cmbStandard.SelectedValue = std.StandardId;
            }
            else
            {
                txtName.Text = "";
                cmbStandard.SelectedIndex = -1;
                MessageBox.Show("Invalid ID. Please try again");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var std = db.Students.Find(id);

            std.StudentName = txtName.Text;
            std.StandardId = (int)cmbStandard.SelectedValue;

            db.SaveChanges();

            LoadStudents();
            MessageBox.Show("Student updated");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            var std = db.Students.Find(id);

            db.Students.Remove(std);
            db.SaveChanges();

            LoadStudents();
            MessageBox.Show("Student deleted");
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var students = (from s in db.Students
                            where s.StudentName!.Contains(txtName.Text)
                            select s).ToList();

            grdStudents.ItemsSource = students;
        }
    }
}