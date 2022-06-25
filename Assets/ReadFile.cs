using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadFile : MonoBehaviour
{
    public static void WriteString(string file, string text)
    {
        string path = Application.persistentDataPath + file;

        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(text);
        writer.Close();
        StreamReader reader = new StreamReader(path);
        reader.Close();
    }
    public static string ReadString(string file)
    {
        string path = Application.persistentDataPath + file;

        StreamReader reader = new StreamReader(path);
        string returnString = reader.ReadToEnd();
        reader.Close();

        return returnString;
    }
}
