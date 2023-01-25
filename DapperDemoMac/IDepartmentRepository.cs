using System;
namespace DapperDemoMac
{
	public interface IDepartmentRepository
	{
        public IEnumerable<Department> GetAllDepartments();
        public void InsertDepartment(string newDepartmentName);
        public void DeleteDepartment(int deptID);
    }
}

