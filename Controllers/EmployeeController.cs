using Employee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        List<Emp> empList = new List<Emp> { 
            new Emp { id=1,name="Ishaa",age=22},
            new Emp { id=2,name="Chaitali",age=22},
            new Emp { id=3,name="Mukundan",age=22},
            };
        [HttpGet]
        public ActionResult<IEnumerable<Emp>> Get()
        {
            return empList;
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public ActionResult<Emp> Get(int id)
        {
            Emp emp = empList.FirstOrDefault(c => c.id == id);
            if (emp == null)
            {
                return NotFound(new { Message = "Employee has not been found." });
            }

            return Ok(emp);
        }
        [HttpPost]
        public ActionResult<IEnumerable<Emp>> Post(Emp newEmp)
        {
            newEmp.id = empList.Count + 1;
            empList.Add(newEmp);
            return empList;
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Emp>> Put(int id, Emp updatedEmp)
        {
            Emp emp = empList.FirstOrDefault(c => c.id == id);
            if (emp == null)
            {
                return NotFound();
            }

            emp.name = updatedEmp.name;
            emp.age = updatedEmp.age;

            return empList;
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Emp>> Delete(int id)
        {
            Emp emp = empList.FirstOrDefault(c => c.id == id);
            if (emp == null)
            {
                return NotFound();
            }

            empList.Remove(emp);

            return empList;
        }
    }
}
