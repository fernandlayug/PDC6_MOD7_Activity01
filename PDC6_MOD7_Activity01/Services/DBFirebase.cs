using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using PDC6_MOD7_Activity01.Models;
using System.Collections.ObjectModel;

using System.Linq;


namespace PDC6_MOD7_Activity01.Services
{
   
    public class DBFirebase
    {
        FirebaseClient client;
        public DBFirebase()
        {
            client = new FirebaseClient("https://pdc6mod7-default-rtdb.firebaseio.com/");
        }

        public ObservableCollection<Employee> getEmployee()
        {
            var employeeData = client
                .Child("Employee")
                .AsObservable<Employee>()
                .AsObservableCollection();

            return employeeData;

        }

        public async Task AddEmployee(string Name, string Gender, int Age)
        {
            Employee em = new Employee() { name = Name, gender = Gender, age = Age };
            await client
                .Child("Employee")
                .PostAsync(em);
        }

        //Delete and Update
        public async Task DeleteEmployee(string Name, string Gender, int Age)
        {
            var toDeleteStudent = (await client
                  .Child("Employee")
                  .OnceAsync<Employee>()).FirstOrDefault
                  (a => a.Object.name == Name || a.Object.gender == Gender);
            await client.Child("Employee").Child(toDeleteStudent.Key).DeleteAsync();

        }

        public async Task UpdateEmployee(string Name, string Gender, int Age)
        {
            var toUpdateEmployee = (await client
                .Child("Employee")
                .OnceAsync<Employee>()).FirstOrDefault
                (a => a.Object.name == Name);

            Employee e = new Employee() { name = Name, gender = Gender, age = Age };
            await client
                .Child("Employee")
                .Child(toUpdateEmployee.Key)
                .PutAsync(e);
        }

    }
}
