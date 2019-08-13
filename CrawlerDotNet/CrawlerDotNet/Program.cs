using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
using System.IO;

namespace CrawlerDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            startCrowlerAsync();
            Console.ReadLine();
        }

        private static async Task startCrowlerAsync()
        {
            var url = "https://www.alura.com.br/cursos-online-programacao/dotnet";
            HttpClient httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var lista = new List<CrawlerDados>();

            var divs = htmlDoc.DocumentNode.Descendants("div").
                Where(node => node.GetAttributeValue("class", "").
                Equals("card-curso__info")).ToList();

            //foreach (var div in divs)
            //{
            //    var dados = new CrawlerDados
            //    {
            //        Nome = div.Descendants("span").FirstOrDefault().InnerText
            //    };
            //    lista.Add(dados);
            //    Console.WriteLine(dados);
            //}

            string path = @"c:\temp\MyTest.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (var div in divs)
                    {
                        var dados = new CrawlerDados
                        {
                            Nome = div.Descendants("span").FirstOrDefault().InnerText
                        };
                        sw.WriteLine(dados);
                    }

                }
            }
        }
    }
}
