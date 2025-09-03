using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeKeys : MonoBehaviour
{
    //public string[] inputConsonantAlphabets;
    public string[] inputVowelAlphabets;
    public TMP_Text[] inputConsonantTextfields;
    public TMP_Text[] inputVowelTextfields;
    // Start is called before the first frame update
    void Start()
    {
        UpdateAlphabetKeys();

        if(inputVowelTextfields.Length != inputVowelAlphabets.Length)
        {
            Debug.LogError("Vowel Alphabets and Textfields are not equal in length");
        } else
        {
            for(int i = 0; i < inputVowelAlphabets.Length; i++)
            {
                inputVowelTextfields[i].text = inputVowelAlphabets[i];
            }
        }   
    }

    public void UpdateAlphabetKeys()
    {
        string consonants = "bcdfghjklmnpqrstvwxyz";
        var rng = new System.Random();
        var randomAlphabets = new char[inputConsonantTextfields.Length];
        var consonantArray = consonants.ToCharArray();
    
        // Shuffle the consonant array
        for (int i = consonantArray.Length - 1; i > 0; i--)
        {
            int swapIndex = rng.Next(i + 1);
            // Swap elements
            char temp = consonantArray[i];
            consonantArray[i] = consonantArray[swapIndex];
            consonantArray[swapIndex] = temp;
        }
    
        // Select the first 3 unique consonants
        for (int i = 0; i < randomAlphabets.Length; i++)
        {
            randomAlphabets[i] = consonantArray[i];
        }
    
        // Update the text fields
        for (int i = 0; i < randomAlphabets.Length; i++)
        {
            inputConsonantTextfields[i].text = randomAlphabets[i].ToString();
        }
    }
}
