using Lesson10.Models;
//using Newtonsoft.Json;
using System.Text.Json;

namespace Lesson10.Services;

/// <summary>
/// Base
/// </summary>
public static class FileManagerService
{
    private static string PathFile = @"D:\c#Projects\HomeTasksPdp\Lesson10\Lesson10\Repository\Base.json";
    private static JsonSerializerOptions options = new JsonSerializerOptions
    {
        IncludeFields = true,
        PropertyNameCaseInsensitive = true
    };
    public static void Write(Cart cart)
    {
        using (StreamWriter sw = new StreamWriter(PathFile))
        {

            if (!File.Exists(PathFile))
            {

                var jsonSerializer = JsonSerializer.Serialize(cart, options);
                sw.WriteLine(jsonSerializer);

            }
            else
            {
                var jsonSerializer = JsonSerializer.Serialize(cart, options);
                sw.WriteLine(jsonSerializer);
            }
        }
    }


    public static Cart Read()
    {

        if (!File.Exists(PathFile))
        {
            return new Cart();
        }

        var json = File.ReadAllText(PathFile);


        var desirialize = JsonSerializer.Deserialize<Cart>(json, options);
        //var desirialize = JsonConvert.DeserializeObject<Cart>(json);

        return desirialize ?? new Cart();

    }

}
