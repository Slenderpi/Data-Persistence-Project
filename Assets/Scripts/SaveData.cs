using UnityEngine;

[System.Serializable]
public class SaveData {

	public static readonly string SAVE_FILE_PATH = Application.persistentDataPath + "/highest_score.json";

	public string name = "";
	public int score = 0;

	public SaveData(string n, int s) {
		name = n;
		score = s;
	}

}
