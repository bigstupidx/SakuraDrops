using UnityEngine;  
using System;  
using System.Collections;  
using System.Xml.Serialization;  
using System.IO;

public class FileMap : Singleton<FileMap> {

	// writeStringToFile
	public void writeStringToFile( string str, string filename )
	{
		#if !UNITY_WEBPLAYER
		string path = pathForDocumentsFile( filename );

		Debug.Log("path : " + path);

		FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);

		StreamWriter sw = new StreamWriter( file );
		sw.WriteLine( str );

		sw.Close();
		file.Close();
		#endif 
	}

	// readStringFromFile
	public string readStringFromFile( string filename)//, int lineIndex )
	{
		#if !UNITY_WEBPLAYER
	    string path = pathForDocumentsFile( filename );

		Debug.Log("path : " + path);

	    if (File.Exists(path))
	    {
	        FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
	        StreamReader sr = new StreamReader( file );

	        string str = null;
	        str = sr.ReadLine ();

	        sr.Close();
	        file.Close();

	        return str;
	    }
	    else
		{
	        return null;
	    }
		#endif

		return null;
	}

	// pathForDocumentsFile
	public string pathForDocumentsFile( string filename ) 
	{ 
	    if (Application.platform == RuntimePlatform.IPhonePlayer)
	    {
			/*
	        string path = Application.dataPath.Substring( 0, Application.dataPath.Length - 5 );
	        path = path.Substring( 0, path.LastIndexOf( '/' ) );
	        return Path.Combine( Path.Combine( path, "Documents" ), filename );
	        */

			string path = Application.persistentDataPath + "/";
			return Path.Combine( path, filename );
	    }
	    else if(Application.platform == RuntimePlatform.Android)
	    {
	        string path = Application.persistentDataPath; 
	        path = path.Substring(0, path.LastIndexOf( '/' ) ); 
	        return Path.Combine (path, filename);
	    } 
	    else 
	    {
	        string path = Application.dataPath; 
	        path = path.Substring(0, path.LastIndexOf( '/' ) );
	        return Path.Combine (path, filename);
	    }
	}
}
