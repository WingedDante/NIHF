using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarPartsService.DAL.Models;
using CarPartsService.DAL;
using CarPartsService.Services;

namespace ToDoService.Controllers
{
    /*
        Your Controllers really only care about handling the HTTP requests, 
        and getting information back from your services to respond with. 
     */

    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        
        private CarPartsService.Services.CarPartsService _toDoService;
       
        public ToDoController(CarPartsService.Services.CarPartsService toDoService )
        {
            _toDoService = toDoService;
        }
        

        //GET api/todo
        [HttpGet]
        public ActionResult<IEnumerable<CarPart>> Get()
        {
            /*
                get data with _service
                apply _BL
                Return VM
             */
            var toDos = _toDoService.GetAllToDoItems();

            if (toDos != null)
            {
                return Ok(toDos);
            }
            else if (toDos.Count() == 0)
            {
                return Ok(toDos);
            }
            else
            {
                return Ok(new List<CarPart>());
            }


        }

        [HttpGet("{id}")]
        public ActionResult<CarPart> Get(int id){
            var result = _toDoService.GetToDoItemByID(id);

            return Ok(result);
        }

        // POST api/toDo
        // POST body: name
        [HttpGet("{name}")]
        public ActionResult<IEnumerable<CarPart>> Get([FromBody] string name)
        {
            if (name != null && name != "")
            {
                var toDos = _toDoService.GetToDoItem(name);

                if (toDos != null)
                {
                    return Ok(toDos);
                }
                else if (toDos.Count() == 0)
                {
                    return Ok(toDos);
                }
                else
                {
                    return Ok(new List<CarPart>());
                }
            }
            else
            {
                return BadRequest();
            }
        }

        //Post
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] CarPart item){
            int result;
            try{
                result =  (await _toDoService.AddToDoItem(item));
                return Ok(result);
            }
            catch(Exception ex){
                result = 0;
                return BadRequest(result);
            }

            
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody] CarPart item){
            int result;
            try{
                result = (await _toDoService.UpdateToDoItem(item));
                return Ok(result);
            }
            catch(Exception ex){
                result = 0;
                return BadRequest(0);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id){
            int result;
            try{
                result = (await _toDoService.DeleteToDoItem(id));
                return Ok(result);
            }
            catch(Exception ex){
                result = 0;
                return BadRequest(result);
            }
        }



        // // GET api/values/5
        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     return "value";
        // }

        // // POST api/values
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}