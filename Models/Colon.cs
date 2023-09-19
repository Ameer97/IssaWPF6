using IssaWPF6.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssaWPF6.Models
{
    public class Colon
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? FileNo { get; set; }
        public DateTime? Date { get; set; }
        public string? Premedication { get; set; }
        public string? Scope { get; set; }
        public string? ReferredDoctor { get; set; }
        public string? ClinicalData { get; set; }
        public string? Preparation { get; set; }
        public string? AnalInspection { get; set; }
        public string? PRExam { get; set; }
        public string? Ileum { get; set; }
        public string? ColonDetails { get; set; }
        public string? Rectum { get; set; }
        public string? Conclusion { get; set; }
        public string? Assistant { get; set; }
        public string? Endoscopist { get; set; }

        public int TypePhoto => 1;
    }
    public class Stomach
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? FileNo { get; set; }
        public DateTime? Date { get; set; }
        public string? Premedication { get; set; }
        public string? Scope { get; set; }
        public string? ReferredDoctor { get; set; }
        public string? ClinicalData { get; set; }
        public string? GEJ { get; set; }
        public string? Esophagus { get; set; }
        public string? StomachDetails { get; set; }
        public string? D1 { get; set; }
        public string? D2 { get; set; }
        public string? Conclusion { get; set; }
        public string? Assistant { get; set; }
        public string? Endoscopist { get; set; }

        public int TypePhoto => 0;

        //public List<Photo> Photos { get; set; } = new List<Photo>();
        //public List<Photo> GetPhotos()
        //{
        //    return new ApplicationDbContext().Photos.Where(x => x.TypeId == 0 && x.ObjectId == Id).ToList();
        //}
        //public void SetPhotos(ApplicationDbContext context, List<Photo> photos)
        //{
        //    photos.ForEach(x =>
        //    {                           ///micanisim for add path to photo
        //        x.TypeId = 0;
        //        x.ObjectId = Id;
        //    });
        //    context.Photos.AddRange(photos);
        //    context.SaveChanges();

        //}
    }

    public class Photo
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public byte[]? Data { get; set; }
    }
}
