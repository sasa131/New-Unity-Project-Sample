using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public GameObject countDownText;
    public GameObject timerText;
    // float型の変数名を「countDown」に設定
    public float countDown;
    // float型の変数名を「startCount」に設定
    public float startCount;
    // カウントダウン後の「Start!」を消すかどうかのフラグ制御
    public bool isPlay;
    // float型の変数名を「elapsedTime」に設定
    public float elapsedTime;
    
    void Start()
    {
        // 変数に４.0秒の値を代入
        countDown = 4.0f;
        // 変数に1.0秒の値を代入
        startCount = 1.0f;
        // フラグ制御の最初の値を「false」に設定
        isPlay = false;
        // 変数に0.0秒の値を代入
        elapsedTime = 0.0f;
        // テキスト探す処理をするメソッドを呼び出す
        Text();
    }

    /// <summary>
    /// ゲーム開始のカウントダウンと、経過時間のテキストを探す　メソッド
    /// </summary>
    public void Text()
    {
        this.countDownText = GameObject.Find("CountDown");
        this.timerText = GameObject.Find("Timer");
    }
    
    void Update()
    {
        // Firstメソッドで、isPlayがtrueに変更されたら、この処理を開始
        if(isPlay == true)
        {
            // 「Start!」の文字を、見えなくする処理を呼び出す
            StartRes();
        }
        // 「countDown」の値が4.0の為、最初はこっちから処理を開始
        else if (countDown > 0)
        {
            // ゲーム開始のカウントダウンを、処理するメソッドを呼び出す
            First();
        }
    }

    /// <summary>
    /// ゲーム開始のカウントダウン　メソッド
    /// </summary>
    public void First()
    {
        // 「countDown」の値が「1」以下なら、処理を開始
        if (countDown < 1)
        {
            countDown = 0;
            isPlay = true;
            this.countDownText.GetComponent<Text>().text =
                "Start!";
        }
        // 「countDown」の値が4.0の為、最初はこっちから処理を開始
        else
        {
            // 「countDown」の値を減らしていく
            this.countDown -= Time.deltaTime;
            // 整数でカウントダウンしたい為、(int)を使用
            var count = (int)countDown;
            // Unityの「ゲームビュー」にカウントダウンを表示
            this.countDownText.GetComponent<Text>().text =
                count.ToString();
        }
    }

    /// <summary>
    /// 「Start!」の文字を1秒後に消す　メソッド
    /// </summary>
    public void StartRes()
    {
        // 「startCount」の値が「0」以下なら、処理を開始
        if (startCount <= 0)
        {
            // 「Start!」の表示を空欄に変える
            this.countDownText.GetComponent<Text>().text = "";

            // 経過時間の処理を行うメソッドを呼び出す
            ElapsedTime();
        }
        // 最初にこの処理から開始
        else
        {
            //　「startCount」の値を減らしていく
            this.startCount -= Time.deltaTime;
        }
    }

    /// <summary>
    /// 経過時間を測定する　メソッド
    /// </summary>
    public void ElapsedTime()
    {
        // 「elapsedTime」の値を増やしていく
        this.elapsedTime += Time.deltaTime;
        // Unityの「ゲームビュー」に「Time:」と、経過時間を表示
        this.timerText.GetComponent<Text>().text =
            ("Time:") + this.elapsedTime.ToString("F2");
    }

    /// <summary>
    /// 障害物に触れたら「GameOver」と表示するメソッド
    /// </summary>
    public void Out()
    {
        isPlay = false;

        // 「isPlay」が、「false」になった際、処理を開始
        if(isPlay == false)
        {
            // 「countDownText」の文字を、「GameOver」に変え表示
            this.countDownText.GetComponent<Text>().text = "GameOver";
            // 「timerText」の文字を、空欄にして表示
            this.timerText.GetComponent<Text>().text = "";
        }
    }

    /// <summary>
    /// ゴールラインに触れたら「GameClear」と表示するメソッド
    /// </summary>
    public void Goal()
    {
        isPlay = false;

        if(isPlay == false)
        {
            // Outメソッドと処理は同じ
            this.countDownText.GetComponent<Text>().text = "GameClear";
            this.timerText.GetComponent<Text>().text = "";
        }
    }
}
