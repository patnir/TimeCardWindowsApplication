using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeCardAppLogic
{
    [Table("TimeLogHistory")]
    public class clsTimeHistory
    {
        [Key]
        public int HistoryID { get; set; }
        [Column, Required]
        public DateTime HistoryDateTime { get; set; }
        [Column, Required, MaxLength(255)]
        public string UserID { get; set; }
        [Column, Required]
        public string SQLCommand { get; set; }
    }
}