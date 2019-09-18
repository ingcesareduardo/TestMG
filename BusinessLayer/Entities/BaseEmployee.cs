using BusinessLayer.Base;

namespace BusinessLayer.Entities
{
    public abstract class BaseEmployee: BaseEntity
    {
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }

    }
}
