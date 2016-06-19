using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp
{
    public class TimeSheet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string volunteerId { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        
        //public Admin SignoffAdmin { get; set; }

        public string Description { get; set; }
        
    }
}
