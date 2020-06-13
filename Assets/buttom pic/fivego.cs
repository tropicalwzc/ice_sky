using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class fivego : MonoBehaviour {

    public string levelname;
    void Start () {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
    }

    private void OnClick(){
        if(levelname=="Quit"||levelname=="quit")
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
        }
        else
        {
            SceneManager.LoadScene(levelname);
        }
        
    }
}
