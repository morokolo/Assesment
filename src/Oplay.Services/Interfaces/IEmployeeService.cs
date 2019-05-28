using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Oplay.Models.Response;

namespace Oplay.Services.Interfaces
{
    public interface IEmployeeService
    {
        //Task<EmployeeResponse> GetEmployeesAsync();
        Task<List<EmployeeResponse>> GetEmployeesAsync();
    }
}


