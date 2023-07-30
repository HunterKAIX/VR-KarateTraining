using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gekisai1Shift : MonoBehaviour
{
    [SerializeField] Toggle Switch;

    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1) || Input.GetKey(KeyCode.Alpha1))
        {
            OnClickGekisai1ShiftButton();
        }
    }
    public void OnClickGekisai1ShiftButton()
    {
        if (Switch.isOn)
        {
            SceneManager.LoadScene("Gekisai1 mirror");
        }
        else
        {
            SceneManager.LoadScene("Gekisai1");
        }
    }

}
