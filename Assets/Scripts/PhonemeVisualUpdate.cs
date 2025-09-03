using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhonemeKeyVisualUpdate : MonoBehaviour
{
    void Start()
    {
        //ChangeColorToUnlocked();
    }
    // Start is called before the first frame update
    void ChangeColorToUnlocked()
    {
        GetComponent<Image>().color = Color.green;
    }

    public void CheckPhonemeText(string phoneme)
    {
        Debug.Log("Checking phoneme:" + phoneme + " for word.");
        string tmpText = GetComponentInChildren<TMP_Text>().text;
        if (tmpText == phoneme)
        {
            ChangeColorToUnlocked();
        }
    }

    public void SetPhonemeText(string phoneme)
    {
        GetComponentInChildren<TMP_Text>().text = phoneme;
    }
}
