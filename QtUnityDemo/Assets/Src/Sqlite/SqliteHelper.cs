using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class SqliteHelper {
    private SqliteConnection sqliteConnection;
    private string dbPath;

    public void InitializeDBConnection() {
#if UNITY_IOS
        dbPath = "URI=file:" + Application.dataPath + "/Raw" + "/Metadata/DemoDB.db";
#elif UNITY_ANDROID
        //TODO(Huayu): load sql from jar on android
        dbPath = "jar:file://" + Application.dataPath + "!/assets/" + "/Metadata/DemoDB.db";
#else
        dbPath = "URI=file:" + Application.dataPath + "/StreamingAssets" + "/Metadata/DemoDB.db";
#endif
        Debug.Log("InitializeDBConnection: " + dbPath);
        sqliteConnection = new SqliteConnection(dbPath);
    }

    public SqliteCommand CreateSqlCommand(string query) {
        SqliteCommand cmd = sqliteConnection.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = query;
        return cmd;
    }

    public SqliteDataReader ExecuteSqlCommand(SqliteCommand cmd) {
        sqliteConnection.Open();
        SqliteDataReader reader = cmd.ExecuteReader();
        cmd.Dispose();
        return reader;
    }

    public void CloseResultReader(SqliteDataReader reader) {
        reader.Close();
        sqliteConnection.Close();
    }
}
