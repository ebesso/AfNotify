using System;
using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace Core.Entities
{
    public class Unit
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public UnitType UnitType { get; set; }

        [Required]
        public int Rooms { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public int Floor { get; set; }

        [Required]
        public double Size { get; set; }

        [Required]
        public int RentalPeriods { get; set; }

        [Required]
        public DateTime ReservationDeadline { get; set; }

        [Required]
        public bool NovishPriority { get; set; }

        [Required]
        public int Rent { get; set; }

        [Required]
        public bool FurnitureIncluded { get; set; }
    }
}
