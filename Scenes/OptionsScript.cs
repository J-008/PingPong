using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    Dropdown m_Dropdown;
    int m_DropdownValue;
    int scoreLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
   public void SetScoreLimit()
    {
        m_DropdownValue = this.GetComponent<Dropdown>().value;// m_Dropdown.value;//GameObject.Find("Options").GetComponent<Dropdown>().value;
        Debug.Log("value=" + m_DropdownValue);
        scoreLimit = Convert.ToInt32(m_Dropdown.options[m_DropdownValue].text);
        Debug.Log("sciorelimit=" + scoreLimit);
}
   public int GetScoreLimit()
    {
        return scoreLimit;

    }
    public void OpenNewScene(string name)
    {
       Application.LoadLevel(name);
    }
    public void SetSpeed()
    {

    }
}
