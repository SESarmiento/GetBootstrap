﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace System.Extensions
{
    internal class LoggerXmlFile
    {
        private string _name;
        private string _dir;
        private string _filename;

        public LoggerXmlFile(string name, string path, string filename)
        {
            _name = name;
            _dir = path;
            _filename = filename;
        }

        internal void XmlWrite(DateTime now, string level, string format)
        {
            string fileDir = $"{_dir}/{_filename}";

            XmlDocument xml = new XmlDocument();
            xml.Load(fileDir);
            var loggerNode = xml.SelectSingleNode($"//GetBootstrap/Logger[@name='{_name}']");

            if (loggerNode == null)
            {
                var node = xml.CreateNode(XmlNodeType.Element, "Logger", "");

                var attr = xml.CreateAttribute("name");
                attr.Value = _name;

                node.Attributes.Append(attr);

                var root = xml.DocumentElement;
                root.AppendChild(node);
            }

            loggerNode = xml.SelectSingleNode($"//GetBootstrap/Logger[@name='{_name}']");
            var logNode = xml.CreateNode(XmlNodeType.Element, "Log", "");
            loggerNode.AppendChild(logNode);

            var levelNode = xml.CreateNode(XmlNodeType.Element, "Level", "");
            levelNode.InnerText = level;
            var dateNode = xml.CreateNode(XmlNodeType.Element, "Date", "");
            dateNode.InnerText = now.ToString();
            var descNode = xml.CreateNode(XmlNodeType.Element, "Description", "");
            descNode.InnerText = format;

            logNode.AppendChild(levelNode);
            logNode.AppendChild(dateNode);
            logNode.AppendChild(descNode);

            xml.Save(fileDir);
        }

        internal void GenerateXmlFile()
        {
            if (!Directory.Exists(_dir))
            {
                Directory.CreateDirectory(_dir);
            }

            string fileDir = $"{_dir}/{_filename}";

            if (!File.Exists(fileDir))
            {
                XmlWriterSettings xmlSettings = new XmlWriterSettings();
                xmlSettings.Indent = true;
                xmlSettings.NewLineOnAttributes = true;
                using (var xml = XmlWriter.Create(fileDir, xmlSettings))
                {
                    xml.WriteStartDocument();
                    string pitext = $"type=\"text/xsl\" href=\"../XSLT/default.xslt\"";
                    xml.WriteProcessingInstruction("xml-stylesheet", pitext);
                    xml.WriteStartElement("GetBootstrap");
                    xml.WriteEndDocument();
                    xml.Flush();
                    xml.Close();
                }
            }
        }
    }
}
