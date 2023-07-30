using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorToggle : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (GetComponent<Toggle>().isOn)
            {
                GetComponent<Toggle>().isOn = false;
            }
            else
            {
                GetComponent<Toggle>().isOn = true;
            }
        }
    }
}
