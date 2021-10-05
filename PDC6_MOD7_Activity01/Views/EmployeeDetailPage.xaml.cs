using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PDC6_MOD7_Activity01.Services;
using PDC6_MOD7_Activity01.Models;



namespace PDC6_MOD7_Activity01.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeDetailPage : ContentPage
    {
        DBFirebase services;

        public EmployeeDetailPage(Employee employee)
        {
            InitializeComponent();
            BindingContext = employee;
            services = new DBFirebase();
        }

        public async void BtnDelete (object sender, EventArgs e)
        {
            await services.DeleteEmployee(Name.Text, Gender.Text, int.Parse(Age.Text));
            await Navigation.PushAsync(new EmployeeView());
        }

        public async void BtnUpdate(object sender, EventArgs e)
        {
            await services.UpdateEmployee(
                Name.Text, Gender.Text, int.Parse(Age.Text));
            await Navigation.PushAsync(new EmployeeView());
        }
    }
}