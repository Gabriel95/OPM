using AutoMapper;
using OpmData;
using OpmPatientsSite.Models.Patient;

namespace OpmPatientsSite
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<PatientModel, Patient>();
                config.CreateMap<Patient, PatientModel>();
            });
        }
    }
}