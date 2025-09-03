using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhonemeKeyManager : MonoBehaviour
{
    GameObject[] PhonemeKeys;
    public int totalPhonemeKeys;
    // Start is called before the first frame update
    void Start()
    {
        totalPhonemeKeys = transform.childCount; // Get the number of children
        PhonemeKeys = new GameObject[totalPhonemeKeys]; // Initialize the array

        for (int i = 0; i < totalPhonemeKeys; i++)
        {
            PhonemeKeys[i] = transform.GetChild(i).gameObject; // Assign each child to the array
        }
    }

    public void SetPhonemeText(List<string> phonemes)
    {
        if(totalPhonemeKeys>=phonemes.Count)
        {
            for(int i = 0; i<phonemes.Count; i++)
            {
                PhonemeKeys[i].GetComponent<PhonemeKeyVisualUpdate>().SetPhonemeText(phonemes[i]);
            }

        } else
        {
            Debug.Log("Not enough phoneme keys to display all phonemes.");
        }
        
    }

    public void CheckPhonemeText(string phoneme)
    {
        Debug.Log("Checking phoneme:" + phoneme + " for word.");
        for (int i = 0; i < totalPhonemeKeys; i++)
        {
            PhonemeKeys[i].GetComponent<PhonemeKeyVisualUpdate>().CheckPhonemeText(phoneme);
        }
    }
}
