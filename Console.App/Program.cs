namespace Console.App
{
    using ConsoleApp.Library.Interfaces;
    using ConsoleApp.Library.Helper;
    using ConsoleApp.Library.Services;
    using System;

    /// <summary>
    /// This program is written to convert the time into human readable format
    /// </summary>
    internal class Program
    {
        public static ITimeToHumanReadable _iTimetoHumanReadable { get; set; }
        static Program()
        {
            _iTimetoHumanReadable = new TimeToHumanReadableService();
        }
        static void Main(string[] args)
        {
            try
            {

                //Objective 1
                Console.WriteLine("<------------------- Objective 1 ------------------->");
                string objective1Input = System.DateTime.Now.ToString("hh:mm");
                _iTimetoHumanReadable.ConvertTimeToHumanReadble(objective1Input);
                string humanReadableMessageOutputObjective1 = _iTimetoHumanReadable.ReturnHumanReadableTime();
                Console.WriteLine(humanReadableMessageOutputObjective1);

                //Objective 2      
                Console.WriteLine("<------------------- Objective 2 ------------------->");
                Console.WriteLine("Enter the time in the format (hh:mm)");
                string? objective2Input = Console.ReadLine();

                if (objective2Input != null)
                {
                    _iTimetoHumanReadable.ConvertTimeToHumanReadble(objective2Input);
                    string humanReadableMessageOutputObjective2 = _iTimetoHumanReadable.ReturnHumanReadableTime();
                    Console.WriteLine(humanReadableMessageOutputObjective2);
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Message {0}", ex.Message);
            }
            Console.ReadKey();
        }
    }
}