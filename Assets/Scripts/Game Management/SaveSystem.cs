using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
 
    public static void SaveTotalCoffees(OrderCheck orderData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/coffeecorrectness.bruh";
        FileStream stream = new FileStream(filePath, FileMode.Create);

        CoffeeData data = new CoffeeData(orderData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CoffeeData loadTotalCoffees()
    {
        string filePath = Application.persistentDataPath + "/coffeecorrectness.bruh";
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

           CoffeeData data = formatter.Deserialize(stream) as CoffeeData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save File Not Found in " + filePath);
            return null;
        }
    }

}
