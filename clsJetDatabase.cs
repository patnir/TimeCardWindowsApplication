﻿using System;
using System.Data.OleDb;

public class clsJetDatabase
{
    private OleDbConnection mDBConn = null;

    public clsJetDatabase(string fullFileName)
    {
        string connectionString = getConnectionString(fullFileName);
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

    public object ExecuteScalar(string sqlQuery)
    {
        OleDbCommand cmd = new OleDbCommand();
        cmd.Connection = mDBConn;
        cmd.CommandText = sqlQuery;
        return cmd.ExecuteScalar();
    }

    // Moved connection string here to accomodate different databases

    private string getConnectionString(string fullFileName)
    {
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fullFileName;
        return connectionString;
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
