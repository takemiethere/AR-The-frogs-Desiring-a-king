using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FindObj : MonoBehaviour
{
    public GameObject _aGameObject;
    // Start is called before the first frame update
    
    void Update()
    {
        _aGameObject = GameObject.FindWithTag("Page");
    }
    
    public void OnGameObj()
    {
        _aGameObject.SetActive(true);
    }

    // Update is called once per frame
    public void OffGameObj()
    {
        _aGameObject.SetActive(false);
    }
}
