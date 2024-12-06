using InventoryManagement.Core.IRepositories;
using InventoryManagement.Core.Models.Entities;
using InventoryManagement.Service.Interfaces;
using InventoryManagement.Service.Models.Request;
using InventoryManagement.Service.Models.Response;

namespace InventoryManagement.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResponse<EmployeeListResponse>> GetAllEmployeesAsync(SearchRequest<string> searchRequest)
        {
            var paginatedEmployees = await _unitOfWork.Repository<Employee>().GetPagedAsync(
                query => query.Select(x => new EmployeeListResponse
                {
                    Id = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    Email = x.Email ?? ""//,
                    //Department = x.Department.Name,
                    //Designation = x.Designation.Name
                }),
                pageIndex: searchRequest.PageIndex,
                pageSize: searchRequest.PageSize
            );

            return new PaginatedResponse<EmployeeListResponse>
            {
                Data = paginatedEmployees.Data,
                TotalCount = paginatedEmployees.TotalCount,
                CurrentPage = searchRequest.PageIndex,
                PageSize = searchRequest.PageSize
            };
        }

        public async Task<EmployeeDetailsResponse> GetEmployeeByIdAsync(long id)
        {
            var employee = await _unitOfWork.Repository<Employee>().GetByIdAsync<EmployeeDetailsResponse>(id,
                emp => new EmployeeDetailsResponse
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Email = emp.Email,
                    CreatedDate = emp.CreatedDate
                });
            if (employee == null)
                throw new KeyNotFoundException($"Employee with ID {id} not found.");

            return new EmployeeDetailsResponse
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                CreatedDate = employee.CreatedDate,
                Department = "aaa"
            };
        }

        public async Task AddEmployeeAsync(EmployeeCreateOrUpdateRequest request)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DepartmentId = request.DepartmentId,
                CreatedDate = request.CreatedDate
            };

            var result = _unitOfWork.Repository<Employee>().AddAsync(employee);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateEmployeeAsync(long id, EmployeeCreateOrUpdateRequest request)
        {
            //var existingEmployee = await _unitOfWork.Repository<Employee>().GetByIdAsync<EmployeeDet(id);
            //if (existingEmployee == null)
            //    throw new KeyNotFoundException($"Employee with ID {id} not found.");

            //existingEmployee.FirstName = request.FirstName;
            //existingEmployee.LastName = request.LastName;
            //existingEmployee.Email = request.Email;
            //existingEmployee.DepartmentId = request.DepartmentId;

            //var result = await _employeeRepository.UpdateAsync(existingEmployee);
            //if (!result)
            throw new Exception("Failed to update the employee.");
        }

        public async Task DeleteEmployeeAsync(long id)
        {
            //var employee = await _employeeRepository.GetByIdAsync(id);
            //if (employee == null)
            //    throw new KeyNotFoundException($"Employee with ID {id} not found.");

            //var result = await _employeeRepository.DeleteAsync(employee);
            //if (!result)
            throw new Exception("Failed to delete the employee.");
        }

        //public async Task AddEmployeeWithDesignationAsync(Employee employee, Designation designation)
        //{
        //    try
        //    {
        //        // Start a transaction
        //        _unitOfWork.BeginTransaction();

        //        // Save the designation first (as per your requirement)
        //        await _unitOfWork.Repository<Designation>().AddAsync(designation);
        //        await _unitOfWork.SaveAsync();

        //        // Save the employee (after designation)
        //        await _unitOfWork.Repository<Employee>().AddAsync(employee);
        //        await _unitOfWork.SaveAsync();

        //        // Commit transaction if everything is successful
        //        _unitOfWork.CommitTransaction();
        //    }
        //    catch (Exception)
        //    {
        //        // Rollback if something goes wrong
        //        _unitOfWork.RollbackTransaction();
        //        throw;
        //    }
        //}
    }
}
