using System.IO;
using System.Xml.Serialization;
using System;

public static class Serializer<Data>
{
    public static void Save(string path, Data data)
    {
        XmlSerializer formatter = new XmlSerializer(typeof(Data));

        using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
        {
            formatter.Serialize(stream, data);
        }
    }

    public static Data Load(string path)
    {
        Type type = typeof(Data);
        Data retVal;

        XmlSerializer formatter = new XmlSerializer(type);

        using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            retVal = (Data)formatter.Deserialize(stream);
        }

        return retVal;
    }
}