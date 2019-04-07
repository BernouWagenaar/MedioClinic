using CMS.DocumentEngine;
using System;

namespace Business.Dto.Doctors
{
    /// <summary>
    /// Example of the doctor data object
    /// </summary>
    public class DoctorDto
    {
        public int NodeId { get; set; }
        public Guid NodeGuid { get; set; }
        public string NodeAlias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Degree { get; set; }
        public DocumentAttachment Photo { get; set; }
        public string Specialty { get; set; }
        public string Bio { get; set; }
        public int EmergencyShift { get; set; }

        // Defines doctor's full name
        public string FullName => $"{FirstName} {LastName}";

        // Determines whether the doctor has emergency shift
        public bool HasShiftToday => EmergencyShift == (int)DateTime.Now.DayOfWeek;
    }
}
