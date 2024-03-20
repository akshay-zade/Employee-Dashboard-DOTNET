using Microsoft.EntityFrameworkCore;
using System;

namespace Crud_operation_API.Data
{
    public class EmployeeRepository
    {
        private readonly AppDBContext _appDBContext;
        public EmployeeRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task AddEmpolyeeAsync(Employee employee)
        {
            await _appDBContext.Set<Employee>().AddAsync(employee);
            await _appDBContext.SaveChangesAsync(); 
        }

        public async Task<List<Employee>> GetAllEmployeeAsync() 
        {
          return await _appDBContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetAllEmployeeBYId(int id)
        {
            return await _appDBContext.Employees.FindAsync(id); 
        }
        public async Task UpdateEmployee(int id , Employee model)
        {
            var employee = await _appDBContext.Employees.FindAsync(id);
            if(employee == null)
            {
                throw new Exception("Employee not found");
            }
            employee.Name = model.Name;
            employee.Phone = model.Phone;
            employee.Age = model.Age;
            employee.Salary = model.Salary;
            await _appDBContext.SaveChangesAsync();
        }
        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _appDBContext.Employees.FindAsync(id);
            if (employee == null) {
                throw new Exception("User Not Found");
            }
            _appDBContext.Employees.Remove(employee);
            await _appDBContext.SaveChangesAsync();
        }
    }
}
