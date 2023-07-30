using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    AudioSource sound;
    public AudioClip clipSound;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSourceコンポーネントを取得して"sound"変数に格納。
        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //別スクリプトで指定してある条件を満たしたら、
    //設定してある音声を再生する。
    public void ComparisonSpeaker()
    {

        sound.PlayOneShot(clipSound);

    }
}
