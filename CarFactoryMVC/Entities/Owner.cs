using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFactoryMVC.Entities
{
    public class Owner
    {

        public int Id { get; set; }

        public string Name { get; set; }

        //[ForeignKey("Car")]
        //public int? CarId { get; set; }

        [ValidateNever]
        public Car Car { get; set; }

        public Owner(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Owner()
        {

        }
    }
}