using System;

public class clsTimeEntry
{
    private int EntryID;
    public string EmployeeID;
    public float NumberOfHoursWorked;
    public DateTime DateWorked;
    public bool BillableIndicator;
    public string Description;

    public string Serialize()
    {
        return EntryID.ToString() + '\t'
            + EmployeeID + '\t'
            + DateWorked.ToString() + '\t'
            + NumberOfHoursWorked.ToString() + '\t'
            + BillableIndicator.ToString() + '\t'
            + Description;
    }

    public void Deserialize(string serializedEntry)
    {
        string[] values = serializedEntry.Split('\t');

        EntryID = int.Parse(values[0]);
        EmployeeID = values[1];
        DateWorked = DateTime.Parse(values[2]);
        NumberOfHoursWorked = float.Parse(values[3]);
        BillableIndicator = bool.Parse(values[4]);
        Description = values[5];
    }

    public void CopyTo(clsTimeEntry entry)
    {
        string myState = Serialize();
        entry.Deserialize(myState);
    }

    public void Insert(clsJetDatabase db) 
    {
        // Insert SQL statement

        string sql = "INSERT INTO TimeLogEntries ("
            + "EmployeeID, " + "DateWorked, " + "HoursWorked, " + "Billable, "
            + "Description" + ") VALUES ("

        + db.ToSql(EmployeeID) + ", "
        + db.ToSql(NumberOfHoursWorked) + ", "
        + db.ToSql(DateWorked) + ", "
        + db.ToSql(BillableIndicator) + ", "
        + db.ToSql(Description) + ", "
        + ")";

        db.ExecuteSQL(sql);
    }

    public void Delete(clsJetDatabase db)
    {
        string sql = "DELETE FROM ZipCodes WHERE ZipCode = " + db.ToSql(EntryID);

        db.ExecuteSQL(sql);
    }

    public void Update(clsJetDatabase db)
    {
        // Update SQL statement

        string sql = "UPDATE TimeLogEntries SET "
           + "EmployeeID = " + db.ToSql(EmployeeID) + ", "
           + "HoursWorked = " + db.ToSql(NumberOfHoursWorked) + ", "
           + "DateWorked = " + db.ToSql(DateWorked) + ", "
           + "Billable = " + db.ToSql(BillableIndicator) + ", "
           + "Description = " + db.ToSql(Description)

           + " WHERE EntryID = " + db.ToSql(EntryID);

        db.ExecuteSQL(sql);
    }

    public void RestoreStateFromQuery(clsJetQueryResults results)
    {
        EntryID = (int)results.GetColValue("EntryID");
        EmployeeID = (string)results.GetColValue("EmployeeID");
        NumberOfHoursWorked = (float)results.GetColValue("HoursWorked");
        DateWorked = (DateTime)results.GetColValue("DateWorked");
        BillableIndicator = (bool)results.GetColValue("Billable");
        Description = (string)results.GetColValue("Description");
    }
}