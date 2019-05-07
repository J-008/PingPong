﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
   public void OpenNewScene(string name)
    {
        Application.LoadLevel(name);
    }

    public void CloseScene()
    {
        Application.Quit();
    }

}

