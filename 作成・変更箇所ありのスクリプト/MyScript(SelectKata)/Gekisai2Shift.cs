using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gekisai2Shift : MonoBehaviour
{
    [SerializeField] Toggle Switch;

    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad2) || Input.GetKey(KeyCode.Alpha2))
        {
            OnClickGekisai2ShiftButton();
        }
    }

    public void OnClickGekisai2ShiftButton()
    {
        if (Switch.isOn)
        {
            SceneManager.LoadScene("Gekisai2 mirror");
        }
        else
        {
            SceneManager.LoadScene("Gekisai2");
        }
    }
}
