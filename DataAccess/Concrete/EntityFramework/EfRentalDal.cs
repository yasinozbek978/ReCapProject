using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             join u in context.Users on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarBrandName = b.BrandName,
                                 CarColorName = cl.ColorName,
                                 CarDescription = c.Description,
                                 CarModelYear = c.ModelYear,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 CustomerEmail = u.Email,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
