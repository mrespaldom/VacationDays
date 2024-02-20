using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VacationsDays.Models
{
    public class DayData
    {
        public int Id { get; set; } 
        public int DayOfYear { get; set; }
        public bool IsCheckedV { get; set; }
        public bool IsCheckedCH { get; set; }
    }

}
