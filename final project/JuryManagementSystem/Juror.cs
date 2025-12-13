using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinalProject
{
    /// <summary>
    /// Represents one individual juror in the system
    /// </summary>
    public class Juror
    {
        public string FullName { get; set; } //Juror's full name
        public DateTime SummonsDate { get; set; } //When the juror has to show up to court

        //Constructor with validation
        public Juror(string fullName, DateTime summonsDate)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            FullName = fullName;
            SummonsDate = summonsDate;
        }
    }
}