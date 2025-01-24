using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myTestWebApi.DTO;
using myTestWebApi.Models;

namespace myTestWebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]    
    public class EmployeeController : ControllerBase
    {
        private readonly DBTmycontext _dbContect;

        public EmployeeController(DBTmycontext dbcontext)
        {
            _dbContect = dbcontext;
        }


        [HttpGet]
        public List<DtoEmployee> GetEmployees()
        {
            List<DtoEmployee> objNew = new List<DtoEmployee>();
            try
            {


                objNew = _dbContect.TEmployee.Select(p => new DtoEmployee
                {
                    Name = p.NAME,
                    Salary = p.Salary,
                    PhoneNumber = p.PhoneNumber,
                    Email = p.Email,
                }).ToList();
            }
            catch (Exception ex)
            {

                string err = ex.ToString();
            }
            return objNew;
            //return Ok(_dbContect.Employees);
        }

        [HttpGet("getEmp")]
        public IEnumerable<DtoEmployee> getEmp()
        {
            var objData = new List<DtoEmployee>();
            objData = _dbContect.TEmployee.Select(p => new DtoEmployee
            {
                Email = p.Email,
                Salary = p.Salary,
                PhoneNumber = p.PhoneNumber,
                Name = p.NAME

            }).ToList();
            return objData;
        }

        [HttpGet]
        [Route("{ID}/{fstrData}")]
        public IActionResult GetEmployeeById(int ID,string fstrData)
        {
            var employee = _dbContect.TEmployee.Find(ID);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpPost]
        public IActionResult AddEmployee(DtoEmployee employeeDto)
        {
            var employee = new clsEmployees
            {
                NAME = employeeDto.Name,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                Salary = employeeDto.Salary
            };
            _dbContect.TEmployee.Add(employee);
            _dbContect.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEmployee(int id, DtoEmployee employeeDto)
        {
            var employee = _dbContect.TEmployee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.NAME = employeeDto.Name;
            employee.Email = employeeDto.Email;
            employee.PhoneNumber = employeeDto.PhoneNumber;
            employee.Salary = employeeDto.Salary;
            _dbContect.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{ID:int}")]
        public IActionResult DeleteEmployee(int ID)
        {
            var employee = _dbContect.TEmployee.Find(ID);
            if (employee == null)
            {
                return NotFound();
            }
            _dbContect.TEmployee.Remove(employee);
            _dbContect.SaveChanges();
            return NoContent();
        }
    }



}
