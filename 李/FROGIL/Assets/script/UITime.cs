using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITime : MonoBehaviour
{

    [SerializeField]
    public float seconds;
    //　前のUpdateの時の秒数
    private float oldSeconds;
    //コンポーネント用
    private Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        seconds = 0.0f;
        oldSeconds = 0.0f;
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;

        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text =((int)seconds).ToString("000");
        }
        oldSeconds = seconds;
    }
}
