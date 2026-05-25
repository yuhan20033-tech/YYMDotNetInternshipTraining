using System;
using System.ComponentModel.DataAnnotations;

namespace YYMDotNetInternshipTraining.EFCoreSample2.Database.AppDbContextModels
{
    public class TblStudent
    {
        [Key] // Database ရဲ့ Primary Key ဖြစ်ကြောင်း သတ်မှတ်ခြင်း
        public int StudentId { get; set; }

        public string StudentNo { get; set; }

        public string StudentName { get; set; }

        public string FatherName { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public string? ModifiedBy { get; set; }
    }
}