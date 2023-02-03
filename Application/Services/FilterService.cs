using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Enums;

namespace Application.Services
{
    public class FilterService : IFilterService
    {
        public List<Unit> Filter(List<Unit> units, Notification notification)
        {
            var matched = new List<Unit>();

            foreach(var unit in units)
            {
                if(notification.MinFloor <= unit.Floor)
                {
                    if((notification.FurnitureIncluded && notification.FurnitureIncluded) || !notification.FurnitureIncluded)
                    {
                        if(unit.Rent <= notification.MaxRent && unit.Rent >= notification.MinRent)
                        {
                            if(unit.Size <= notification.MaxSize && unit.Size >= notification.MinSize)
                            {
                                if(unit.Rooms <= notification.MaxRooms && unit.Rooms >= notification.MinRooms)
                                {
                                    if(unit.RentalPeriods <= notification.MaxRentalPeriods)
                                    {
                                        if((notification.Corridor && notification.Apartment) ||
                                            (unit.UnitType == UnitType.Appartment && notification.Apartment) ||
                                            (unit.UnitType == UnitType.Corridor && notification.Corridor))
                                        {
                                            if(unit.NovishPriority == notification.NovischPriority)
                                            {
                                                if(notification.Areas.Count == 0 ||
                                                    notification.Areas.Count(a => a.Name == unit.Area) > 0)
                                                {
                                                    matched.Add(unit);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return matched;
        }
    }
}
