#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using System.Text;
public class STSoundGen : MonoBehaviour
{
    static public string path = "Pokemon Battle/Resources/game/";
    static public List<string> names;
    static public List<string> names_array;
    static public List<string>[] names_array_child;
    static public List<string> names_var;
    static public List<string> names_get;
    static public List<string> paths;
    static public string classname = "STSound";
    static string path_inclass;
    static int n;
    static bool IS_LIST = true;
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
        if (IS_LIST)
        GetChildFolders();
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
    static public void GetChildFolders()
    {
        string[] h = Directory.GetDirectories(path);
        names_array = new List<string>();
        names_array_child = new List<string>[h.Length];
        for(int i =0;i<h.Length;i++)
        {
            names_array.Add(GetNameFolder(h[i]));
            names_array_child[i] = new List<string>();
            //Debug.Log(h[i]);
            //Debug.Log(names_array[i]);
            GetAllAudioFilesInFolder(h[i],i);
        }


    }
    static public void GetAllAudioFilesInFolder(string path,int index)
    {
        List<string> paths = new List<string>();
        string[] filePaths = Directory.GetFiles(path, "*.mp3");
        for (int i = 0; i < filePaths.Length; i++) paths.Add(filePaths[i]);
        filePaths = Directory.GetFiles(path, "*.wav");
        for (int i = 0; i < filePaths.Length; i++) paths.Add(filePaths[i]);
        filePaths = Directory.GetFiles(path, "*.ogg");
        for (int i = 0; i < filePaths.Length; i++) paths.Add(filePaths[i]);

        //Debug.Log(paths.Count);
        for (int i = 0; i < paths.Count; i++)
            names_array_child[index].Add(GetName(paths[i]));
        //Debug.Log(names_array_child[index].Count);
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
    static public string GetNameFolder(string str)
    {
        string s = str;
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
        s += "public AudioSource[] audio;\n";
        s += "public int audio_index=1;\n";
        //single ton

        s +="public static "+classname+" Instance\n";
        s +=" {\n";
        s +="get\n";
        s +="{\n";
        s +="if (_instance == null)\n";
        s +="       {\n";
        s +="            GameObject g = new GameObject();\n";
        s +="            g.AddComponent<AudioSource>();\n";
        s +="            g.AddComponent<AudioSource>();\n";
        s +="            g.AddComponent<AudioSource>();\n";
        s +="            g.AddComponent<AudioSource>();\n";
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
            s += "AudioClip " + names_var[i] + "_;\t";
            s += "float " + names_var[i] + "_time;\n";
            Debug.Log(names_var[i]);
        }
        //for (int i = 0; i < n; i++) 
        //{
        //    s += "float " + names_var[i] + "_time;\n";
        //}
        s+= "\nstring path_inclass = \""  + path_inclass + "\";\n\n";
        //for list
        if (IS_LIST)
        {
            s += "//LIST\n";
            for (int i = 0; i < names_array.Count; i++)
            {
                if (IS_LIST)
                {
                    s += "AudioClip[] " + names_array[i] + "_;\t";
                    s += "float " + names_array[i] + "_time;";
                    s += "int " + names_array[i] + "_legnth = " + names_array_child[i].Count + ";\n";
                }

                string st = "string[] " + names_array[i] + "_childrennames={"  ;
                for(int j=0;j<names_array_child[i].Count;j++)
                {
                    st += "\"" + names_array[i] + "/"+names_array_child[i][j] + "\"";
                    if (j < names_array_child[i].Count - 1)
                        st += ",";
                }
                st+="};\n";
                s += st ;

                //function

                s += "public void PlayList_" + names_array[i] + "(int index,float time=-1,float pit_start=1,float pit_end=1,float volum_start=1,float volum_end=1)\n";
                s += "{\n";
                s += "    if (" + names_array[i] + "_" + " == null) " + names_array[i] + "_" + " = new AudioClip[" + names_array[i] + "_" + "legnth];\n";
                s += "    if(" + names_array[i] + "_" + "[index]==null) " + names_array[i] + "_" + "[index] = Resources.Load<AudioClip>(path_inclass+\"/\"+" + names_array[i] + "_" + "childrennames[index]);\n";
                s += "    if (" + names_array[i] + "_" + "[index] == null) Debug.Log(\"khong load dc:\" + path_inclass + \"/\" + " + names_array[i] + "_" + "childrennames[index]);\n";
                s += "    if (time > 0)\n";
                s += "    {\n";
                s += "        if (Time.time - " + names_array[i] + "_" + "time < time) return;\n";
                s += "    }\n";
                s += "   " + names_array[i] + "_" + "time = Time.time;\n";
                s += "    if (pit_start == -1)\n";
                s += "        PLayOneShot(" + names_array[i] + "_" + "[index]);\n";
                s += "    else PLayOneShotEffect(" + names_array[i] + "_" + "[index],pit_start,pit_end,volum_start,volum_end);\n";
                s += "}\n";
                //play random


                s += "public void PlayList_" + names_array[i] + "_" + "_random(float time = -1,float pit_start=1,float pit_end=1,float volum_start=1,float volum_end=1)\n";
                s += "{\n";
                s += "    int index = Random.Range(0, " + names_array[i] + "_" + "legnth);\n";
                s += "    PlayList_" + names_array[i] + "(index, time);\n";
                s += "}\n";

                s += "\n\n";

            }
            




            s += "//END LIST\n";
        }
        s += "\n\n";
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
        //play effect
        for (int i = 0; i < n; i++)
        {
            s += "    public void PlayEffect_" + names_var[i] + "(float pit_start = 1, float pit_end = 1, float volum_start = 1, float volum_end = 1, float time = -1 )\n";
            s += "    {\n";
            s += "        if(time>0)\n";
            s += "        {\n";
            s += "            if(Time.time-" + names_var[i] + "_time < time) return;\n";
            s += "        }\n";
            s += "            " + names_var[i] + "_time = Time.time;\n";
            s += "         //PLayOneShot(" + names_get[i] + ");\n";
            s += "         PLayOneShotEffect("+ names_get[i] +", pit_start, pit_end, volum_start, volum_end);\n";
            s += "    }\n";
        }   
        //define functions here
        //play one shot
        s += "\npublic void PLayOneShot(AudioClip c,float delta_time=-1)\n";
	    s += "{\n";
        s += "  if (audio == null) audio = GetComponents<AudioSource>();\n";
        s += "  if (audio == null|| audio.Length==0) Debug.LogError(\"Can phai add AudioSource vao gameobject nay\");\n";
        s += "audio_index++; if (audio_index >= audio.Length) audio_index = 1;\n";
        s += "audio[audio_index].pitch = 1;\n";
        s += "audio[audio_index].volume = 1;\n";
        s += "  audio[audio_index].PlayOneShot(c);\n";
        s += "}\n";

        //play random
        s += "public void PLayOneShotEffect(AudioClip c,float pit_start=1,float pit_end=1,float volum_start=1,float volum_end=1, float delta_time = -1)\n";
        s += "{\n";
        s += "    if (audio == null) audio = GetComponents<AudioSource>();\n";
        s += "    if (audio == null || audio.Length == 0) Debug.LogError(\"Can phai add AudioSource vao gameobject nay\");audio_index++; if (audio_index >= audio.Length) audio_index = 1;audio[audio_index].pitch = 1;audio[audio_index].volume = 1;\n";
        s += "    audio[audio_index].pitch = Random.Range(pit_start, pit_end);\n";
        s += "    audio[audio_index].volume = Random.Range(volum_start, volum_end);\n";
        s += "    audio[audio_index].PlayOneShot(c);\n";
        s += "}\n";


        //function play music


        //

        s += "public void playMusic(AudioClip sound)\n"; 
        s += "{\n";
        s += "    if (Instance != null)\n";
        s += "    {\n";
        s += "        if (audio == null) audio = GetComponents<AudioSource>();\n";
        s += "        if (audio == null || audio.Length==0) Debug.LogError(\"Can phai add AudioSource vao gameobject nay\");\n";
        s += "        audio[0].clip = sound;\n";
        s += "        audio[0].loop = true;\n";
        s += "        audio[0].Play();\n";
        s += "    }\n";
        s += "}\n";

        //s += "AudioClip  currentloop;\n";
        //s += "public void playLoopSingle(AudioClip sound,float time){if (Instance != null){if (audio == null) audio = GetComponent<AudioSource>();currentloop = sound;StartCoroutine(singgleloop(time));}}\n";
        //s += "IEnumerator singgleloop(float time){PLayOneShot(currentloop);yield return new WaitForSeconds(time);StartCoroutine(singgleloop(time));}\n";

        //emd
        s += "}\n\n";
        return s;
    }

    static public void GenObject()
    {
        GameObject g = new GameObject();
    }

    [MenuItem("STGame/Sound Manager/Gen", false, 0)]
    static void GenEditor()
    {
        Debug.Log("here");
    }
    [MenuItem("Assets/STGame/Sound Manager/Gen (Multiple Source)")]
    static void Gencontext()
    {
        Object folder = Selection.activeObject;
        string rootPath = Path.GetFullPath(AssetDatabase.GetAssetPath(folder));
        Debug.Log(rootPath);
        path = rootPath;
        IS_LIST = false;
        GenerateSTSound();
        
    }

    [MenuItem("Assets/STGame/Sound Manager/Gen (Multiple Source(Folder List))")]
    static void Gencontext_List()
    {
        Object folder = Selection.activeObject;
        string rootPath = Path.GetFullPath(AssetDatabase.GetAssetPath(folder));
        Debug.Log(rootPath);
        path = rootPath;
        IS_LIST = true;
        GenerateSTSound();

    }


    [MenuItem("Assets/STGame/Sound Manager/Set All Audio to 2D")] 
    static void Set2DAll()
    {
        Object[] audioclips = GetSelectedAudioclips();
        Selection.objects = new Object[0];
        foreach (AudioClip audioclip in audioclips)
        {
            string path = AssetDatabase.GetAssetPath(audioclip);
            AudioImporter audioImporter = AssetImporter.GetAtPath(path) as AudioImporter;
            //audioImporter.compressionBitrate = (int)newCompressionBitrate;
            audioImporter.threeD = false;
            Debug.Log(audioImporter.threeD);
            AssetDatabase.ImportAsset(path);
        }
    }
    [MenuItem("Assets/STGame/Sound Manager/Set All Audio to 3D")]
    static void Set3DAll()
    {
        Object[] audioclips = GetSelectedAudioclips();
        Selection.objects = new Object[0];
        foreach (AudioClip audioclip in audioclips)
        {
            string path = AssetDatabase.GetAssetPath(audioclip);
            AudioImporter audioImporter = AssetImporter.GetAtPath(path) as AudioImporter;
            audioImporter.threeD = true;
            Debug.Log(audioImporter.threeD);
            AssetDatabase.ImportAsset(path);
        }
    }

    [MenuItem("Assets/STGame/Sound Manager/Set All Audio Compress to 156kbps")]
    static void CompressAll156()
    {
        SelectedSetCompressionBitrate(156000);
    }

    [MenuItem("Assets/STGame/Sound Manager/Set All Audio Compress to 128kbps")]
    static void CompressAll128()
    {
        SelectedSetCompressionBitrate(128000);
    }

    [MenuItem("Assets/STGame/Sound Manager/Set All Audio Compress to 96kbps")]
    static void CompressAll96()
    {
        SelectedSetCompressionBitrate(96000);
    }
    [MenuItem("Assets/STGame/Sound Manager/Set All Audio Compress to 64kbps")]
    static void CompressAll64()
    {
        SelectedSetCompressionBitrate(64000);
    }


    static void SelectedSetCompressionBitrate(float newCompressionBitrate)
    {

        Object[] audioclips = GetSelectedAudioclips();
        Selection.objects = new Object[0];
        foreach (AudioClip audioclip in audioclips)
        {
            string path = AssetDatabase.GetAssetPath(audioclip);
            AudioImporter audioImporter = AssetImporter.GetAtPath(path) as AudioImporter;
            audioImporter.compressionBitrate = (int)newCompressionBitrate;
            AssetDatabase.ImportAsset(path);
        }
    }

    static Object[] GetSelectedAudioclips()
    {
        return Selection.GetFiltered(typeof(AudioClip), SelectionMode.DeepAssets);
    }
}

#endif