using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite; 
using System.Data; 
using System;

public class db : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("DB script starts");
		// string conn = "URI=file:" + Application.dataPath + "Plugins/Users.db"; //Path to database.
		string conn = "URI=file:Users.db"; 
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open(); //Open connection to the database.
		IDbCommand dbcmd = dbconn.CreateCommand();
		string sqlQuery = "SELECT Id,Username,Score FROM UserInfo";
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader();
		while (reader.Read())
		{
			int Id = reader.GetInt32(0);
			string Username = reader.GetString(1);
			int Score = reader.GetInt32(2);

			Debug.Log( "Id= "+Id+"  name ="+Username+" Score= "+Score);
		}
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
		dbconn = null;
	}

			
	}
	