using AutoShow.Models.Base;
using DBAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Models
{
    public class EmployeeModel : ModelBase , IDataErrorInfo
    {
        private string  _login;
        private string  _password;
        private string  _fullname;
        private string  _phone;
        private int     _positionId;
        private string  _positionName;
        public int Id { get; set; }
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string FullName
        {
            get => _fullname;
            set
            {
                _fullname = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        public int PositionId
        {
            get => _positionId;
            set
            {
                _positionId = value;
                OnPropertyChanged(nameof(PositionId));
            }
        }
        public string PositionName
        {
            get => _positionName;
            set
            {
                _positionName = value;
                OnPropertyChanged(nameof(PositionName));
            }
        }
        public string Error => throw new NotImplementedException();

        public string this[string columnName] => GetValidationError(columnName);
        private static readonly string[] ValidatedProperties = { "Login" };
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                {
                    if (GetValidationError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        private string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                //case "Login":
                //    if (Login.Length < 2)
                //    {
                //        error = "Имя должно быть больше 1 символа!";
                //    }
                //    break;
            }
            return error;
        }
        public EmployeeModel() { }
        public EmployeeModel(Employee employee)
        {
            Id          = employee.id;
            Login       = employee.login;
            Password    = employee.password;
            FullName    = employee.fullname;
            Phone       = employee.phone;
            PositionId  = employee.position_id;
        }

    }

}

