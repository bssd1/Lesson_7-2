using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
  public static DataManager Instance { get; private set; }
  public static string CurrentPlayerName;
  public static int CurrentPlayerScore;
  public static string HighscorePlayerName;
  public static int HighscorePlayerScore;

  private void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
      return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
  }

  public void SaveScore()
  {
    SaveData data = new SaveData();
    data.Name = HighscorePlayerName;
    data.Score = HighscorePlayerScore;

    string json = JsonUtility.ToJson(data);

    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
  }

  public void LoadScore()
  {
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
      string json = File.ReadAllText(path);
      SaveData data = JsonUtility.FromJson<SaveData>(json);

      HighscorePlayerName = data.Name;
      HighscorePlayerScore = data.Score;
    }
  }
}

[System.Serializable]
public class SaveData
{
  public string Name;
  public int Score;
}
