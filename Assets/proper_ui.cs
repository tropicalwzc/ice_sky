using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proper_ui : MonoBehaviour {

    public int proper_big_button = 30;
    public int proper_bar_height = 20;
    public int proper_text_size = 15;
    public int proper_font_size = 15;
    // Use this for initialization
    void Awake()
    {
        if (Screen.height > 1300)
        {
            proper_big_button = 100;
            proper_bar_height = 50;
            proper_text_size = 35;
            proper_font_size = 35;
        }
        else{

            if(Screen.height>900)
            {
                proper_big_button = 60;
                proper_bar_height = 40;
                proper_text_size = 20;
                proper_font_size = 20;
            }

        }

    }
    private void Start()
    {
        if (Screen.height > 1300)
        {
            proper_big_button = 100;
            proper_bar_height = 50;
            proper_text_size = 35;
            proper_font_size = 35;
        }
        else
        {

            if (Screen.height > 900)
            {
                proper_big_button = 60;
                proper_bar_height = 40;
                proper_text_size = 20;
                proper_font_size = 20;
            }

        }
    }
    public void set_proper_ui_style(GUIStyle good)
    {
        if (Screen.height <= 900)
            good.fontSize = 15;
        else
        if (Screen.height > 900 && Screen.height <= 1300)
            good.fontSize = 20;
        else
        if (Screen.height > 1300)
            good.fontSize = 35;
    }
}
