using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour {

	public TextMeshProUGUI bestScoreText;
	public Button startButton;
	public Button exitButton;

	// Start is called before the first frame update
	void Start() {
		if (File.Exists(SaveData.SAVE_FILE_PATH)) {
			SaveData save = JsonUtility.FromJson<SaveData>(File.ReadAllText(SaveData.SAVE_FILE_PATH));
			bestScoreText.text = $"HIGHEST SCORE : {save.name} : {save.score}";
		}
	}

	// Update is called once per frame
	void Update() {

	}

	public void StartNew() {
		SaverManager.instance.bestScoreTextValue = bestScoreText.text;
		SceneManager.LoadScene(1);
	}

	public void ExitGame() {
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
		Application.Quit();
#endif
	}

}
