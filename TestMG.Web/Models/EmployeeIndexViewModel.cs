using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestMG.Web.Models
{
    public class EmployeeIndexViewModel
    {
        public int? Id { get; set; }
        public IEnumerable<EmployeeDTO> Employees { get; set; }
    }
}
