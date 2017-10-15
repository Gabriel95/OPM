using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpmPatientsSite.Models.Record
{
    public class NewRecordModel
    {
        public int PatientId { get; set; }
        public int CreatedById { get; set; }
        public string Observations { get; set; }
        public string PreviousRx { get; set; }
        public double DIP { get; set; }
        public string LenseType { get; set; }
        public double LeftBifocalHeight { get; set; }
        public double LeftSpherical { get; set; }
        public double LeftCilinder { get; set; }
        public double LeftEdge { get; set; }
        public double LeftAdditional { get; set; }
        public string LeftFarVisualAcuity { get; set; }
        public string LeftCloseVisualAcuity { get; set; }
        public double RighttBifocalHeight { get; set; }
        public double RightSpherical { get; set; }
        public double RightCilinder { get; set; }
        public double RightEdge { get; set; }
        public double RightAdditional { get; set; }
        public string RightFarVisualAcuity { get; set; }
        public string RightCloseVisualAcuity { get; set; }
    }
}