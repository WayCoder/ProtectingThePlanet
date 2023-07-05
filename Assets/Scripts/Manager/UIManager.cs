using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);

            return;
        }

        instance = this;
    }


    public void SetDarkPanel(bool value)
    {

    }


}
