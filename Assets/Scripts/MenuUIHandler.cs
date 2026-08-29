using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
  [SerializeField] private TMP_InputField nameField;
  [SerializeField] private TextMeshProUGUI highScoreText;

  private Color defaultColor;

  void Start()
  {
    DataManager.Instance.LoadScore();
    highScoreText.text = $"High Score: {DataManager.HighscorePlayerScore} by {DataManager.HighscorePlayerName}";
    defaultColor = nameField.image.color;
    nameField.onValueChanged.AddListener(_ => nameField.image.color = defaultColor);
  }

  public void StartNew()
  {
    string playerName = nameField.text.Trim();

    if (!string.IsNullOrEmpty(playerName))
    {
      DataManager.CurrentPlayerName = playerName;
      SceneManager.LoadScene(1);
    }
    else
    {
      nameField.image.color = Color.red;
      nameField.Select();
      nameField.ActivateInputField();
    }
  }

  public void ExitGame()
  {
#if UNITY_EDITOR
    //Don't forget since this use editor code, need to add "using UnityEditor" at the top and wrap it between #if
    EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
  }

}
