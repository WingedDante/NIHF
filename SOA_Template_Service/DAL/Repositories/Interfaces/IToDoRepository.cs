using System.Collections.Generic;
using System.Threading.Tasks;
using CarPartsService.DAL.Models;

namespace CarPartsService.DAL.Repositories.Interfaces
{
    public interface ICarPartsRepository
    {
         IEnumerable<CarPart> GetAll();
         IEnumerable<CarPart> Search(string name);
         Task<int> Add(CarPart carPart);
         Task<int> Delete(int carPartId);
         CarPart GetToDo(int carPartId);
         Task<int> Update(CarPart carPart);
    }
}