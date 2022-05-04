using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;


    private TextMeshProUGUI[] choicesText;

Image[] diagImages;
    TMP_Text[] diagText;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

    }

    // Update is called once per frame
    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;

        diagImages = GameObject.Find("DialogueBox").GetComponentsInChildren<Image>();
        diagText = GameObject.Find("DialogueBox").GetComponentsInChildren<TMP_Text>();

        TurnOffDiag();
        //dialoguePanel.SetActive(false);
    }

    public void Update()
    {
        //return right away if dialogue isnt playing
        if (!dialogueIsPlaying)
        {
            return;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        if (!dialogueIsPlaying)
        {
            TurnOnDiag();
            currentStory = new Story(inkJSON.text);
            dialogueIsPlaying = true;
        }

        ContinueStory();
    }


    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialogueText.text = "";
        TurnOffDiag();


    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            Debug.Log(dialogueText);
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    void TurnOffDiag()
    {
        foreach (TMP_Text text in diagText)
        {
            text.enabled = false;
        }

        foreach (Image image in diagImages)
        {
            image.enabled = false;
        }
    }

    void TurnOnDiag()
    {
        foreach (TMP_Text text in diagText)
        {
            text.enabled = true;
        }

        foreach (Image image in diagImages)
        {
            image.enabled = true;
        }
    }
}
