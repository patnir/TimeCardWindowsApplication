using System.Collections.Generic;
using System;
using TimeCardAppLogic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;

public class clsTimeEntryList
{
    public static string UserID;

    public List<clsTimeEntry> GetAllEntries(DateTime beginDate, DateTime endDate)
    {
        using (TimeCardContext context = new TimeCardContext())
        {
            IQueryable<clsTimeEntry> query =
                from entry in context.TimeCardEntries
                where entry.DateWorked >= beginDate && entry.DateWorked <= endDate
                orderby entry.EntryID
                select entry;

            int count = query.Count();

            if (count > 500)
            {
                throw new clsTooManyRecordsException("More than 500 records found.");
            }

            return query.ToList();
        }
    }

    public void DeleteEntry(clsTimeEntry entryToDelete)
    {
        using (TimeCardContext context = new TimeCardContext())
        {
            clsTimeEntry entry = context.TimeCardEntries.FirstOrDefault(e => e.EntryID == entryToDelete.EntryID);
            if (entry == null)
            {
                throw new Exception(string.Format("Entry for EntryID \"{0}\" was not found.", entryToDelete));
            }
            context.TimeCardEntries.Remove(entry);
            context.SaveChanges();
        }
    }

    public void AddEntry(clsTimeEntry newEntry)
    {
        using (TimeCardContext context = new TimeCardContext())
        {
            newEntry.DateTimeLastMaint = DateTime.Now.Date;
            context.TimeCardEntries.Add(newEntry);
            context.SaveChanges();
        }
    }

    public void UpdateEntry(clsTimeEntry updatedEntry)
    {
        using (TimeCardContext context = new TimeCardContext())
        {
            DbEntityEntry<clsTimeEntry> entry = context.Entry(updatedEntry);
            if (entry == null)
            {
                context.TimeCardEntries.Attach(updatedEntry);
                entry = context.Entry(updatedEntry);
            }
            entry.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}