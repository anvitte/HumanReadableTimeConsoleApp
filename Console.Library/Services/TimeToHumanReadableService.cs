using System;
using System.Diagnostics.CodeAnalysis;
using Console.Library.Models;
using ConsoleApp.Library.Helper;
using ConsoleApp.Library.Interfaces;
using Humanizer;

namespace ConsoleApp.Library.Services
{
    /// <summary>
    /// It will convert time to human readable string
    /// </summary>
    public class TimeToHumanReadableService : ITimeToHumanReadable
    {
        private TimeModel? objTime = null;
        private string? _humanReadableMessage { get; set; }
        public TimeToHumanReadableService() => objTime = new();
        /// <summary>
        ///  This method will convert the time into human readable format
        /// </summary>
        /// <param name="UserInputTime">User will input the time</param>
        public void ConvertTimeToHumanReadble(string UserInputTime)
        {
            try
            {
                var time = Convert.ToDateTime(UserInputTime).ToString("hh:mm");
                objTime.HourAndMin = time.Split(':');// Splitting objTime.Hour and objTime.Min
                objTime.Hour = int.Parse(objTime.HourAndMin[0]); // Assigning objTime.Hour
                objTime.Min = int.Parse(objTime.HourAndMin[1]); // Assigning objTime.Min

                if (Constant.ZeroMinClock == objTime.HourAndMin[1]) // Checking Zero Mins - 00
                {
                    _humanReadableMessage = string.Join(" ", objTime.Hour.ToWords().Pascalize(), Constant.ZeroMinClockMessage);
                }
                else if (objTime.Min > 30 && objTime.Min < 60)// checking if objTime.Min is greater than 30 and smaller than 60
                {
                    if (objTime.Hour < 11)
                        objTime.Hour = objTime.Hour + 1;
                    else
                        objTime.Hour = 0;

                    objTime.Min = 60 - objTime.Min;
                    _humanReadableMessage = string.Join(" ", objTime.Min.ToWords().Pascalize(), Constant.AfterThirty, objTime.Hour.ToWords());

                }
                else if (objTime.Min == 30) // checking the objTime.Min equal to 30
                {
                    _humanReadableMessage = string.Join(" ", Constant.HalfPastMessage, objTime.Hour.ToWords());
                }
                else // checking objTime.Min is smaller than 30 and greater than zero and not equal to "00"
                {
                    _humanReadableMessage = string.Join(" ", objTime.Min.ToWords().Pascalize(), Constant.BeforeThirty, objTime.Hour.ToWords());
                }

            }
            catch (Exception ex)
            {
                _humanReadableMessage = ex.Message;
            }
        }


        /// <summary>
        /// This method will return the human readable time
        /// </summary>
        /// <returns>Return human readable text</returns>
        public string ReturnHumanReadableTime()
        {
            return _humanReadableMessage;

        }
    }
}
