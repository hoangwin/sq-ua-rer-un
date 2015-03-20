#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
public class STSoundGen_Sample : MonoBehaviour
{
    static public string path = "Pokemon Battle/Resources/game/";
    static public List<string> names;
    static public List<string> names_var;
    static public List<string> names_get;
    static public List<string> paths;
    static public string classname = "STSound";
    static string path_inclass;
    static int n;
    void Start()
    {
        
    }

    void Update()
    {
        //STSound.Instance.PLayOneShot(STSound.Instance.victory);
//        STSound.Instance.Play_victory(1);
    }

    [ContextMenu("Generate STSound")]
    public static void GenerateSTSound()
    {
        paths = new List<string>();
        names = new List<string>();
        names_var = new List<string>();
        names_get = new List<string>(); 
        string str =  path;

        string[] filePaths = Directory.GetFiles(str, "*.mp3");
        for (int i = 0; i < filePaths.Length; i++) paths.Add(filePaths[i]);
        filePaths = Directory.GetFiles(str, "*.wav");
        for (int i = 0; i < filePaths.Length; i++) paths.Add(filePaths[i]);
        filePaths = Directory.GetFiles(str, "*.ogg");
        for (int i = 0; i < filePaths.Length; i++) paths.Add(filePaths[i]);

        //string[] files = Directory.GetFiles(str, "*.*", SearchOption.AllDirecto).Where(s => s.EndsWith(".mp3") || s.EndsWith(".wav"));

        //        string[] filePaths = Directory.GetFiles(str, "");

        n = paths.Count;
        for (int i = 0; i < n; i++)
        {
            names.Add(GetName(paths[i]));
            
            names_var.Add(RemoveSpecialCharacters(names[i]) + "");
            names_get.Add("_"+names_var[i] );
            Debug.Log("Found: " + names[i]);
            for (int j = i + 1; j < n; j++)
                if (paths[i] == paths[j]) Debug.LogError("toanstt : khong dc trung file name: " + paths[i]);

            
        }

        path_inclass = GetPathAudioCLips();
        string s = RealGenClass();
         
        Debug.Log(path_inclass);


        File.WriteAllText(Application.dataPath + "/" + classname + ".cs", s);

        AssetDatabase.Refresh();
        
    }
    public static string RemoveSpecialCharacters(string str)
    {
        string str2 = str.Replace("-", "_");
        str2 = str2.Replace("+", "_");
        str2 = str2.Replace("-", "_");
        str2 = str2.Replace(" ", "_");
        str2 = str2.Replace("(", "_");
        str2 = str2.Replace(")", "_");
        Debug.Log(str2);
        return str2;
    }
    static public string GetPathAudioCLips()
    {
        Debug.Log(path); 
        int index = path.IndexOf("Resources");
        index+=10;
        string s= path.Substring(index,path.Length - index);
        Debug.Log(s); 
        s = s.Replace("\\" , "/");
        if (s[s.Length - 1] == '/') s = s.Substring(0, s.Length - 1);
        return s; 
    }
    static public string GetName(string str)
    { 
        string s = str.Substring(0, str.IndexOf("."));
        int index;
        for (index = s.Length - 1; index >= 0; index--)
        {
            if (s[index] == '/') break;
        } 
        s = s.Substring(index + 1, s.Length - index - 1);

        for (index = s.Length - 1; index >= 0; index--)
        {
            if (s[index] == '\\') break;
        }
        s = s.Substring(index + 1, s.Length - index - 1);
        return s;

      
    }
    static public string RealGenClass()
    {

        string s = "using UnityEngine;\n";
        s += "using System.Collections;\n";
        s += "using System.Collections.Generic;\n";
        s += "public class " + classname + ": MonoBehaviour  \n{\n";

        //define variables here
        s += "private static " + classname + " _instance;\n";
        s += "public AudioSource audio;\n"; 
        
        //single ton

        s +="public static "+classname+" Instance\n";
        s +=" {\n";
        s +="get\n";
        s +="{\n";
        s +="if (_instance == null)\n";
        s +="       {\n";
        s +="            GameObject g = new GameObject();\n";
        s +="            g.AddComponent<AudioSource>();\n";
        s +="           g.AddComponent<"+classname+">();\n";
        s +="           _instance = g.GetComponent<"+classname+">();\n";
        s +="           DontDestroyOnLoad(g.gameObject);\n";
        s +="       }";
        s +="       return _instance;\n";
        s +=" }\n";
        s +="}\n";
        //end 
        for (int i = 0; i < n;i++ )
        {
            s += "AudioClip " + names_var[i] + "_;\n";
            Debug.Log(names_var[i]);
        }
        for (int i = 0; i < n; i++) 
        {
            s += "float " + names_var[i] + "_time;\n";
        }
        s+= "string path_inclass = \""  + path_inclass + "\";\n";

        //get set 

        for (int i = 0; i < n;i++ )
        {
            s += "    public AudioClip " + names_get[i] + "\n";
        s+="{";
        s+="get";
        s+="{";
        s += "if (" + names_var[i] + "_ == null)";
        s += names_var[i] + "_ = Resources.Load<AudioClip>(path_inclass" + "+\"/\"+" + "\"" + names[i] + "\"" + ");";
        s += "return " + names_var[i] + "_;";
        s+="}"; 
        s += "}\n";
        }
        //play otimaze
        for (int i = 0; i < n;i++ ) 
        {
            s += "    public void Play_" + names_var[i] + "(float time=- 1 )\n";
            s+="    {\n";
            s+="        if(time>0)\n";
            s+="        {\n";
            s += "            if(Time.time-" + names_var[i] + "_time < time) return;\n";
            s+="        }\n";
            s += "            " + names_var[i] + "_time = Time.time;\n";
            s += "         PLayOneShot(" + names_get[i] + ");\n";
            s +="    }\n";
        }  
        //define functions here
        //play one shot
        s += "\npublic void PLayOneShot(AudioClip c,float delta_time=-1)\n";
	    s += "{\n";
        s += "  if (audio == null) audio = GetComponent<AudioSource>();\n";
        s += "  if (audio == null) Debug.LogError(\"Can phai add AudioSource vao gameobject nay\");\n";
        s += "  audio.PlayOneShot(c);\n";
        s += "}\n";
        //function play music

        s += "public void playMusic(AudioClip sound)\n";
        s += "{\n";
        s += "    if (Instance != null)\n";
        s += "    {\n";
        s += "        if (audio == null) audio = GetComponent<AudioSource>();\n";
        s += "        if (audio == null) Debug.LogError(\"Can phai add AudioSource vao gameobject nay\");\n";
        s += "        audio.clip = sound;\n";
        s += "        audio.loop = true;\n";
        s += "        audio.Play();\n";
        s += "    }\n";
        s += "}\n";
        s += "AudioClip  currentloop;\n";
        s += "public void playLoopSingle(AudioClip sound,float time){if (Instance != null){if (audio == null) audio = GetComponent<AudioSource>();currentloop = sound;StartCoroutine(singgleloop(time));}}\n";
        s += "IEnumerator singgleloop(float time){PLayOneShot(currentloop);yield return new WaitForSeconds(time);StartCoroutine(singgleloop(time));}\n";

        //emd
        s += "}\n\n";
        return s;
    }

    static public void GenObject()
    {
        GameObject g = new GameObject();
    }


    [MenuItem("Assets/STGame/Sound Manager/Gen (Simple)")]
    static void Gencontext()
    {
        Object folder = Selection.activeObject;
        string rootPath = Path.GetFullPath(AssetDatabase.GetAssetPath(folder));
        Debug.Log(rootPath);
        path = rootPath;
        GenerateSTSound();
    }
}

#endif