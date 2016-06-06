using System;
using System.Data;
using MySql.Data.MySqlClient;

internal class clsMySqlDatabase
{
    private MySqlConnection mConnection = new MySqlConnection
        ("Server=localhost;Port=3306;Database=timecard5000;Uid=root;Pwd=mysql");

    private MySqlTransaction mTransaction = null;

    internal void Open()
    {
        if (mConnection.State == ConnectionState.Closed)
        {
            mConnection.Open();
        }
    }

    internal void Close()
    {
        if (mConnection.State == ConnectionState.Open)
        {
            mConnection.Close();
        }
    }

    internal int ExecuteSQL(string sqlStatement)
    {
        MySqlCommand cmd = new MySqlCommand(sqlStatement, mConnection);
        cmd.Transaction = mTransaction;
        return cmd.ExecuteNonQuery();
    }

    internal MySqlDataReader ExecuteQuery(string query)
    {
        MySqlCommand cmd = new MySqlCommand(query, mConnection);
        cmd.Transaction = mTransaction;
        return cmd.ExecuteReader();
    }

    internal object ExecuteScalar(string sqlQuery)
    {
        MySqlCommand cmd = new MySqlCommand(sqlQuery, mConnection);
        cmd.Transaction = mTransaction;
        return cmd.ExecuteScalar();
    }

    internal void BeginTransaction()
    {
        mTransaction = mConnection.BeginTransaction(IsolationLevel.ReadCommitted);
    }

    internal void CommitTransaction()
    {
        mTransaction.Commit();
        Console.WriteLine("Both records are written to database.");
    }

    internal void RollbackTransaction()
    {
        mTransaction.Rollback();
    }

    internal string toSQL(string stringValue)
    {
        return "'" + stringValue.Replace("'", "''") + "'";
    }

    internal string toSQL(float floatValue)
    {
        return floatValue.ToString();
    }

    internal string toSQL(int intValue)
    {
        return intValue.ToString();
    }

    internal string toSQL(bool boolValue)
    {
        return boolValue.ToString();
    }

    internal string toSQL(DateTime dateTimeValue)
    {
        return "'" + dateTimeValue.ToString("yyyy-MM-dd") + "'";
    }
}