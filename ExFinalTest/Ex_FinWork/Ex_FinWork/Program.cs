using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace Ex_FinWork
{
    class FileInfo
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string Signature { get; set; }
        public override string ToString()
        {
            return string.Format("{0}\n\n{1}\n\n{2}\n\n", Header, Body, Signature);
        }
    }
    class Files
    {
        public string S { set; private get; }
        public Files(string s)
        {
            S = s;
        }
        public List<FileInfo> GetInfoFiles()
        {
            Dictionary<string, IParser> vocabulary = new Dictionary<string, IParser>();
            vocabulary.Add(".txt", new TxtParser());
            vocabulary.Add(".html", new HtmlParser());
            List<FileInfo> fileInfoList = new List<FileInfo>();
            var FileList = Directory.EnumerateFiles(S);
            foreach(var s in FileList)
            {
                IParser parser;
                FileInfo f = null;
                if(vocabulary.TryGetValue(Path.GetExtension(s), out parser))
                    fileInfoList.Add(parser.Parse(s));
                else
                    Console.WriteLine("Parser for {0} not found",Path.GetFileName(s));
            }         
            return fileInfoList ;      
        }
        public void Search(List<FileInfo> fileinfo, string lineintext)
        {
            foreach(var s in fileinfo)
            {
                string newstring = string.Join(" ",s.Header,s.Body,s.Signature);
                if (newstring.Contains(lineintext))
                    Console.WriteLine(s.ToString());
            }
        }
        static FileInfo Parsehtml(string path) 
        {
            return new FileInfo();
        }
    }
    interface IParser
    {
        FileInfo Parse(string path);
    }
    class TxtParser : IParser
    {
        public FileInfo Parse(string path)
        {
            using (StreamReader strmrdr = new StreamReader(path))
            {

                string filetext = strmrdr.ReadToEnd();
                string[] split = filetext.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);

                return new FileInfo()
                {

                    Header = split[0],
                    Body = split[1],
                    Signature = split[2]
                };

            }
        }
    }
    class HtmlParser : IParser
    {

        public FileInfo Parse(string path)
        {
            using (StreamReader strmrdr = new StreamReader(path))
            {
                FileInfo f = new FileInfo();
                string filetext = " ";
                string[] split;
                while (filetext != null)
                {
                    filetext = strmrdr.ReadLine();
                    if (filetext.Contains("<title>") && filetext.Contains("</title>"))
                    {
                        split = filetext.Split(new string[] { "<title>", "</title>" }, StringSplitOptions.RemoveEmptyEntries);
                        f.Header = split[1];
                    }
                    if (filetext.Contains("<body>"))
                        f.Body = strmrdr.ReadLine();

                    if (filetext.Contains("<div class=\"signature\">") && (filetext.Contains("</div>")))
                    {
                        split = filetext.Split(new string[] { "<div class=\"signature\">", "</div>" }, StringSplitOptions.RemoveEmptyEntries);
                        f.Signature = split[0];
                        filetext = null;
                    }
                }
                return f;
            }
            throw new  NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Files f = new Files(@"C:\Users\user\Desktop\A");
            List<FileInfo> fileinfo = f.GetInfoFiles();
            f.Search(fileinfo,"First");
            
        }
    }
}
