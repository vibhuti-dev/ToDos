using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infrastructure.Repository;
using Domain.Entities;
using Application.Interfaces;

namespace ToDos.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController:ControllerBase
    {
         private readonly IUnitOfWork unitOfWork;

        public ToDoController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

         [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await unitOfWork.ToDos.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await unitOfWork.ToDos.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ToDo todo)
        {
            var data = await unitOfWork.ToDos.AddAsync(todo);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await unitOfWork.ToDos.DeleteAsync(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ToDo todo)
        {
            var data = await unitOfWork.ToDos.UpdateAsync(todo);
            return Ok(data);
        }
    }
}