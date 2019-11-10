using EFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreDemo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {

                var result = db.Towns
                    .Where(t => t.Name.StartsWith("S"))
                    .Select(t=> new
                    {
                        t.Name
                    })
                    .ToList();

                //var result = db.Towns
                //    .Where(t => t.Name.StartsWith("S"))
                //    .Where(t=>t.TownId > 3)
                //    .Select(t => t.Name)
                //    .ToList();

                foreach (var r in result)
                {
                    Console.WriteLine(r);
                }

                //   var town = db.Towns.ToList();

                //var list = new List<Towns>();
                //list.Where(t => t.Name.StartsWith('1'));

                //db.Towns.Where(t => t.Name.StartsWith('1'));

                //var towns = db.Towns
                //      .Include(t => t.Addresses)
                //      .ToList();

                //var towns = db.Towns
                //      .ToList();

                //  foreach (var town in towns)
                //  {
                //      Console.WriteLine(town.Name);
                //      foreach (var address in town.Addresses)
                //      {
                //          Console.WriteLine($"----- {address.AddressText}"); ;
                //      }

                //  }

                //var town = db.Towns.FirstOrDefault();
                //var entry = db.Entry(town);
                //town.Name = "Ivan";
                //entry = db.Entry(town);

                //db.SaveChanges();

                //var town = new Towns
                //{
                //    Name = "Sofia capital"
                //};
                //db.Towns.Add(town);
                //var entry = db.Entry(town);

                // var towns = db.Towns.ToList();

                //// db.Add(town);
                // db.SaveChanges();

                // foreach (var item in towns)
                // {
                //     Console.WriteLine(item.Name);
                // }

            }
            //using (var db = new SoftUniContext())
            //{
            //    var towns = db.Towns.ToList();
            //    Console.WriteLine(towns.Count);
            //}
        }
    }
}
