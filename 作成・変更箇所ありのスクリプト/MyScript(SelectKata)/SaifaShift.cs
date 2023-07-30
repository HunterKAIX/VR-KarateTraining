using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaifaShift : MonoBehaviour
{
    [SerializeField] Toggle Switch;

    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad3) || Input.GetKey(KeyCode.Alpha3))
        {
            OnClickSaifaShiftButton();
        }
    }

    public void OnClickSaifaShiftButton()
    {
        if (Switch.isOn)
        {
            SceneManager.LoadScene("Saifa mirror");
        }
        else
        {
            SceneManager.LoadScene("Saifa");
        }
    }
}