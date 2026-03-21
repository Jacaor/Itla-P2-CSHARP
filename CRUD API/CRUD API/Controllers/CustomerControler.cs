using Microsoft.AspNetCore.Mvc;
using CallCenter.infretruture.Model;
using CallCenter.infretruture.DBContex;
using CallCenter.aplication.DTOs;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly CrudAPIContex _aPIContex;
        public ManagerController(CrudAPIContex aPIContex)
        {
            _aPIContex = aPIContex;
        }
        [HttpGet]
        public IActionResult GetAllManagers()
        {
            var managers = _aPIContex.Managers.ToList();
            var list = new List<ManagerDTO>();

            var selecmanagers = managers.Select(c => new ManagerDTO
            {

                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber


            }).ToList();
            return Ok(selecmanagers);

        }
        [HttpGet("{id}")]
        public IActionResult GetManagerById(int id)
        {
            var manager = _aPIContex.Managers.FirstOrDefault(c => c.Id == id);
            if (manager == null)
            {
                return NotFound();
            }
            return Ok(manager);
        }
        [HttpPost]
        public IActionResult CreateManager([FromBody] ManagerDTO managerdto)
        {
            var managerdb = new ManagerModel
            {

                FirstName = managerdto.FirstName,
                LastName = managerdto.LastName,
                Email = managerdto.Email,
                PhoneNumber = managerdto.PhoneNumber
            };

            _aPIContex.Add(managerdb);
            _aPIContex.SaveChanges();
            return Ok(managerdto);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateManager(int id, [FromBody] ManagerDTO managerdto)
        {
            var manager = _aPIContex.Managers.FirstOrDefault(c => c.Id == id);
            if (manager == null)
            {
                return NotFound($"Cliente no con {id}encontrado");
            }
            manager.FirstName = managerdto.FirstName;
            manager.LastName = managerdto.LastName;
            manager.Email = managerdto.Email;
            manager.PhoneNumber = managerdto.PhoneNumber;
            _aPIContex.Managers.Update(manager);
            _aPIContex.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteManager(int id, [FromBody] ManagerDTO managerdto)
        {
            var manager = _aPIContex.Managers.FirstOrDefault(c => c.Id == id);
            if (manager == null)
            {
                return NotFound($"Cliente con id:{id} no encontrado");
            }
            _aPIContex.Managers.Remove(manager);
            _aPIContex.SaveChanges();
            return NoContent();
        }

    }
}


