using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelectionManager : MonoBehaviour
{
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