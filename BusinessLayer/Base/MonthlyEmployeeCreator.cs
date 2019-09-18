using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Base
{
    public class MonthlyEmployeeCreator: EmployeeFactory
    {
        public override ICalculableSalary Create(double periodicSalary)
        {
            return new MonthlyEmployee(periodicSalary);
        }
    }
}
