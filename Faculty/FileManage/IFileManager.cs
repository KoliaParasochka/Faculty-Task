using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty.FileManage
{
    public interface IFileManager<T>
    {
        bool IsExists(T path);
        int GetSymbolCount(T content);
        string[] GetLines(T path);
        string[] GetLines(T path, Encoding encoding);
        string GetContent(T path);
        string GetContent(T path, Encoding encoding);
        void SaveContent(string content, T path);
        void SaveContent(string content, T path, Encoding encoding);
        void CreateFile(T path);
    }
}
