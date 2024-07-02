using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public List<SaveItem> saves = new List<SaveItem>();

    private void Awake()
    {
        int i = 1;
        foreach (var item in saves)
        {
            item.savePath = Application.persistentDataPath + "/PlayerData" + i + ".json";
            i++;
        }
    }
}
