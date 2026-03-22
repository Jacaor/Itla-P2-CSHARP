using CallCenter.aplication.DTOs;
using CallCenter.domain.Entityes;
using CallCenter.infretruture.DBContex;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CallCenter_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly CallCenterAPIContex _context;

        public ManagerController(CallCenterAPIContex context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagerDTO>>> GetAllManagers()
        {
            var managers = await _context.Managers
                .Select(m => new ManagerDTO
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Email = m.Email,
                    PhoneNumber = m.PhoneNumber
                })
                .ToListAsync();

            return Ok(managers);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ManagerDTO>> GetManagerById(int id)
        {
            var manager = await _context.Managers.FirstOrDefaultAsync(m => m.Id == id);
            if (manager is null)
            {
                return NotFound($"Manager con id:{id} no encontrado");
            }

            return Ok(new ManagerDTO
            {
                Id = manager.Id,
                FirstName = manager.FirstName,
                LastName = manager.LastName,
                Email = manager.Email,
                PhoneNumber = manager.PhoneNumber
            });
        }

        [HttpPost]
        public async Task<ActionResult<ManagerDTO>> CreateManager([FromBody] ManagerDTO managerDto)
        {
            var manager = new Manager
            {
                FirstName = managerDto.FirstName,
                LastName = managerDto.LastName,
                Email = managerDto.Email,
                PhoneNumber = managerDto.PhoneNumber
            };

            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();

            managerDto.Id = manager.Id;
            return CreatedAtAction(nameof(GetManagerById), new { id = manager.Id }, managerDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateManager(int id, [FromBody] ManagerDTO managerDto)
        {
            var manager = await _context.Managers.FirstOrDefaultAsync(m => m.Id == id);
            if (manager is null)
            {
                return NotFound($"Manager con id:{id} no encontrado");
            }

            manager.FirstName = managerDto.FirstName;
            manager.LastName = managerDto.LastName;
            manager.Email = managerDto.Email;
            manager.PhoneNumber = managerDto.PhoneNumber;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            var manager = await _context.Managers.FirstOrDefaultAsync(m => m.Id == id);
            if (manager is null)
            {
                return NotFound($"Manager con id:{id} no encontrado");
            }

            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
