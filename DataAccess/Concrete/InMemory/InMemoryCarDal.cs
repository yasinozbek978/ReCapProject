using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {CarId=1, BrandId=1, ColorId=1, ModelYear=2020, DailyPrice=500, Description="Araç1"},
                new Car {CarId=2, BrandId=2, ColorId=1, ModelYear=2021, DailyPrice=550, Description="Araç2"},
                new Car {CarId=3, BrandId=2, ColorId=1, ModelYear=2020, DailyPrice=600, Description="Araç3"},
                new Car {CarId=4, BrandId=3, ColorId=1, ModelYear=2019, DailyPrice=600, Description="Araç4"},
                new Car {CarId=5, BrandId=1, ColorId=1, ModelYear=2021, DailyPrice=650, Description="Araç5"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delet(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            //LINQ = Language Integrated Query (Dile Gömülü Sorgulama)
            // _products.Remove(product); Kodu tek başına ürünü silmez.Çünkü isim aynı olsa bile referans farklıdır
            //Lambda
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByCardId(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
