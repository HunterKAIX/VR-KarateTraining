using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRoidScaleChanger : MonoBehaviour
{

    //手本とプレイヤーのVRoid両方に適用させる。

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //右矢印キーを押すと、VRoid全体の横幅を0.1m増やす
            gameObject.transform.localScale = new Vector3(
            gameObject.transform.localScale.x + 0.1f,
            gameObject.transform.localScale.y,
            gameObject.transform.localScale.z
            );
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //左矢印キーを押すと、VRoid全体の横幅を0.1m減らす
            gameObject.transform.localScale = new Vector3(
            gameObject.transform.localScale.x - 0.1f,
            gameObject.transform.localScale.y,
            gameObject.transform.localScale.z
            );
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //上矢印キーを押すと、VRoid全体の縦幅を0.1m増やす
            gameObject.transform.localScale = new Vector3(
            gameObject.transform.localScale.x,
            gameObject.transform.localScale.y + 0.1f,
            gameObject.transform.localScale.z
            );
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //下矢印キーを押すと、VRoid全体の縦幅を0.1m減らす
            gameObject.transform.localScale = new Vector3(
            gameObject.transform.localScale.x,
            gameObject.transform.localScale.y - 0.1f,
            gameObject.transform.localScale.z
            );
        }

    }
}
