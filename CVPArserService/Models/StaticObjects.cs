using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVPArserService.Models
{
    public static class StaticObjects
    {
        //static Dictionary<string , string >  
        public static List<Keyword> Keywords;
    }
    public class Keyword
    {
        public static string Name { get; set; }
        public static string Value { get; set; }
    }
}