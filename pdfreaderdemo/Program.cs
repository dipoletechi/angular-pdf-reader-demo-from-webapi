using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfreaderdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PdfReader reader = new PdfReader(@"D:\WorkShop\Projects\MYOB\2.pdf");
                int intPageNum = reader.NumberOfPages;
                string[] words;
                string line;

                for (int i = 1; i <= intPageNum; i++)
                {
                    var text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());

                    words = text.Split('\n');

                    for (int j = 0, len = words.Length; j < len; j++)
                    {
                        line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j]));
                        Console.WriteLine(line);
                    }
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
                
            }
            
        }
    }
}
