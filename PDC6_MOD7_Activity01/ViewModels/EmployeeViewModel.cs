using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using PDC6_MOD7_Activity01.Models;
using PDC6_MOD7_Activity01.Services;
using MvvmHelpers;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace PDC6_MOD7_Activity01.ViewModels
{
    class EmployeeViewModel : BaseViewModel
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        private DBFirebase services;


        public Command AddEmployeeCommand { get;  }
        public ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged();
                  
            }
        }

        public EmployeeViewModel()
        {
            services = new DBFirebase();
            Employees = services.getEmployee();
            AddEmployeeCommand = new Command(async () => await addEmployeeAsync(name, gender, age));

        }

        public async Task addEmployeeAsync(string name, string gender, int age)
        {
            await services.AddEmployee(name, gender, age);
        }

    }
}
