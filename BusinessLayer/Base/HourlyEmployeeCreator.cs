using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Base
{
    public class HourlyEmployeeCreator : EmployeeFactory
    {
        public override ICalculableSalary Create(double periodicSalary)
        {
            return new HourlyEmployee(periodicSalary);
        }
    }
}
