using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int MinRent { get; set; }

        [Required]
        public int MaxRent { get; set; }

        [Required]
        public bool Apartment { get; set; }

        [Required]
        public bool Corridor { get; set; }

        [Required]
        public int MaxRooms { get; set; }

        [Required]
        public int MinRooms { get; set; }

        [Required]
        public int MinFloor { get; set; }

        [Required]
        public int MaxRentalPeriods { get; set; }

        [Required]
        public bool NovischPriority { get; set; }

        [Required]
        public bool FurnitureIncluded { get; set; }

        [Required]
        public double MinSize { get; set; }

        [Required]
        public double MaxSize { get; set; }

        [Required]
        public virtual ICollection<Area> Areas { get; set; }
    }
}
