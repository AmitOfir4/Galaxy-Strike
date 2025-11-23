using TMPro;
using UnityEngine;

public class DialogLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines;
    [SerializeField] TMP_Text dialogText;
    int currentLine = 0;

    public void NextDialogLines()
    {
        currentLine++;
        dialogText.text = timelineTextLines[currentLine];
    }
}