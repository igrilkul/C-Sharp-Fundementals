using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IBus:IVehicle
    {
        void DrivingWithPeople(double distance);
        void DrivingWithoutPeople(double distance);
    }
}
