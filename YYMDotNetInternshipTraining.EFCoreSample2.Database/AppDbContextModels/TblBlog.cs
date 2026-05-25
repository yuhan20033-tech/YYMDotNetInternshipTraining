using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YYMDotNetInternshipTraining.EFCoreSample2.Database.AppDbContextModels
{
    // အပြင်က Project တွေကပါ လှမ်းသုံးနိုင်အောင် 'public' ပြောင်းပေးထားပါတယ်
    public class TblBlog
    {
        [Key] // Database ရဲ့ Primary Key ဖြစ်ကြောင်း သတ်မှတ်ခြင်း
        public int BlogId { get; set; }

        public string BlogTitle { get; set; }

        public string BlogAuthor { get; set; }

        public string BlogContent { get; set; }
    }
}