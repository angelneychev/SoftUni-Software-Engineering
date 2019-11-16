using System.Linq;

namespace MyCoolCarSystem.Data.Querys
{
    using System;
    using System.Collections.Generic;
    using MyCoolCarSystem.Results;
    using Microsoft.EntityFrameworkCore;

    public class CarQueries
    {
        public static Func<CarDbContext, int, IEnumerable<ResultModel>> ToResult 
            = EF.CompileQuery<CarDbContext, int, IEnumerable<ResultModel>>(
                
                (db, price) => db.Cars
                    .Where(x=>x.Price > price)
                    .Select(x=> new
                    {
                        FullName = x.Model.Make.Name
                    }));

    }
}
