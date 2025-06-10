using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayChecker.Data
{
    public class BirthdayService
    {
        // In-memory store for birthdays
        private static List<Birthday> Birthdays { get; set; } = new List<Birthday>();

        /// <summary>
        /// Retrieves a new list containing all current birthday entries.
        /// Returning a new list (.ToList()) prevents external modification of the internal list.
        /// </summary>
        /// <returns>A list of birthdays.</returns>
        public List<Birthday> GetBirthdays()
        {
            return Birthdays.ToList(); // Return a copy
        }

        /// <summary>
        /// Adds a new birthday to the in-memory store.
        /// </summary>
        /// <param name="birthday">The birthday entry to add.</param>
        public void AddBirthday(Birthday birthday)
        {
            if (birthday != null)
            {
                Birthdays.Add(birthday);
            }
        }
    }
}
