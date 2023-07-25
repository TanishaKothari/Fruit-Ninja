using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeSelectionManager : MonoBehaviour
{
    public enum GameMode{Classic,Zen,Arcade};
    public Image dialogueBox;
    public Text modeDesc;

    private void Awake(){
        dialogueBox.enabled = false;
    }
    public void OnHover(int modeAsInt)
    {
        dialogueBox.enabled = true;

        if (modeAsInt == 0){
            modeDesc.text = "Slice any Fruit that appears on the screen, while avoiding the Bombs. You have three lives.";
        }
        if (modeAsInt == 1){
            modeDesc.text = "Slice as many fruits as you can in 90 seconds. There are no bombs.";
        }
        if(modeAsInt == 2){
            modeDesc.text = "Slice as many fruits as you can in 1 minute while avoiding the bombs.";
        }
    }

    public void OnHoverExit()
    {
        dialogueBox.enabled = false;
    }
    public void LoadClassicMode()
    {
        SceneManager.LoadScene("ClassicMode");
    }

    public void LoadZenMode()
    {
        SceneManager.LoadScene("ZenMode");
    }

    public void LoadArcadeMode()
    {
        SceneManager.LoadScene("ArcadeMode");
    }
}