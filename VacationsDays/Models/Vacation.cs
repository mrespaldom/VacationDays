
using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VacationsDays.Models
{

    public class Vacation
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }
        
        public DateTime Date_Time { get; set; }

        [DisplayName("Remaining days")]
        [Range(-100, 100, ErrorMessage = "Days out of range!")]
        public int? RemainingDays { get; set; }

        [DisplayName("2024 Total days")]
        [Range(0, 100, ErrorMessage = "Days out of range!")]
        public int TotalDays { get; set; }
        
        [DisplayName("Booked days")]
        [Range(0, 100, ErrorMessage = "Days out of range!")]
        public int BookedDays { get; set; }

        [DisplayName("Company Holidays")]
        [Range(0, 100, ErrorMessage = "Days out of range!")]
        public int ChDays { get; set; }

        [DisplayName("Vacation Total days")]
        [Range(0, 100, ErrorMessage = "Days out of range!")]
        public int VacTotalDays { get; set; }

        [DisplayName("Legal Vacation 2023")]
        [Range(0, 100, ErrorMessage = "Days out of range!")]
        public int LegalVacYearBef { get; set; }

        [DisplayName("Legal Vacation 2023 H2")]
        [Range(0, 100, ErrorMessage = "Days out of range!")]
        public int LegalVacYearBefH2 { get; set; }

        [DisplayName("Legal Vacation 2024")]
        [Range(0, 100, ErrorMessage = "Days out of range!")]
        public int LegalVacYear { get; set; }

        public int? SelectedDays { get; set; }

        public string? BlokedJson { get; set; }

        
    }
   

}



