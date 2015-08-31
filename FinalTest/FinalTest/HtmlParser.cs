using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest
{
    class HtmlParser : IParser
    {
        public Product Parse(string path)
        {
            Product product = new Product();
            product.FileName = Path.GetFileName(path);
            HtmlDocument html = new HtmlDocument();
            html.Load(path,true);
            try
            {
                product.ProductType = html.DocumentNode.SelectSingleNode("//h3")
                    .InnerText.Contains("Кофемолки") ? "Coffee Blender" : "Phone";
                product.Name = html.DocumentNode.SelectSingleNode("//h3")
                    .InnerText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ElementAt(1).Trim();
                var tblDescription = html.DocumentNode
                   .SelectSingleNode("//table[@id='descr_short']");
                var types = tblDescription.SelectNodes("./tr/td[@class='first']").Select(td => td.InnerText.Trim()).ToArray();
                var values = tblDescription.SelectNodes("./tr/td/b").Select(b => b.InnerText.Trim()).ToArray();
                for(int count = 0; count < types.Length; count++)
                    product.Characteristics += string.Format("{0}: {1}\n", types[count], values[count]);               
            }
            catch (Exception ex) { throw new Exception("Error during parsing file " + path, ex); }
            return product;
        }
    }
}
