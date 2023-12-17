using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_App.Models.Persons.PatientEntities
{
    public class PatientCard
    {
            public int Id { get; set; }
            public required List<DiseaseHistory> DiseaseHistories { get; set; }
    }
}