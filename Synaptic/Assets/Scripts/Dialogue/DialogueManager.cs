using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializedField] private TextMeshProGUI dialogueText;

    private Story currentStory;

    prviate bool dialogueIsPlaying;

    private void Awake
    {
        if(instance != null)
        {
            Debug.Log Warning "Found more than one Dialogue Manager in the scene");

        }
        
        instance = this;
    }

    // Update is called once per frame
    private static DialogueManager GetInstance()
    {
        return instance;
    }

private void Start()
{
    dialogueIsPlaying = false;
    dialoguePanel.SetActive(false);
}
}
