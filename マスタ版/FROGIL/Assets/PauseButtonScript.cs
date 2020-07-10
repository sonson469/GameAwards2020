using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButtonScript : MonoBehaviour
{

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    private Button tudukeru;
    private Button yarinaosu;
    private Button akirameru;

    // Start is called before the first frame update
    void Start()
    {
        tudukeru = Button1.GetComponent<Button>();
        yarinaosu = Button2.GetComponent<Button>();
        akirameru = Button3.GetComponent<Button>();

        //最初に選択されてるやつ
        tudukeru.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
