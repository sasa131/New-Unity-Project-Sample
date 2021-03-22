using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AgainButton : MonoBehaviour
{
    // 「AgainButton」が押されたら、ゲームシーンに画面遷移（後日、画面遷移する場所変更予定）
    public void OnClickAgainButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
