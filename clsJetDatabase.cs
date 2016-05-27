using System;
using System.Data.OleDb;

public class clsJetDatabase
{
    private OleDbConnection mDBConn = null;

    public clsJetDatabase(string connectionString)
    {
        mDBConn = new OleDbConnection();
        mDBConn.ConnectionString = connectionString;
    }

    public void Open()
    {
        mDBConn.Open();
    }

    public void Close()
    {
        mDBConn.Close();
    }

    public int ExecuteSQL(string sqlStatement)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = mDBConn;
        cmd.CommandText = sqlStatement;
        return cmd.ExecuteNonQuery();
    }

    public OleDbDataReader ExecuteQuery(string sqlQuery)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = mDBConn;
        cmd.CommandText = sqlQuery;
        return cmd.ExecuteReader();
    }

    public string ToSql(string value)
    {
        return "'" + value.Replace("'", "''") + "'";
    }
    public string ToSql(double value)
    {
        return value.ToString();
    }
    public string ToSql(DateTime value)
    {
        return "#" + value.ToString("yyyy-MM-dd HH:mm:ss") + "#";
    }
    public string ToSql(bool value)
    {
        return value.ToString();
    }
}
