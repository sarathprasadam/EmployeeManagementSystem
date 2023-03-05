using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
namespace EmployeeManagementSystem.Data
{
    public class DataController:Controller
    {
        private readonly IMemoryCache _memoryCache;
       // private readonly ILogger _logger;
        public DataController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
           // _logger = logger;
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public async Task<Login>GetUser(string username)
        {
            try
            {
                Login user = new();
                using var ctx = new DataContext();
                user=ctx.Login.Where(e=>e.username==username).FirstOrDefault();
                return user;

            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public string AddUser(Login user)
        {
            try
            {
                using var ctx=new DataContext();
                ctx.Login.Add(user);
                ctx.SaveChanges();
                return "Saved";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<List<Employees>>GetEmployees()
        {
            List<Employees> employees = new();
            try
            {
                //_logger.LogInformation("In getEmployees");
                
                using var ctx=new DataContext();
                employees = ctx.Employees.ToList();
               // _logger.LogInformation("Employee list returned");
                return employees;

            }
            catch(Exception ex)
            {
                //_logger.LogError(ex.Message);
                return employees ;
            }
        }
        public async Task<List<Employees>> GetEmployeesByName(string name)
        {
            List<Employees> employees = new();
            try
            {
                using var ctx = new DataContext();
                employees= ctx.Employees.Where(e=>e.Name.ToLower().Contains(name.ToLower())).ToList();
                return employees;
            }
            catch (Exception)
            {
                return employees;
            }
        }
        public bool AddEmployee(Employees employee)
        {
            try
            {
                using var ctx = new DataContext();
                ctx.Employees.Add(employee);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool UpdateEmployee(Employees employee)
        {
            try
            {
                using var ctx = new DataContext();
                ctx.Employees.Update(employee);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteEmployee(Employees employee)
        {
            try
            {
                using var ctx=new DataContext();
                ctx.Employees.Remove(employee);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
