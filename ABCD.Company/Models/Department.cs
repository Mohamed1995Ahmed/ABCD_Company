﻿namespace ABCD.Company.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ManagerName { get; set; }

        public virtual List<Employee>? Emps { get; set; }
    }
}
