using IssaWPF6.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IssaWPF6.Models
{
    public class ColonDto
    {
        public ColonDto()
        {
            
        }
        public ColonDto(Colon colon)
        {
            Id = colon.Id;
            Name = colon.Name;
            Age = colon.Age;
            Gender = colon.Gender;
            FileNo = colon.FileNo;
            Date = colon.Date.ToString("dd-MM-yyyy");
            Premedication = colon.Premedication;
            Scope = colon.Scope;
            ReferredDoctor = colon.ReferredDoctor;
            ClinicalData = colon.ClinicalData;
            Preparation = colon.Preparation;
            AnalInspection = colon.AnalInspection;
            PRExam = colon.PRExam;
            Ileum = colon.Ileum;
            ColonDetails = colon.ColonDetails;
            Rectum = colon.Rectum;
            Conclusion = colon.Conclusion;
            Assistant = colon.Assistant;
            Endoscopist = colon.Endoscopist;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string FileNo { get; set; }
        public string Date { get; set; }
        public string Premedication { get; set; }
        public string Scope { get; set; }
        public string ReferredDoctor { get; set; }
        public string ClinicalData { get; set; }
        public string Preparation { get; set; }
        public string AnalInspection { get; set; }
        public string PRExam { get; set; }
        public string Ileum { get; set; }
        public string ColonDetails { get; set; }
        public string Rectum { get; set; }
        public string Conclusion { get; set; }
        public string Assistant { get; set; }
        public string Endoscopist { get; set; }
    }
    public class StomachDto
    {
        public StomachDto()
        {
            
        }
        public StomachDto(Stomach stomach)
        {
            Id = stomach.Id;
            Name = stomach.Name;
            Age = stomach.Age;
            Gender = stomach.Gender;
            FileNo = stomach.FileNo;
            Date = stomach.Date.ToString("dd-MM-yyyy");
            Premedication = stomach.Premedication;
            Scope = stomach.Scope;
            ReferredDoctor = stomach.ReferredDoctor;
            ClinicalData = stomach.ClinicalData;
            GEJ = stomach.GEJ;
            Esophagus = stomach.Esophagus;
            StomachDetails = stomach.StomachDetails;
            D1 = stomach.D1;
            D2 = stomach.D2;
            Conclusion = stomach.Conclusion;
            Assistant = stomach.Assistant;
            Endoscopist = stomach.Endoscopist;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string FileNo { get; set; }
        public string Date { get; set; }
        public string Premedication { get; set; }
        public string Scope { get; set; }
        public string ReferredDoctor { get; set; }
        public string ClinicalData { get; set; }
        public string GEJ { get; set; }
        public string Esophagus { get; set; }
        public string StomachDetails { get; set; }
        public string D1 { get; set; }
        public string D2 { get; set; }
        public string Conclusion { get; set; }
        public string Assistant { get; set; }
        public string Endoscopist { get; set; }
    }
}
