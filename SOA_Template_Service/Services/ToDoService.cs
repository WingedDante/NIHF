using System;
using System.Collections.Generic;
using System.Linq;
using CarPartsService.DAL.Models;
using CarPartsService.DAL;
using CarPartsService.DAL.Repositories;
using CarPartsService.DAL.Repositories.Interfaces;
using AutoMapper;
// using ToDoService.DAL.Models;
using CarPartsService.BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace CarPartsService.Services
{
    using System.Threading.Tasks;
    using Interfaces;
    // using ToDoService.BusinessLogic.Interfaces;

    /*
        Service is orchestrating your meat and potatoes, getting data from your repo,
        sending it to/through your BL to transform it, and using automapper to map the result to pass it back
        in a VM to the controller/(other service)
     */
    public class CarPartsService : ICarPartsService
    {
        private ICarPartsRepository _repository;
        private readonly IMapper _mapper;
        // private IPhysicianProvider _physicianProvider;
                                                                                //Example BLL injection
        public CarPartsService(ICarPartsRepository repository, IMapper mapper /* , IPhysicianProvider physicianProvider */ ){
            _repository = repository;
            _mapper = mapper;
            // _physicianProvider = physicianProvider;
        }

        public IEnumerable<CarPart> GetAllToDoItems(){
            //Get data
            var ToDo_result = _repository.GetAll();
            
            //Transform Data With BL
            // _physicianProvider.DoStuff();

            return ToDo_result;
            //Map and Return Data VM
            // return _mapper.Map<IEnumerable<ProviderVM>>(Provider_result);
        }

        public IEnumerable<CarPart> GetToDoItem(string name){
            //Get data
            var ToDo_result = _repository.Search(name);

            //Transform Data With BL
            // _physicianProvider.DoStuff();

            return ToDo_result;
            //Map and Return Data VM
            // return _mapper.Map<IEnumerable<ProviderVM>>(Provider_result);

        }

        public async Task<int> AddToDoItem(CarPart item)
        {
            var insert_result = await _repository.Add(item);

            return insert_result;
        }

        public async Task<int> DeleteToDoItem(int id){
            var delete_result = await _repository.Delete(id);
            return delete_result;
        }
        public CarPart GetToDoItemByID(int id){
            var ToDo_result =  _repository.GetToDo(id);
            return ToDo_result;
        }
        public async Task<int> UpdateToDoItem(CarPart item){
            var update_result = await _repository.Update(item);
            return update_result;
        }
    }

}