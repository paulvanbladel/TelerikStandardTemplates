using System.Collections.Generic;
using TelerikAdmin.Shared.Models.Employee;
using TelerikAdmin.Shared.Models.Sales;

namespace TelerikAdmin.Server.Data
{
    public interface IDataService
    {
        List<Employee> GetEmployees();
        IEnumerable<Sale> GetSales();
        List<Team> GetTeams();
    }
}
