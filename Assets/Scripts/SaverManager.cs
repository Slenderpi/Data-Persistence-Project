using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaverManager : MonoBehaviour {

	public static SaverManager instance;

	public string bestScoreTextValue;

	public TMP_InputField nameInput;
	public string nameEntered = "";

	SaveData currentHighestScore;

	void Awake() {
		if (instance)
			Destroy(gameObject);
		else {
			instance = this;
			DontDestroyOnLoad(gameObject);

			currentHighestScore = File.Exists(SaveData.SAVE_FILE_PATH) ? JsonUtility.FromJson<SaveData>(File.ReadAllText(SaveData.SAVE_FILE_PATH)) : new SaveData("", 0);
		}
	}

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public void SetNameEntered(string name) {
		nameEntered = name;
	}

	public void OnGameOver(int scoreAchieved) {
		if (currentHighestScore != null && currentHighestScore.score >= scoreAchieved)
			return;

		currentHighestScore.name = nameEntered;
		currentHighestScore.score = scoreAchieved;
		File.WriteAllText(SaveData.SAVE_FILE_PATH, JsonUtility.ToJson(currentHighestScore));
	}

	public void ReloadTexts(Text bestScoreText) {
		bestScoreText.text = $"HIGHEST SCORE : {currentHighestScore.name} : {currentHighestScore.score}";
	}

}
