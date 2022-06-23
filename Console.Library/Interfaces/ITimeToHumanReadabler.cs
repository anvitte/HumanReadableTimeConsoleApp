using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Library.Interfaces
{
    /// <summary>
    /// This interface give the declaration of Time to Human Readable Converter
    /// </summary>
    public  interface ITimeToHumanReadable
    {
         void ConvertTimeToHumanReadble(string userInputTime);
         string ReturnHumanReadableTime();
    }
}
