using System.Collections.Generic;
using System.Threading.Tasks;
using CarPartsService.DAL.Models;

namespace CarPartsService.Services.Interfaces
{
    public interface ICarPartsService
    {
        IEnumerable<CarPart> GetAllToDoItems();
        IEnumerable<CarPart> GetToDoItem(string name);
        Task<int> AddToDoItem(CarPart item);
        Task<int> DeleteToDoItem(int id);
        CarPart GetToDoItemByID(int id);
    }
}