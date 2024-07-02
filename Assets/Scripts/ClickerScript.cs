using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ClickerScript : MonoBehaviour
{
    public CurrentSaveSO currentSave;
    public PlayerData playerData;
    public TMP_Text clickText;
    void Start()
    {
        if (File.Exists(currentSave.savePath))
        {
            string loadPlayerData = File.ReadAllText(currentSave.savePath);
            playerData = JsonUtility.FromJson<PlayerData>(loadPlayerData);
        }
        else
        {
            playerData = new PlayerData(0);
            string savePlayerData = JsonUtility.ToJson(playerData);
            File.WriteAllText(currentSave.savePath, savePlayerData);
        }
        clickText.text = playerData.clicks.ToString();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnClick()
    {
        playerData.clicks++;
        clickText.text = playerData.clicks.ToString();
        string savePlayerData = JsonUtility.ToJson(playerData);
        Debug.Log(savePlayerData);
        File.WriteAllText(currentSave.savePath, savePlayerData);
    }
}
