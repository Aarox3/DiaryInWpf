using DiaryInWpf.ViewModels;
using MahApps.Metro.Controls;


namespace DiaryInWpf.Views
{
    /// <summary>
    /// Interaction logic for AddEditStudentView.xaml
    /// </summary>
    public partial class AddEditStudentView : MetroWindow
    {
        public AddEditStudentView(Models.Wrappers.StudentWrapper student = null)
        {
            InitializeComponent();
            DataContext = new AddEditStudentViewModel(student);
        }
    }
}
