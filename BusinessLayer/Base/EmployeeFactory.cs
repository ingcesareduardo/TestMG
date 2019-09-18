using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Base
{
    public abstract class EmployeeFactory
    {

        public abstract ICalculableSalary Create(double periodicSalary);


        public EmployeeDTO EmployeeCreator(BaseEmployee employeeEntity)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            ICalculableSalary calculableSalary = null;

            if (employeeEntity.ContractTypeName == "MonthlySalaryEmployee")
                calculableSalary = new MonthlyEmployeeCreator().Create(employeeEntity.MonthlySalary);
            else
                calculableSalary = new HourlyEmployeeCreator().Create(employeeEntity.HourlySalary);

            employeeDTO.Id = employeeEntity.Id;
            employeeDTO.Name = employeeEntity.Name;
            employeeDTO.ContractTypeName = employeeEntity.ContractTypeName;
            employeeDTO.RoleId = employeeEntity.RoleId;
            employeeDTO.RoleName = employeeEntity.RoleName;
            employeeDTO.RoleDescription = employeeEntity.RoleDescription;
            employeeDTO.AnnualSalary = calculableSalary.CalculateSalary();

            return employeeDTO;
        }
    }
}
