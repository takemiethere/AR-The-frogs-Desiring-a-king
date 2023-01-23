using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FindObj : MonoBehaviour
{
    public GameObject _aGameObject;
    public GameObject Ui_find;
    
    // Start is called before the first frame update
    
    void Update()
    {
        // _aGameObject = GameObject.FindWithTag("Page");
        // Ui_find = GameObject.Find("Ui-LookFor");
    }
    
    public void OnGameObj()
    {
        Ui_find.SetActive(false);
        _aGameObject.SetActive(true);
    }

    
    public void OffGameObj()
    {
        Ui_find.SetActive(true);
        _aGameObject.SetActive(false);
    }
}
