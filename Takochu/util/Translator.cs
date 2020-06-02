using System.Collections.Generic;
using System.IO;

namespace Takochu.util
{
    public class Translator
    {
        public enum Language
        {
            English,
            German,
            French,
            Japanese,
            Korean,
            Spanish
        }

        public static Dictionary<string, Language> sStringToLang = new Dictionary<string, Language>()
        {
            { "English", Language.English },
            { "German", Language.German },
            { "French", Language.French },
            { "Japanese", Language.Japanese },
            { "Korean", Language.Korean },
            { "Spanish", Language.Spanish }
        };

        public Translator(string lang)
        {
            mLanguage = sStringToLang[lang];
        }

        /*public string GetTranslation(string where, string what)
        {
            string[] lines = File.ReadAllLines()
        }*/

        public string[] GetGalaxyNames()
        {
            string path = "";

            switch (mLanguage)
            {
                case Language.English:
                    path = $"res/translations/en/SimpleGalaxyNames_{(GameUtil.IsSMG1() ? "SMG1.txt" : "SMG2.txt")}";
                    break;

                case Language.German:
                    path = $"res/translations/de/SimpleGalaxyNames_{(GameUtil.IsSMG1() ? "SMG1.txt" : "SMG2.txt")}";
                    break;

                default:
                    path = $"res/translations/en/SimpleGalaxyNames_{(GameUtil.IsSMG1() ? "SMG1.txt" : "SMG2.txt")}";
                    break;
            }

            return File.ReadAllLines(path);
        }

        private Language mLanguage;
    }
}
