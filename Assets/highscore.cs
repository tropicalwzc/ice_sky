using UnityEngine;
using System.Collections;
using System;
using System.IO;
// hight score counter
public class highscore : MonoBehaviour
{

    string fileName = "highscore.ice";
    int score;
    int highestscore;
    //int cannotopen=0;
    files filer = new files();
    int bigbuttonsize;
    int proper_fontsize;
    int proper_barheight;
    void destroysmall(int news)
    {
        score += news;

        if (score > highestscore)
        {
            writescore(score);
        }

    }
    int readscore()
    {
        string textre = "";
        textre = filer.ReadTextFile(fileName);
        //  print(textre);
        return trans(textre);
    }
    void writescore(int scorer)
    {
        string fsco = "" + scorer;
        filer.WriteTextFile(fileName, fsco);
    }
    int pow(int n)
    {
        int res = 1;
        for (int j = 0; j < n; j++)
            res *= 10;

        return res;
    }
    int trans(string f)
    {
        int res = 0;
        int ran;
        int jj = 0;
        int j = 0;
        foreach (char bigger in f)
        {
            jj++;
        }
        foreach (char will in f)
        {
            int po = jj - j - 1;
            int num = (int)will - 48;
            ran = pow(po);
            res += ran * num;
            j++;
        }
        return res;
    }

    // Use this for initialization
    void Start()
    {
        score = 0;
        highestscore = readscore();
    }
    int one = 0;
    // Update is called once per frame
    void Update()
    {
        if (one == 0)
        {
            bigbuttonsize = this.GetComponent<proper_ui>().proper_big_button;
            proper_barheight = this.GetComponent<proper_ui>().proper_bar_height;
            proper_fontsize = this.GetComponent<proper_ui>().proper_font_size;
        }
    }
    void OnGUI()
    {
        GUI.skin.label.fontSize = proper_fontsize;
        GUI.skin.label.normal.textColor = new Vector4(247f / 255f, 248f / 255f, 175f / 255f, 1.0f);
        if (score < highestscore)
            GUI.Label(new Rect(Screen.width - bigbuttonsize * 3, Screen.height - proper_barheight * 2, Screen.width / 4, proper_barheight), " ><> " + highestscore + " <>< ");
        else
        {
            GUI.Label(new Rect(Screen.width - bigbuttonsize * 3, Screen.height - proper_barheight * 2, Screen.width / 4, proper_barheight), " ><> " + "新纪录" + " <>< ");
        }
    }
}
