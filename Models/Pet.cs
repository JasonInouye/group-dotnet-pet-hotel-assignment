using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType {
        Shepherd, Poodle, Beagle, Bulldog, Terrier, Boxer, Labrador, Retriever
    }
    public enum PetColorType {
        White, Black, Golden, Tricolor, Spotted
    }
    public class Pet {
        public int id {get; set;}

        [Required]
        public string name {get; set;}

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreedType petBreed {get; set;}

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]

        public PetColorType petColor {get; set;}

        public DateTime checkedInAt {get; set;}

        [ForeignKey("ownedBy")]
        public int petOwnerId {get; set;}

        public PetOwner ownedBy {get; set;}
    }
}

// int id: primary key
// string name (required): The pet name
// PetBreed breed (required): Pet breed, based on the PetBreed enum.
// PetColor color (required): Pet color, based on the PetColor enum.
// DateTime checkedInAt (nullable): The time that this pet was checked in. If null, the pet has not been checked in yet.
// int petOwnerid (required): A foreign key link to the pet owner that owns this pet. Set up the foriegn key link with a PetOwner petOwner property on the Pet model