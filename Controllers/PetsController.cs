using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context)
        {
            _context = context;
        }

        // get all pets
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return _context.Pets

            .Include(pet => pet.ownedBy);
        }

        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }

        // /api/pets/:id
        [HttpPut("{id}")]
        public Pet Put (int id, Pet pet)
        {

            pet.id = id;

            _context.Update(pet);

            _context.SaveChanges();

            return pet;
        }

        // // /api/pets/:id/checkin
        // [HttpPut("{id}/checkin")]
        // public Pet ChangeCheckedInAt(int id, Date checkedInAt)
        // {

        //     pet.checkedInAt = pet.checkedInAt;

        //     _context.Update(pet.checkedInAt);

        //     _context.SaveChanges();

        //     return pet;
        // }

        // // /api/pets/:id/checkout
        // [HttpPut("{id}")]
        // public Pet Put (int id, Pet pet)
        // {

        //     pet.id = id;

        //     _context.Update(pet);

        //     _context.SaveChanges();

        //     return pet;
        // }


    
        //get pet owner by id
        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id)
        {
            Pet pet = _context.Pets
                .SingleOrDefault(pet => pet.id == id);

            if(pet == null){
                return NotFound();
            }

            return pet;
        }
    }
}
