using System;

namespace numberValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleVinOperations operations = new VehicleVinOperations();

            operations.CheckVIN("JHMCM56557C404453");
        }
    }
}
