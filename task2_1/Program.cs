using System.IO;
using System.Text;


string text = ReadFromFile(@"D:\C#\IT\task2_1\file.txt"); 
string clearedText = ClearString(text); 
string sortedText = SortText(clearedText); 
WriteToFile(@"D:\C#\IT\task2_1\file1.txt", sortedText); 


string ReadFromFile(string path)
{
    string buff;
    StreamReader reader = new StreamReader(path);
    buff = reader.ReadToEnd();
    reader.Close();
    return buff;
}


void WriteToFile(string path, string str)
{
    FileStream fStream = new FileStream(path, FileMode.OpenOrCreate);
    StreamWriter writer = new StreamWriter(fStream);
    writer.Write(str);
    writer.Close();
    fStream.Close();
}


string ClearString(string str)
{
    List<char> letters = new List<char>();
    for (int i = 0; i < str.Length; i++)
    {
        if(!letters.Contains(str[i]))
        {
            letters.Add(str[i]);
        }
        else
        {
            str = str.Remove(i, 1);
            i--;
        }
    }
    return str;
}

string SortText(string str)
{
    for (int i = 0; i < str.Length; i++)
    {
        for (int j = 0; j < str.Length - i - 1; j++)
        {
            if (str[j].CompareTo(str[j + 1]) > 0)
            {
                string newStr = str[j + 1].ToString() + str[j].ToString();
                string oldStr = str[j].ToString() + str[j + 1].ToString();
                str = str.Replace(oldStr, newStr);
            }
        }
    }
    return str;
}
