using Lesson10.Models;
using System.Text.Json;

namespace Lesson10.Services;

/// <summary>
/// Base
/// </summary>
public static class FileManagerService
{
    private static string PathFile = @"D:\c#Projects\HomeTasksPdp\Lesson10\Lesson10\Repository\Base.json";

    public static void Write(Cart cart)
    {
        using (StreamWriter sw = new StreamWriter(PathFile))
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true
            };
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
        using (StreamReader sr = new StreamReader(PathFile))
        {
            if (!File.Exists(PathFile))
            {
                return new Cart();
            }

            return JsonSerializer.Deserialize<Cart>(sr.ReadToEnd() ?? string.Empty,
                new JsonSerializerOptions { IncludeFields = true })
                ?? new Cart();
        }
    }

}
