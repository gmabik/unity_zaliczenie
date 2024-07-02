using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveItem : MonoBehaviour
{
    public string savePath;
    public PlayerData playerData;
    public TMP_Text clickAmount;
    public CurrentSaveSO currentSave;

    private bool loaded;

    private void Start()
    {
        playerData = new PlayerData(0);
        if (File.Exists(savePath) && !loaded)
        {
            using StreamReader sr = new StreamReader(savePath);
            string loadPlayerData = sr.ReadToEnd();

            playerData = JsonUtility.FromJson<PlayerData>(loadPlayerData);
            Debug.Log(playerData);
            clickAmount.text = playerData.clicks.ToString();
            loaded = true;
        }
    }

    public void OnClick()
    {
        currentSave.savePath = savePath;
        SceneManager.LoadScene("Game");
    }
}
