using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject content;

    public void Display()
    {
        this.content.SetActive(true);
    }
}
