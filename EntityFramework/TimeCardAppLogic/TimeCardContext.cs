namespace TimeCardAppLogic
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TimeCardContext: DbContext
    {
        public TimeCardContext()
            : base("Server=SUNITA\\SQLEXPRESS;Database=TimeCard5000;Trusted_Connection=True")
        {

        }

        public virtual DbSet<clsTimeEntry> TimeCardEntries { get; set; }
    }
}