using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button labButton, ecgButton, calciumButton, insulinButton;
    public Button hintButton, restartButton;
    public TextMeshProUGUI hintText, resultText;
    public GameObject treatmentPanel;

    private int stage = 0;

    void Start()
    {
        // Set initial UI state
        hintText.gameObject.SetActive(false);
        treatmentPanel.SetActive(false);
        resultText.text = "";

        // Assign button listeners
        labButton.onClick.AddListener(ShowLabResults);
        ecgButton.onClick.AddListener(ShowECGResults);
        calciumButton.onClick.AddListener(GiveCalcium);
        insulinButton.onClick.AddListener(GiveInsulin);
        hintButton.onClick.AddListener(ShowHint);
        restartButton.onClick.AddListener(RestartGame);
    }

    void ShowLabResults()
    {
        if (stage == 0)
        {
            resultText.text = "🧪 Lab Result:\nPotassium 7.2 mmol/L";
            stage = 1;
        }
    }

    void ShowECGResults()
    {
        if (stage == 1)
        {
            resultText.text = "📉 ECG Result:\nPeaked T-waves – Hyperkalemia!";
            treatmentPanel.SetActive(true);
            stage = 2;
        }
    }

    void GiveCalcium()
    {
        if (stage == 2)
        {
            resultText.text = "✅ Calcium given. Heart stabilized.";
            stage = 3;
        }
    }

    void GiveInsulin()
    {
        if (stage == 3)
        {
            resultText.text = "🎉 Insulin administered. Potassium normalized. Patient saved!";
            treatmentPanel.SetActive(false);
            stage = 4;
        }
    }

    void ShowHint()
    {
        if (stage == 0)
            hintText.text = "Hint: Start by checking the lab report.";
        else if (stage == 1)
            hintText.text = "Hint: Now look at the ECG.";
        else if (stage == 2)
            hintText.text = "Hint: Administer calcium first.";
        else if (stage == 3)
            hintText.text = "Hint: Now give insulin.";
        else
            hintText.text = "Well done! You completed the case.";

        hintText.gameObject.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
