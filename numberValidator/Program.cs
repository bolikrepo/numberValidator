using System;

namespace numberValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleVinOperations operations = new VehicleVinOperations();

            operations.CheckVIN("MHMCM56557C404453");
        }
    }
}
