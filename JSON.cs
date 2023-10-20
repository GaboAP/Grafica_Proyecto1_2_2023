using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ProGrafica
{
    internal class JSON
    {
        public static void Save(String path, object objeto)
        {
            String output = JsonConvert.SerializeObject(objeto,
                Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText(path, output);
        }

        public static T Load<T>(String path)
        {
            String output = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(output,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        }
    }
}
