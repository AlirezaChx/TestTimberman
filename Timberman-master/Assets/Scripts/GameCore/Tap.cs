using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    [SerializeField] GameController _GameController;
    [SerializeField] private string direction;
    private void OnMouseDown()
    {
        _GameController.OnTap(direction);
        //Debug.Log("Tap" + direction);
    }
}
