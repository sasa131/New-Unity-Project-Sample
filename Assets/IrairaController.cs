using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrairaController : MonoBehaviour
{
    // Color型の変数名を「materialColr」に設定
    private Color materialColr;
    // FixedJoystick型の変数名を「joystick」に設定
    public FixedJoystick joystick;
    // privateメンバの変数をUnityのInspector内に表示させる
    [SerializeField]
    // イライラ棒に物理処理を設定
    private Rigidbody iraira;
    // イライラ棒の移動速度の変数名を「moveSpeed」に設定
    public float moveSpeed;
    // GameDirectorの各メソッドを使用する設定
    public GameDirector ui;
    // folat型の変数名を「cowntDown」に設定
    public float cowntDown;
    
    void Start()
    {
        // 変数に青色の情報を代入
        materialColr = Color.blue;
        // 変数に移動速度の数値を代入
        moveSpeed = 0.6f;
        // カウントダウン後に操作出来るようにする為、カウントダウンと同じ数値を代入
        cowntDown = 4.0f;
        // オブジェクトの色を変更するメソッドを呼び出す
        SetColor();
    }

    
    void Update()
    {
        // ジョイスティックの移動に関するメソッドを呼び出す
        MoveKey();
    }

    private void SetColor()
    {
        // オブジェクトの色を変更
        GetComponent<Renderer>().material.color = materialColr;
    }

    protected void MoveKey()
    {
        // ジョイスティックのX・Y・Z方向を設定(Z方向は使用しない為、0に設定)
        var direction = new Vector3(joystick.Horizontal, joystick.Vertical, 0);
        // X・Y方向の移動速度を設定
        var velocity = iraira.velocity;
        velocity.x = joystick.Horizontal * moveSpeed;
        velocity.y = joystick.Vertical * moveSpeed;
        // 「GameDirector」スクリプトの「isPlay」が「true」なら、処理を開始
        if(ui.isPlay == true)
        {
            iraira.velocity = velocity;
        }
    }

    /// <summary>
    /// 障害物に触れた際のメソッド
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision)
    {
        // 「GameDirector」スクリプトの「Out」メソッドを呼び出す
        ui.Out();
    }

    /// <summary>
    /// ゴールラインに触れた際のメソッド
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        // 「GameDirector」スクリプトの「Goal」メソッドを呼び出す
        ui.Goal();
    }

}
