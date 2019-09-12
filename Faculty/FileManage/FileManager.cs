using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Faculty.FileManage
{
    public class FileManager : IFileManager<string>
    {
        private static readonly Encoding defaultEncoding = Encoding.GetEncoding(1251);

        public void CreateFile(string path)
        {
            File.Create(path);
        }

        public string GetContent(string path)
        {
            return File.ReadAllText(path, defaultEncoding);
        }

        public string GetContent(string path, Encoding encoding)
        {
            return File.ReadAllText(path, encoding);
        }

        public string[] GetLines(string path)
        {
            return File.ReadAllLines(path, defaultEncoding);
        }

        public string[] GetLines(string path, Encoding encoding)
        {
            return File.ReadAllLines(path, encoding);
        }

        public int GetSymbolCount(string content)
        {
            return content.Length;
        }

        public bool IsExists(string path)
        {
            return File.Exists(path);
        }

        public void SaveContent(string content, string path)
        {
            File.AppendAllText(path, content, defaultEncoding);
        }

        public void SaveContent(string content, string path, Encoding encoding)
        {
            File.AppendAllText(path, content, encoding);
        }

        public void ClearFile(string path)
        {
            
        }
    }
}