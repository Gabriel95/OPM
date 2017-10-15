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
                config.CreateMap<PatientModel, Patient>().ForMember(x => x.PatientId, y => y.Ignore());
                config.CreateMap<Patient, PatientModel>();
            });
        }
    }
}