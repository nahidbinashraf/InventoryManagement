using InventoryManagement.Service.Models.Request;
using InventoryManagement.Service.Models.Response;

namespace InventoryManagement.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<PaginatedResponse<EmployeeListResponse>> GetAllEmployeesAsync(SearchRequest<string> searchRequest);

        Task<EmployeeDetailsResponse> GetEmployeeByIdAsync(long id);

        Task AddEmployeeAsync(EmployeeCreateOrUpdateRequest employeeCreateOrUpdateRequest);

        Task UpdateEmployeeAsync(long id, EmployeeCreateOrUpdateRequest employeeCreateOrUpdateRequest);

        Task DeleteEmployeeAsync(long id);
    }
}
