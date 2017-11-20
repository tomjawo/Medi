using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Medi.Models
{
    public class Examination
    {
        public enum ExamType
        {
            Ogólne,
            BadaniaKrwi,
            BadanieMoczu,
            Prześwietlenie,
            Elektokardiogram
        }
     
        public int Id { get; set; }
        public ExamType ExaminationTape { get; set; }
        public ApplicationUser OrderedBy { get; set; }
        public DateTime OrderedDate{ get; set; }
        public ApplicationUser PreparedBy { get; set; }
        public DateTime PreparedDate { get; set; }
        public string Description { get; set; }
        public List<String> FileUrls { get; set; }


        public List<ApplicationUser> Users { get; set; }
    }



    public class ExaminationViewModel
    {
        public Examination Exam { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }


}