// See https://aka.ms/new-console-template for more information

//CPRG 211 F Lab 6 - Using Serialization and Random Access Files (RAF)
//Michael (Zi) Liang 000921925
//Mar 15, 2024

using CPRG211Lab6;
using System.Runtime.CompilerServices;

const string EVENT_FILE_PATH = "event.txt";
const string EVENT_LIST_FILE_PATH = "eventlist.json";
const string HACKATHON_FILE_PATH = "hackathon.txt";

Event event1 = new Event("1", "Calgary");

//De/serialization reference: https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer?view=net-8.0
using (StreamWriter sw = new StreamWriter(EVENT_FILE_PATH))
{
    sw.WriteLine(System.Text.Json.JsonSerializer.Serialize(event1));
}

using (StreamReader sr = new StreamReader(EVENT_FILE_PATH))
{
    Event event1Deserialized = System.Text.Json.JsonSerializer.Deserialize<Event>(sr.ReadToEnd());
    Console.WriteLine(event1Deserialized);
}



List<Event> eventList = new List<Event>();

eventList.Add(event1);
eventList.Add(new Event("2", "Vancouver"));
eventList.Add(new Event("3", "Toronto"));
eventList.Add(new Event("4", "Edmonton"));

using (StreamWriter sw = new StreamWriter(EVENT_LIST_FILE_PATH))
{
    sw.WriteLine(System.Text.Json.JsonSerializer.Serialize(eventList));
}

using (StreamReader sr = new StreamReader(EVENT_LIST_FILE_PATH))
{
    List<Event> eventListDeserialized = System.Text.Json.JsonSerializer.Deserialize<List<Event>>(sr.ReadToEnd());

    foreach (Event eventItem in eventListDeserialized)
    {
        Console.WriteLine(eventItem);
    }
}



using (StreamWriter sw = new StreamWriter(HACKATHON_FILE_PATH))
{
    sw.Write("Hackathon");
}


//Seeking: https://www.dotnetperls.com/seek
void ReadFromFile(string path)
{
    using (StreamReader sr = new StreamReader(path))
    {
        long middle = sr.BaseStream.Length / 2;

        Console.WriteLine($"The First character is: \"{(char)sr.Read()}\"");

        sr.DiscardBufferedData();
        sr.BaseStream.Seek(middle, SeekOrigin.Begin);
        Console.WriteLine($"The Middle character is: \"{(char)sr.Read()}\"");

        sr.DiscardBufferedData();
        sr.BaseStream.Seek(-1, SeekOrigin.End); //-1 because end of file is its own character
        Console.WriteLine($"The Last character is: \"{(char)sr.Read()}\"");
    }
}

ReadFromFile(HACKATHON_FILE_PATH);