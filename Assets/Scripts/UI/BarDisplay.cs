using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarDisplay : MonoBehaviour
{

    [SerializeField]
    private GameObject bar;

    [SerializeField]
    private TextMeshProUGUI label;

    [SerializeField]
    private string title;

    internal void Set(float currentVal, float maxVal)
    {
        Vector3 newScale = this.bar.transform.localScale;
        newScale.x = currentVal / maxVal;
        this.bar.transform.localScale = newScale;
        this.label.text = String.Format("{0} : {1}",this.title, (int) currentVal);
    }
}
