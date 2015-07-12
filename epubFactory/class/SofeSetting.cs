using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace epubFactory
{
    public static class SofeSetting
    {
        //public const string SofeId = "LeFe TEST PROJECT"; //标识符
        //public const string Edition = "LeFe 0.0.1 BETA";  //版本
	    private static string xmlFile = "config.xml";
        private static SerializableDictionary<string, string> settings = new SerializableDictionary<string, string>();
        public static void init()
        {
            try
            {
                using (FileStream fileStream = new FileStream(xmlFile, FileMode.OpenOrCreate))
                {
                    XmlSerializer xmlFormatter = new XmlSerializer(typeof(SerializableDictionary<string, string>));
                    settings = (SerializableDictionary<string, string>)xmlFormatter.Deserialize(fileStream);
                }
            }
            catch (Exception e)
            {
            }
        }
        public static string Get(string key)
        {
            if (settings.Count == 0)
            {
                init();
            }
            if (!settings.ContainsKey(key))
            {
                string tmp = GetDefault(key);
                if (tmp!="")
                {
                    Set(key, tmp);
                    return tmp;
                }
                return "";
            }
            //Set(key, settings[key]);
            return settings[key];
        }
        public static string GetDefault(string key)
        {
            switch (key)
            {
                case "生成模板": return "默认";
                case "[MAKER]": return "填写你自己的ID";
                case "[SUBJECT]": return "轻小说";
                case "[DESCRIPTION]": return "本ePub由XXX制作";
                case "[SOURCE]": return "个人或组织名";
                case "[PUBLISHER]": return "ePub制作组";
                case "[RIGHT]": return "http://www.baidu.com/你的网址";
                default:
                    return "";
            }
        }
        ///<summary> 
        ///更新连接字符串 
        ///</summary> 
        public static void Set(string key, string value)
        {
            if (settings.ContainsKey(key))
            {
                settings.Remove(key);
            }
            settings.Add(key,value);
            using (FileStream fileStream = new FileStream(xmlFile, FileMode.Create))
            {
                XmlSerializer xmlFormatter = new XmlSerializer(typeof(SerializableDictionary<string, string>));
                xmlFormatter.Serialize(fileStream, settings);
            }
        }
        ///<summary> 
        ///清空已有内容 
        ///</summary> 
        public static void Destroy()
        {
            settings.Clear();
        }
	}
}
