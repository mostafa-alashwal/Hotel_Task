using Hotel_Task.Data;
using Hotel_Task.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Roomzy.Controllers
{
    public class AgentsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AgentsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Agents/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: Agents/Add
        [HttpPost]
        public async Task<IActionResult> Add(Agent viewModel)
        {
            if (ModelState.IsValid)
            {
                var agent = new Agent
                {
                    Id = Guid.NewGuid(), // Generate a new GUID for the agent
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    Password = viewModel.Password,
                    Address = viewModel.Address,
                    Remake = viewModel.Remake,
                    IsDeleted = false // Initialize as not deleted
                };

                await _dbContext.Agents.AddAsync(agent);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("List"); // Redirect to the list page after saving
            }

            return View(viewModel); // Return the same view with validation errors
        }

        // GET: Agents/List
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var agents = await _dbContext.Agents
                .Where(a => !a.IsDeleted) // Exclude agents marked as deleted
                .ToListAsync();
            return View(agents);
        }

        // POST: Agents/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var agent = await _dbContext.Agents.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }

            // Mark the agent as deleted instead of removing from the database
            agent.IsDeleted = true;
            _dbContext.Agents.Update(agent);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("List"); // Redirect to the list page after deletion
        }
        // GET: Agents/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var agent = await _dbContext.Agents.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // POST: Agents/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Agent viewModel)
        {
            if (id != viewModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(viewModel);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_dbContext.Agents.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    throw;
                }

                return RedirectToAction("List");
            }

            return View(viewModel);
        }

    }
}
