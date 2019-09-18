using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Entities
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double AnnualSalary { get; set; }
    }
}
