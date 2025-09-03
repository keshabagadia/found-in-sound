using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputKeyVisualUpdate : MonoBehaviour
{
    public TMP_Text inputText;
    private string alphabetKey;

    // Start is called before the first frame update
    public void OnAlphabetButtonClicked()
    {
        alphabetKey = GetComponentInChildren<TMP_Text>().text;
        inputText.text +=  alphabetKey;
    }

    public void OnBackspaceButtonClicked()
    {
        if(inputText.text.Length > 0)
        {
            inputText.text = inputText.text.Substring(0, inputText.text.Length - 1);
        }
    }

    public void SetText(string text)
    {
        GetComponentInChildren<TMP_Text>().text = text;
    }
}
