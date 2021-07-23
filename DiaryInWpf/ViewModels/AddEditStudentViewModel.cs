using DiaryInWpf.Commands;
using DiaryInWpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DiaryInWpf.ViewModels
{
    class AddEditStudentViewModel : ViewModelBase
    {
        public AddEditStudentViewModel(Student student = null)
        {
            ConfirmCommand = new RelayCommand(Confirm);

            CloseCommand = new RelayCommand(Close);

            if (student == null)
            {
                Student = new Student();
            }
            else
            {
                Student = student;
                IsUpdate = true;
            }

            InitGroups();

        }


        public ICommand ConfirmCommand { get; set; }
       
        public ICommand CloseCommand { get; set; }

        private Student _student;

        public Student Student
        {
            get { return _student; }
            set
            { 
                _student = value;
                OnPropertyChanged();
            }
        }

        private bool _isUpdate;

        public bool IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }

        private int _selectedGroupId;


        public int SelectedGroupId
        {
            get { return _selectedGroupId; }

            set { _selectedGroupId = value; }
        }

        private ObservableCollection<Student> _group;
        public ObservableCollection<Student> Groups

        {
            get { return _group; }
            set
            {
                _group = value;

                OnPropertyChanged();
            }
        }

        private void InitGroups()
        {
            Groups = new ObservableCollection<Group>
            {
                new Group {Id = 0, Name = "--brak--"},
                new Group {Id = 1, Name = "1A"},
                new Group {Id = 2, Name = "2B"},
            };

            Student.Group.Id = 0;
        }

        private void Confirm(object obj)
        {
           if (!IsUpdate)
              AddStudent();
           else
             UpdateStudent();
             CloseWindow(obj as Window);
        }

        private void UpdateStudent()
        {
          //baza danych
        }

        private void AddStudent()
        {
            //baza danych
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
