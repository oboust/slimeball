using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hungerbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider fillbar;
    public float hunger;
    player playerscript;
    public float hungervalue;
    float elapsed = 0f;
    public void losehunger(float value)
    {
        if (hunger <= 0)
        {
            return;
        }
        hunger -= value;
        fillbar.value = hunger / 100;
        if (hunger <= 0)
        {
           playerscript.Die();
        }
    }

    public void gainhunger(float value)
    {
        if (hunger >= 100)
        {
            return;
        }
        hunger += value;
        fillbar.value = hunger / 100;
    }
    void Start()
    {
       playerscript = FindObjectOfType<player>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            losehunger(hungervalue);
        }
    }

}
