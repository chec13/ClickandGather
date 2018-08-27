using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCodes : MonoBehaviour {
    private static Dictionary<string, textureSprite> ui_codes;
    private static Dictionary<string, GameObject> object_codes;
    //public Texture[] TextureObjects;
    public Sprite[] SpriteObjects;
    public string[] s;
    public string[] obj_s;
    public GameObject[] g;
    static bool initialized = false;
	// Use this for initialization
	void Awake () {
        ui_codes = new Dictionary<string, textureSprite>();
        object_codes = new Dictionary<string, GameObject>();
		for (int x = 0; x < SpriteObjects.Length && x <s.Length; x++)
        {
            ui_codes.Add(s[x], new textureSprite( SpriteObjects[x].texture, SpriteObjects[x]));
        }
        for (int x = 0; x < obj_s.Length && x < g.Length; x++)
        {
            object_codes.Add(obj_s[x], g[x]);
            Debug.Log("test");
        }
	}
    public static Texture getTex(string s)
    {
        
        Texture t = ui_codes[s].t;
        int x = ui_codes.Count;
        return t;
    }
    public static Sprite getSprite(string s)
    {
        Sprite t = ui_codes[s].s;
        int x = ui_codes.Count;
        return t;
    }
	public static GameObject getObject(string s)
    {
        
        Debug.Log(s);
        Debug.Log(object_codes.Keys);
        GameObject g = object_codes[s];
        
        return g;
    }
	// Update is called once per frame
	void Update () {
		
	}
    public struct textureSprite
    {
        public Texture t;
        public Sprite s;
       public textureSprite( Texture tex, Sprite sp)
        {
            t = tex;
            s = sp;
        }
    }
    
    
}
