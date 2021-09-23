using DiaryInWpf.Commands;
using DiaryInWpf.Models.Wrappers;
using DiaryInWpf.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DiaryInWpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {

            using (var context = new ApplicationDbContext())
            {
                var students = context.Students.ToList();
            }

            AddStudentsCommand = new RelayCommand(AddEditStudents);

            EditStudentsCommand = new RelayCommand(AddEditStudents, CanEditDeleteStudent);

            RefreshStudentsCommand = new RelayCommand(RefreshStudents, CanEditDeleteStudent);

            DeleteStudentsCommand = new AsyncRelayCommand(DeleteStudents);

            RefreshDiary();

            InitGroups();

        }

               
        public ICommand AddStudentsCommand { get; set; }

        public ICommand EditStudentsCommand { get; set; }

        public ICommand RefreshStudentsCommand { get; set; }

        public ICommand DeleteStudentsCommand { get; set; }





        private void RefreshStudents(object obj)
        {
            RefreshDiary();
        }

       

        private bool CanEditDeleteStudent(object obj)
        {
            return SelectedStudent != null;
        }

        private async Task DeleteStudents(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync("Usuwanie ucznia", $"Czy na pewno chcesz usunąć ucznia " +
                $"{SelectedStudent.FirstName} {SelectedStudent.LastName}?", MessageDialogStyle.AffirmativeAndNegative);

            if (dialog != MessageDialogResult.Affirmative)
                return;

            //usuwanie ucznia z bazy danych

            RefreshDiary();      
            
        }

        private void AddEditStudents(object obj)
        {
            var addEditStudentWindow = new AddEditStudentView(obj as StudentWrapper);
            addEditStudentWindow.Closed += AddEditStudentWindow_Closed;
            addEditStudentWindow.ShowDialog();
        }

        private void AddEditStudentWindow_Closed(object sender, EventArgs e)
        {
            RefreshDiary();
        }

        private StudentWrapper _selectedStudent;

        public StudentWrapper SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;

                OnPropertyChanged();
            }
        }


        private ObservableCollection<StudentWrapper> _students;

        public ObservableCollection<StudentWrapper> Students
        {
            get { return _students; }
            set
            {
                _students = value;

                OnPropertyChanged();
            }
        }

        private int _selectedGroupId;


        public int SelectedGroupId
        {
            get { return _selectedGroupId; }

            set { _selectedGroupId = value; }
        }

        public ObservableCollection<GroupWrapper> _groups;
        public ObservableCollection<GroupWrapper> Groups

        {
            get { return _groups; }
            set
            {
                _groups = value;

                OnPropertyChanged();
            }
        }

     
        private void RefreshDiary()
        {
            Students = new ObservableCollection<StudentWrapper>
            {
                new StudentWrapper

                {
                  FirstName = "Kazimierz",
                  LastName = "Szpin",
                  Group = new GroupWrapper { Id = 1 }
                },

                new StudentWrapper
                {
                  FirstName = "Jan",
                  LastName = "Kowalski",
                  Group = new GroupWrapper { Id = 2 }
                },

                new StudentWrapper
                {
                  FirstName = "Zofia",
                  LastName = "Nowak",
                  Group = new GroupWrapper { Id = 1 }
                },
            };
        }



        public void InitGroups()
        {
            Groups = new ObservableCollection<GroupWrapper>
            {
                new GroupWrapper { Id = 0, Name = "Wszystkie" },
                new GroupWrapper { Id = 1, Name = "1A" },
                new GroupWrapper { Id = 2, Name = "2B" },
            };

            SelectedGroupId = 0;
        }

    }
}
