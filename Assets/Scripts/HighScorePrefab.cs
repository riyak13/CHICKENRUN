using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePrefab : MonoBehaviour {

	public GameObject name;
	public GameObject score;
	public GameObject rank;

	public void SetScore (string name, string score, string rank) {

		this.rank.GetComponent<Text> ().text = rank;
		this.rank.GetComponent<Text> ().text = name;
		this.rank.GetComponent<Text> ().text = score;
		
	}
}
