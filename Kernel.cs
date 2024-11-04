using Cosmos.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace AxonOS
{
    public class Kernel : Sys.Kernel
    {

        static uint maxmem = CPU.GetAmountOfRAM();
        static ulong availableMem = GCImplementation.GetAvailableRAM();
        static ulong usedmem = maxmem - availableMem;

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("AXON");
            Console.WriteLine("Created by AndrewNova");
            Console.WriteLine("v0.0.0");
            Console.WriteLine(" ");
        }

        protected override void Run()
        {
            Console.Write("$ >");

            string input = Console.ReadLine()?.ToLower();

            switch (input)
            {
                case "help":
                    DisplayHelp();
                    break;
                case "systeminfo":
                    DisplayAbout();
                    break;
                case "shutdown":
                    ShutdownSystem();
                    break;
                case "reboot":
                    RebootSystem();
                    break;
                default:
                    Console.WriteLine("Unknown command. Type 'help' for a list of commands.");
                    break;
            }
        }

        private void DisplayHelp()
        {
            Console.WriteLine("Available Commands:");
            Console.WriteLine("help     - Displays this help message");
            Console.WriteLine("systeminfo    - Shows information about AxonOS");
            Console.WriteLine("shutdown - Shuts down the system");
            Console.WriteLine("reboot   - Restarts the system");
        }

        private void DisplayAbout()
        {
            Console.WriteLine("Operating System Info");
            Console.WriteLine(" ");
            Console.WriteLine("AxonOS v0.0.0");
            Console.WriteLine("Developed by AndrewNova");
            Console.WriteLine("An operating system built using Cosmos.");
            Console.WriteLine(" ");
            Console.WriteLine(" Computer Info ");
            Console.WriteLine(" ");
            Console.WriteLine($"CPU: {CPU.GetCPUBrandString()}");
            Console.WriteLine($"RAM: {usedmem}/{maxmem}MB");




        }

        private void ShutdownSystem()
        {
            Console.WriteLine("Shutting down...");
            Sys.Power.Shutdown();
        }

        private void RebootSystem()
        {
            Console.WriteLine("Rebooting...");
            Sys.Power.Reboot();
        }
    }
}
