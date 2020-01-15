using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using PetClinic.Models;

namespace PetClinic.DataProcessor
{
    using System;

    using PetClinic.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        //Record {animal aid name} successfully imported.
        private const string SuccessfulImportAnimalAids  
            = "Record {0} successfully imported.";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";
        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var animalAids = JsonConvert.DeserializeObject<AnimalAid[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<AnimalAid> animal = new List<AnimalAid>();
            
            foreach (var animalAid in animalAids)
            {
                if (!IsValid(animalAid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                animal.Add(animalAid);
                sb.AppendLine(String.Format(SuccessfulImportAnimalAids, animalAid.Name));
            }
            //
            context.AnimalAids.AddRange(animal);
            context.SaveChanges();
            
            //Record {animal aid name} successfully imported. 
            var result = sb.ToString().ToString();
            return result;
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            throw new NotImplementedException();
        }
        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return result;
        }
    }
}
