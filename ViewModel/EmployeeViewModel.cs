using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module02Exercise01.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module02Exercise01.ViewModel
{
    internal class EmployeeViewModel: INotifyPropertyChanged
    {
        private Employee _employee;

        private string _fullName;


        

        public EmployeeViewModel() 
        {

            _employee = new Employee { FirstName = "John", LastName = "Park", Position="Manager", Department="IT", IsActive=false};

            LoadEmployeeDataCommand = new Command(async () => await LoadEmployeeDataAsync());

            Employees = new ObservableCollection<Employee>
            {
                new Employee {FirstName="Sarah", LastName="Gregory", Position="Assistant", Department="IT", IsActive=true },
                new Employee {FirstName="Mike", LastName="Thompson", Position="Secretary", Department="IT", IsActive=true },
                new Employee {FirstName="Lucas", LastName="Franko",Position="Treasurer", Department="IT", IsActive=false},
            };
        }

        public ObservableCollection<Employee> Employees { get; set; }

        public ICommand LoadEmployeeDataCommand { get; }

        public string ManagerName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(ManagerName));
                }
            }
        }

        


        private async Task LoadEmployeeDataAsync()
        {
            await Task.Delay(1000); // I/O operation
            ManagerName = $"{_employee.FirstName} {_employee.LastName} {_employee.Position} {_employee.Department} {_employee.IsActive}";

            //Data

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
