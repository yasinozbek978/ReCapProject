using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2022, DailyPrice = 50000, Description = "Araba1"},
                new Car{Id = 1, BrandId = 1, ColorId = 2, ModelYear = 2021, DailyPrice = 51000, Description = "Araba2"},
                new Car{Id = 1, BrandId = 2, ColorId = 2, ModelYear = 2020, DailyPrice = 52000, Description = "Araba3"},
                new Car{Id = 1, BrandId = 3, ColorId = 3, ModelYear = 2022, DailyPrice = 53000, Description = "Araba4"},
                new Car{Id = 1, BrandId = 3, ColorId = 4, ModelYear = 2021, DailyPrice = 54000, Description = "Araba5"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
