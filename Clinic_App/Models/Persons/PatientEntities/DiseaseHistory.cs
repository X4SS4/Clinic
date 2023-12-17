using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_App.Models.Persons.PatientEntities
{
    public class DiseaseHistory
    {
        public int Id { get; set; }
        public string? DiseaseName { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}