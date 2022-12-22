using AutoShow.Models;
using AutoShow.Services.Interfaces;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AutoShowDb _autoShowDb;

        public EmployeeService()
        {
            _autoShowDb = new AutoShowDb();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeModel> GetEmployees()
        {
            return _autoShowDb.Employee.AsEnumerable().Select(employee => new EmployeeModel(employee)).ToList();
        }

        public string GetPositionNameById(int id)
        {
            return _autoShowDb.Position.Where(i => i.id == id).Select(i => i.name).FirstOrDefault();
        }

        public void InsertEmployee(EmployeeModel employee)
        {
            var newEmployee = new Employee()
            {
                login       = employee.Login,
                password    = employee.Password,
                fullname    = employee.FullName,
                phone       = employee.Phone,
                position_id = employee.PositionId,
            };

            _autoShowDb.Employee.Add(newEmployee);
            _autoShowDb.SaveChanges();
        }

        public EmployeeModel SignIn(string login, string password)
        {
            var model = _autoShowDb.Employee.FirstOrDefault(p => p.login == login && p.password == password);

            if(model == null)
                return null;

            return new EmployeeModel()
            {
                Id          = model.id,
                Login       = model.login,
                Password    = model.password,
                FullName    = model.fullname,
                Phone       = model.phone,
                PositionId  = model.position_id
            };
        }
    }
}
