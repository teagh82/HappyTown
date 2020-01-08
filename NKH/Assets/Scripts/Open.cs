using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    private NumberSystem theNum;

    public GameObject go;

    private void Start()
    {
        theNum = FindObjectOfType<NumberSystem>();

        go.SetActive(true);
    }

}

