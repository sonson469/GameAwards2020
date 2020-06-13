using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class GrassClear : MonoBehaviour
{
    public string tagname;

    public bool ClearFlag;

    public GameObject ClearUI;
    public GameObject ClearBuck;

    public GameObject Fade;

    public int num;

    

    // Start is called before the first frame update
    void Start()
    {
        
        ClearFlag = false;
        ClearUI.SetActive(false);
        ClearBuck.SetActive(false);
        Fade.SetActive(false);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagname)
        {
            ClearFlag = true;
        }
    }

    // Update is called once per frame
    public void Update()
    {

        if (ClearFlag)
        {
            Time.timeScale = 0f;
            ClearUI.SetActive(true);
            ClearBuck.SetActive(true);
        }
        
        

    }

    public void OnClick()
    {
       
        Fade.SetActive(true);

        Invoker.InvokeDelayed(OnClick_NextStage, 1);


    }

    public void OnClick_StageSelect()
    {
        Fade.SetActive(true);
        Invoker.InvokeDelayed(StageSelect, 1);

    }

    public void OnClick_StageTitle()
    {
        Fade.SetActive(true);
        Invoker.InvokeDelayed(StageTitle, 1);

    }

    public void OnClick_NextStage()
    {

        if (num == 1)
        {

            SceneManager.LoadScene("Stage1");
        }
        if (num == 2)
        {
            SceneManager.LoadScene("Stage2");
        }
        if (num == 3)
        {
            SceneManager.LoadScene("Stage3");
        }
        if (num == 4)
        {
            SceneManager.LoadScene("Stage4");
        }
        if (num == 5)
        {
            SceneManager.LoadScene("Stage5");
        }
        if (num == 6)
        {
            SceneManager.LoadScene("Stage6");
        }
        if (num == 7)
        {
            SceneManager.LoadScene("Stage7");
        }
        if (num == 8)
        {
            SceneManager.LoadScene("Stage8");
        }
        if (num == 9)
        {
            SceneManager.LoadScene("Stage9");
        }
        if (num == 10)
        {
            SceneManager.LoadScene("Stage10");
        }

    }

    public void StageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }
    public void StageTitle()
    {
        SceneManager.LoadScene("Title");
    }


    //
    //Time.timeScale = 0だとInvokeが使えないから
    //
    public delegate void Invokable();

    /// <summary>
    /// Enables invokation of functions without regard to timeScale
    /// To use this class, Call Invoker.InvokeDelayed(MyFunc, 5);
    /// 
    /// Written by Jade Skaggs - Funonium.com
    /// </summary>
    public class Invoker : MonoBehaviour
    {
        private struct InvokableItem
        {
            public Invokable func;
            public float executeAtTime;
            public static Invoker _instance = null;

            public InvokableItem(Invokable func, float delaySeconds)
            {
                this.func = func;

               
                if (Time.time == 0)
                    this.executeAtTime = delaySeconds;
                else
                    this.executeAtTime = Time.realtimeSinceStartup + delaySeconds;

            }
        }

        private static Invoker _instance = null;
        public static Invoker Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.AddComponent<Invoker>();
                    go.name = "_FunoniumInvoker";
                    _instance = go.GetComponent<Invoker>();
                }
                return _instance;
            }
        }

        float fRealTimeLastFrame = 0;
        float fRealDeltaTime = 0;

        List<InvokableItem> invokeList = new List<InvokableItem>();
        List<InvokableItem> invokeListPendingAddition = new List<InvokableItem>();
        List<InvokableItem> invokeListExecuted = new List<InvokableItem>();

        public float RealDeltaTime()
        {
            return fRealDeltaTime;
        }
        /// <summary>
        /// Invokes the function with a time delay.  This is NOT 
        /// affected by timeScale like the Invoke function in Unity.
        /// </summary>
        /// <param name='func'>
        /// Function to invoke
        /// </param>
        /// <param name='delaySeconds'>
        /// Delay in seconds.
        /// </param>
        public static void InvokeDelayed(Invokable func, float delaySeconds)
        {
            Instance.invokeListPendingAddition.Add(new InvokableItem(func, delaySeconds));
        }

        // must be maanually called from a game controller or something similar every frame
        public void Update()
        {
            fRealDeltaTime = Time.realtimeSinceStartup - fRealTimeLastFrame;
            fRealTimeLastFrame = Time.realtimeSinceStartup;

           
            foreach (InvokableItem item in invokeListPendingAddition)
            {
                invokeList.Add(item);
            }
            invokeListPendingAddition.Clear();


            // Invoke all items whose time is up
            foreach (InvokableItem item in invokeList)
            {
                if (item.executeAtTime <= Time.realtimeSinceStartup)
                {
                    if (item.func != null)
                        item.func();

                    invokeListExecuted.Add(item);
                }
            }

            // Remove invoked items from the list.
            foreach (InvokableItem item in invokeListExecuted)
            {
                invokeList.Remove(item);
            }
            invokeListExecuted.Clear();
        }
    }
}
