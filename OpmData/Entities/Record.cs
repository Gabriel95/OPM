using OpmData.Entities;
using System.ComponentModel.DataAnnotations;

namespace OpmData
{
    public class Record
    {
        [Key]
        public int RecordId { get; set; }
        public Patient Patient { get; set; }
        public User CreatedBy { get; set; }
        public string Observations { get; set; }
        public string PreviousRx { get; set; }
        public Refraction RightEye { get; set; }
        public Refraction LeftEye { get; set; }
        public double DIP { get; set; }
        public string LenseType { get; set; }
        public double BifocalHeight { get; set; }
    }
}
