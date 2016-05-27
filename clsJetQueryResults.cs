using System;
using System.Data.OleDb;

public class clsJetQueryResults
{
    private bool mEOF;
    private OleDbDataReader mDataReader = null;

    // Returns true when there are no more records/rows in the query results.
    public bool EOF
    {
        get
        {
            return mEOF;
        }
    }

    // Performs a query and sets the current record/row pointer to the first one.
    public void Open(clsJetDatabase db, string sqlQuery)
    {
        mDataReader = db.ExecuteQuery(sqlQuery);
        MoveNext();
    }

    // Moves to the next record/row and sets the EOF property.
    public void MoveNext()
    {
        if (mDataReader.Read() == true)
        {
            mEOF = false;
        }
        else
        {
            mEOF = true;
        }
    }

    // Closes the query results.
    public void Close()
    {
        mDataReader.Close();
    }

    // Returns a reference to the value of the column name passed.  If
    // the value is null, a reasonable non-null value is returned instead.
    public object GetColValue(string columnName)
    {
        int columnNumber = mDataReader.GetOrdinal(columnName);

        if (mDataReader.IsDBNull(columnNumber) == false)
        {
            return mDataReader.GetValue(columnNumber);
        }

        string check = mDataReader.GetDataTypeName(columnNumber);

        switch (mDataReader.GetDataTypeName(columnNumber))
        {
            case "DBTYPE_I4": return 0;	// int

            case "DBTYPE_R4": return 0f; // DateTime

            case "DBTYPE_DATE": return new DateTime(9999, 12, 31);

            case "DBTYPE_WLONGVARCHAR": return "No data entered for description. This description requires characters.";

            case "DBTYPE_WVARCHAR": return "NoIDEntered";

            default:
                throw new Exception("Unexpected database type "
                    + columnName + " = " + mDataReader.GetDataTypeName(columnNumber));
        }
    }
}
