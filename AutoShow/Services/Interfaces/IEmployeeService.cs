using AutoShow.Models;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Services.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeModel SignIn(string login, string password);
        List<EmployeeModel> GetEmployees();
        string GetPositionNameById(int id);
        void InsertEmployee(EmployeeModel employee);
        void DeleteEmployee(int id);
        EmployeeModel GetEmployeeByPhone(string phone);
        void EditEmployee(EmployeeModel employee);
    }
}
