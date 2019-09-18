using BusinessLayer.Base;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public class MonthlyEmployee: BaseEmployee, ICalculableSalary
    {
        private double _periodicSalary { get; set; }

        public MonthlyEmployee(double periodicSalary)
        {
            _periodicSalary = periodicSalary;
        }
        public double CalculateSalary()
        {
            return this._periodicSalary * 12;
        }
    }
}
