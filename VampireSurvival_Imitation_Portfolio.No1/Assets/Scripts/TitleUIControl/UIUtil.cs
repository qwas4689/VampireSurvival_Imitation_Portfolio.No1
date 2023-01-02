using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUtil : MonoBehaviour
{
    private bool isTimeOn = false;
    private float flickerTime;

    public void Flicker(Image img)
    {
        flickerTime += Time.deltaTime;

        img.color = isTimeOn == false ? Color.yellow : Color.white;

        if (flickerTime > 0.4f)
        {
            isTimeOn = !isTimeOn;
            flickerTime -= flickerTime;
        }
    }
}
