using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeCardAppLogic
{
    [Table("TimeLogEntries")]
    public class clsTimeEntry
    {
        [Key]
        public int EntryID { get; set; }
        [Column, Required, MaxLength(10)]
        public string EmployeeID { get; set; }
        [Column, Required]
        public DateTime DateWorked { get; set; }
        [Column("HoursWorked"), Required]
        public double NumberOfHoursWorked { get; set; }
        [Column("Billable"), Required]
        public bool BillableIndicator { get; set; }
        [Column, Required, MinLength(25)]
        public string Description { get; set; }
        [Column]
        public DateTime DateTimeLastMaint { get; set; }
    }
}
