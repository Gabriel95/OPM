using System.ComponentModel.DataAnnotations;

namespace OpmData
{
    public class Refraction
    {
        [Key]
        public int RefractionId { get; set; }
        public double Spherical { get; set; }
        public double Cilinder { get; set; }
        public double Edge { get; set; }
        public double Additional { get; set; }
        public string FarVisualAcuity { get; set; }
        public string CloseVisualAcuity { get; set; }

    }
}