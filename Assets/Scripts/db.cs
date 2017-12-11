﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite; 
using System.Data; 
using System;

public class db : MonoBehaviour {
	private string conn;
	private List<HighScore> = new List<HighScore>;

	// Use this for initialization
	void Start () {
		Debug.Log ("DB script starts");
		// string conn = "URI=file:" + Application.dataPath + "Plugins/Users.db"; //Path to database.
		string conn = "URI=file:Users.db"; 
		GetScores ();
	}

	void Update (){ private void InsertScore (string name, int NewScore) {
			string conn = "URI=file:Users.db"; 
			IDbConnection dbconn;
			dbconn = (IDbConnection) new SqliteConnection(conn);
			dbconn.Open(); 

			//Open connection to the database.

			IDbCommand dbcmd = dbconn.CreateCommand();
			string sqlQuery = String.Format (
				"INSERT INTO UserInfo (Id,Username,Score) VALUES (\"{1}\",\"{2}\")",name,NewScore); 
			dbcmd.CommandText = sqlQuery;
			dbcmd.ExecuteScalar ();
			dbconn.Close ();

			//shows data on console

		}


	}
		
			public void GetScores () 
	{
		HighScore.Clear (); 
	string conn = "URI=file:Users.db"; 
	IDbConnection dbconn;
	dbconn = (IDbConnection) new SqliteConnection(conn);
	dbconn.Open(); //Open connection to the database.
	IDbCommand dbcmd = dbconn.CreateCommand();
	string sqlQuery = "SELECT *FROM UserInfo";
	//Id,Username,Score 
	dbcmd.CommandText = sqlQuery;

	IDataReader reader = dbcmd.ExecuteReader(); 

	//executes commands to reader

	while (reader.Read())
	{
		int Id = reader.GetInt32(0);
		string Username = reader.GetString(1);
		int Score = reader.GetInt32(2);

			HighScore.Add (
				new HighScore (reader.GetInt32 (0),
				reader.GetString (1)
				reader.GetInt32 (2)));
				

		Debug.Log( "Id= "+Id+"  name ="+Username+" Score= "+Score);
	}

	//shows data on console
	reader.Close();
	reader = null;
	dbcmd.Dispose();
	dbcmd = null;
	dbconn.Close();
	dbconn = null;

	//closing the reader



	private void DeleteScore ( int Id) {
		string conn = "URI=file:Users.db"; 
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open(); 

		//Open connection to the database.

		IDbCommand dbcmd = dbconn.CreateCommand();
		string sqlQuery = String.Format 
			("DELETE FROM UserInfo WHERE Id = \"{0}\"", Id); 
		dbcmd.CommandText = sqlQuery;
		dbcmd.ExecuteScalar ();
		dbconn.Close ();

		//deletes ID 

			
	}
}
}
	