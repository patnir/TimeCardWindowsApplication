using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Data.OleDb;

public class clsTimeEntryList
{
    private string mConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" 
        + Path.Combine(Application.StartupPath, "TimeCard.accdb");

    public void AddEntry(clsTimeEntry entryToAdd)
    {
        clsJetDatabase db = new clsJetDatabase(mConnectionString);

        db.Open();
        entryToAdd.Insert(db);
        db.Close();
    }

    public void UpdateEntry(clsTimeEntry updatedEntry)
    {
        clsJetDatabase db = new clsJetDatabase(mConnectionString);

        db.Open();
        updatedEntry.Update(db);
        db.Close();
    }

    public void DeleteEntry(clsTimeEntry entryToDelete)
    {
        clsJetDatabase db = new clsJetDatabase(mConnectionString);

        db.Open();
        entryToDelete.Delete(db);
        db.Close();
    }

    public List<clsTimeEntry> GetAllEntries(DateTime beginDate, DateTime endDate)
    {
        clsJetDatabase db = new clsJetDatabase(mConnectionString);

        db.Open();

        string countSql = "SELECT COUNT (*) FROM TimeLogEntries WHERE (DateWorked >= " 
            + db.ToSql(beginDate) + ") AND (DateWorked <= " + db.ToSql(endDate) + ")";

        int total_Records = (int)db.ExecuteScalar(countSql);

        if (total_Records > 500)
        {
            throw new clsTooManyRecordsException("Over 500 records found.");
        }

        string sql = "SELECT * FROM TimeLogEntries WHERE (DateWorked >= " + db.ToSql(beginDate)
                + ") AND (DateWorked <= " + db.ToSql(endDate) + ")";

        clsJetQueryResults results = new clsJetQueryResults();
        results.Open(db, sql);

        List<clsTimeEntry> timeEntryList = new List<clsTimeEntry>();

        while (results.EOF == false)
        {
            clsTimeEntry entry = new clsTimeEntry();
            entry.RestoreStateFromQuery(results);
            timeEntryList.Add(entry);
            
            results.MoveNext();
        }

        results.Close();
        db.Close();

        return timeEntryList;
    }
}