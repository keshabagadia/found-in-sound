using UnityEngine;
using System.Collections; // Required for coroutines
using System.Collections.Generic;
using TMPro;

public class PhonemeFinder : MonoBehaviour
{
    public TMP_Text inputField;
    public TMP_Text resultText;
    public PhonemeDictionary phonemeDictionary; // Reference to the PhonemeDictionary script
    public PhonemeKeyManager phonemeKeyManager; // Reference to the PhonemeKeyManager script
    public ChangeKeys changeKeys; // Reference to the ChangeKeys script
    private HashSet<string> foundPhonemes;
    public AudioSource plusPointSFX;

    private void Start()
    {
        foundPhonemes = new HashSet<string>();
        phonemeKeyManager.SetPhonemeText(phonemeDictionary.allPhonemes);
    }

    private void TrackFoundPhonemes(string phonemes)
    {
        int uniquePhonemeCount = 0;
        string[] phonemeArray = phonemes.Split();
        foreach (var phoneme in phonemeArray)
        {
            if(phoneme.Length > 2)
            {
                string phonemeWithoutNumber = phoneme.Substring(0, phoneme.Length - 1);
                uniquePhonemeCount=AddFoundePhoneme(phonemeWithoutNumber, uniquePhonemeCount);
            }
            else
            {
                uniquePhonemeCount=AddFoundePhoneme(phoneme, uniquePhonemeCount);
            }
        }
        if(uniquePhonemeCount>0)
        {
            GameManager.Instance.currentScore += uniquePhonemeCount;
            if(plusPointSFX!=null)
            {
                plusPointSFX.Play();
            }
        }
    }

    private int AddFoundePhoneme(string phonemeToCheck, int phonemeCount)
    {
        if (!foundPhonemes.Contains(phonemeToCheck))
        {
            foundPhonemes.Add(phonemeToCheck);
            phonemeCount++;
        }
        return phonemeCount;
    }

    public void OnFindPhonemesButtonClicked()
    {
        Debug.Log("button clicked");
        string word = inputField.text.Trim().ToLower();
        string phonemes = phonemeDictionary.GetPhonemes(word);
        if (phonemes != null)
        {
            Debug.Log($"Phonemes found for the word '{word}': {phonemes}");
            TrackFoundPhonemes(phonemes);
            foreach (string phoneme in foundPhonemes)
            {
                Debug.Log("Checking phoneme:" + phoneme + " for word: " + word + ".");
                phonemeKeyManager.CheckPhonemeText(phoneme);
            }
            changeKeys.UpdateAlphabetKeys();
            inputField.text="";
        }
        else
        {

            Debug.Log($"Phonemes not found for the word '{word}'.");
            TriggerErrorSignal();
        }
    }
    IEnumerator SignalError()
    {
        Color originalColor = inputField.color; // Store the original color
        //Vector3 originalPosition = inputField.transform.position; // Store the original position
        inputField.color = Color.red; // Change color to red
        float elapsedTime = 0f;
        float duration = 0.5f; // Duration of the shake effect in seconds
        while (elapsedTime < duration)
        {
            // float x = originalPosition.x + Random.Range(-1f, 1f) * 0.1f; // Shake range for x
            // float y = originalPosition.y + Random.Range(-1f, 1f) * 0.1f; // Shake range for y
            // inputField.transform.position = new Vector3(x, y, originalPosition.z); // Apply new position

            elapsedTime += Time.deltaTime;
            yield return null; // Wait until the next frame
        }

        // inputField.transform.position = originalPosition; // Revert to the original position
        inputField.color = originalColor; // Revert to the original color
    }

    // Method to start the coroutine from somewhere in your code
    public void TriggerErrorSignal()
    {
        StartCoroutine(SignalError());
    }

}
