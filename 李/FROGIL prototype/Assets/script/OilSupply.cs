using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSupply : MonoBehaviour
{
    public string Tongue;
    private bool TongueFlag = false;
    public bool SupplyFlag = false;
    static public int SupplyNum;
    static public int SupplyNumScore;

    public OnKeyPress_MoveRotateGravity PlayerScript;

    // Start is called before the first frame update
    void Start()
    {
        SupplyNum = 0;
        SupplyNumScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (TongueFlag == true && SupplyFlag == false)
        {
            TongueFlag = false;
            this.gameObject.SetActive(false);
            SupplyFlag = true;
            SupplyNum++;
            PlayerScript.audioSource.PlayOneShot(PlayerScript.SupplySE1);
        }

        SupplyNumScore = (SupplyNum - 1) * 10;
        if (SupplyNumScore < 0)
        {
            SupplyNumScore *= 0;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == Tongue)
        {
            TongueFlag = true;

        }
    }

    public static int GetSupplyScore()
    {
        return SupplyNum;
    }
    public static int GetSupplyScore2()
    {
        return SupplyNumScore;
    }
}
