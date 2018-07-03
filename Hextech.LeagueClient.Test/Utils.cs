using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace Hextech.LeagueClient.Test
{
    internal static class Utils
    {
        public static void JsonPrintAndVerify(object obj)
        {
            string str = obj.ToString();

            try
            {
                JsonConvert.DeserializeObject(str);
            }
            catch (JsonReaderException)
            {
                Assert.Fail("Invalid JSON string! Maybe the object doesn't inherit JsonSerializable?");
            }
            catch
            {
                throw;
            }

            Console.WriteLine(str);
        }
    }
}
