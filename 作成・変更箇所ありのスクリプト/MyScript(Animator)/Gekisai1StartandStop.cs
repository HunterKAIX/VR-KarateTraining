using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gekisai1StartandStop : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Animator anim = GetComponent<Animator>();

        //シーン名が"Gekisai1"(鏡なしでの練習)なら"MirrorSwitch"トリガーをTrueにする。
        //※"MirrorSwitch"がTrueの時は、手本であるTeacherVRoidのモーションが左右反転する。
        //※"MirrorSwitch"は、鏡の有無ではなく、AnimatorのStateにある"Mirror"の項目のこと。
        if (SceneManager.GetActiveScene().name == "Gekisai1")
        {
            anim.SetBool("MirrorSwitch", true);
        }
        else
        {
            anim.SetBool("MirrorSwitch", false);
        }

        //キーボードのSキーを押すと、"Gekisai1Shift"トリガーをTrueにし、型の手本モーションをスタートする。
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Gekisai1Shift", true);
        }

        //Animatorの現在のステート情報を"State1"に入れる。
        AnimatorStateInfo state1 = anim.GetCurrentAnimatorStateInfo(0);

        //"State1"が"Wait"ステート以外の時は、"Gekisai1Shift"トリガーをFalseのままにする。
        if (!state1.IsName("Wait"))
        {
            anim.SetBool("Gekisai1Shift", false);
        }

        //キーボードのTキーを押すと、"Interrupt"トリガーをTureにし、モーションを中断する。
        if (Input.GetKey(KeyCode.T))
        {
            anim.SetBool("Interrupt", true);
            //"SelectKata"シーン(型の選択画面)に移行する。
            SceneManager.LoadScene("SelectKata");
        }

        //Animatorの現在のステート情報を"State2"に入れる。
        AnimatorStateInfo state2 = anim.GetCurrentAnimatorStateInfo(0);

        //"State2"が"Wait"ステート以外の時は、"Interrupt"トリガーをFalseのままにする。
        if (state2.IsName("Wait"))
        {
            anim.SetBool("Interrupt", false);
        }

    }
}
