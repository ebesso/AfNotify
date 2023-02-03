using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class CreateNotificationDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public int MinRent { get; set; } = 0;

        [Required]
        public int MaxRent { get; set; } = 100000;

        [Required]
        public bool Apartment { get; set; } = false;

        [Required]
        public bool Corridor { get; set; } = false;

        [Required]
        public int MaxRooms { get; set; } = 100;

        [Required]
        public int MinRooms { get; set; } = 0;

        [Required]
        public int MinFloor { get; set; } = 0;

        [Required]
        public int MaxRentalPeriods { get; set; } = 12;

        [Required]
        public bool NovischPriority { get; set; } = false;

        [Required]
        public bool FurnitureIncluded { get; set; } = false;

        [Required]
        public double MinSize { get; set; } = 0;

        [Required]
        public double MaxSize { get; set; } = 1000;

        [Required]
        public List<string> Areas { get; set; } = new List<string>();
    }
}
