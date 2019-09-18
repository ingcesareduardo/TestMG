using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public class HourlyEmployee : ICalculableSalary
    {
        private double _periodicSalary { get; set; }
        public HourlyEmployee(double periodicSalary)
        {
            _periodicSalary = periodicSalary;
        }

        public double CalculateSalary()
        {
            return 120 * this._periodicSalary * 12;
        }
    }
}
