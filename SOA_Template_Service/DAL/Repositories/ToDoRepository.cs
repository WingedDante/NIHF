using System.Collections.Generic;
using CarPartsService.DAL.Models;
using CarPartsService.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using CarPartsService.DAL.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartsService.DAL.Repositories
{
    public class CarPartsRepository : ICarPartsRepository
    {
        private CarPartContext _context;

        public CarPartsRepository(CarPartContext carPartContext){
            _context = carPartContext;
        }

        public IEnumerable<CarPart> GetAll()
        {
            // 
            return _context.CarParts;
        }

        public IEnumerable<CarPart> Search(string name)
        {

            return  _context.CarParts.Where(t => t.PartName == name);

           

        }
        public async Task<int> Add(CarPart toDo){

            await _context.CarParts.AddAsync(toDo);
           return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int partId){
            CarPart carPart = this.GetToDo(partId);
             _context.CarParts.Remove(carPart);

            return await _context.SaveChangesAsync();
        }

        public  CarPart GetToDo(int id){
            var result = _context.CarParts.Where(t => t.ID == id);
            return result.AsQueryable().Cast<CarPart>().First();
        }
        public async Task<int> Update(CarPart carPart){

            var result =  _context.CarParts.FirstOrDefault(item => item.ID == carPart.ID);
            if (result != null){
                result.ManufacturerName = carPart.ManufacturerName;
                result.PartDescription = carPart.PartDescription;
                result.PartName = carPart.PartName;
                result.PartNumber = carPart.PartNumber;

                _context.CarParts.Update(result);
            }
            return await _context.SaveChangesAsync();
        }
    }
}