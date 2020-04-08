using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace ParserLibrary
{
    public class ParserHeadline
    {

        public string text;
        /// <summary>
        /// Получает HTML прездставление страницы сайта и выводит в консоль заголовки
        /// </summary>
        /// <param name="HTMLparse"></param>
        public void Parse(string HTMLparse)
        {
            string line = " ";

            //Регулярное выражение которое находит заголовки
            Regex regexp_paragraph = new Regex(@"<h\d>.*?<\/h\d>");

            //Выполняем запрос к ресурсу и считываем его HTTP кодировку
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HTMLparse);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Открываем поток для считывания данных
            Stream data = response.GetResponseStream();
            //Считываем данные с потока
            StreamReader reader = new StreamReader(data, Encoding.UTF8);


            while (line != null)
            {
                line = reader.ReadLine(); //считываем данные посточно
                if (line != null)
                {
                    MatchCollection matches = regexp_paragraph.Matches(line);//проверяем на совпадения с регулярным выражением
                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            //Если совпало выводим строку на экран и записываем в массив
                            Console.WriteLine(match.Value);
                            text = text + " " + match.Value;
                        }
                    }
                }
            }

            //Закрываем потоки
            data.Close();
            reader.Close();

            Console.ReadKey();
        }

        /// <summary>
        /// Получает HTML прездставление страницы сайта и возвращает заголовки
        /// </summary>
        /// <param name="HTMLparse"></param>
        /// <returns>Строка в которой все заголовки сайта</returns>
        public string ParseText(string HTMLparse)
        {
            string line = " ";

            //Регулярное выражение которое находит заголовки
            Regex regexp_paragraph = new Regex(@"<h\d>.*?<\/h\d>");

            //Выполняем запрос к ресурсу и считываем его HTTP кодировку
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HTMLparse);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Открываем поток для считывания данных
            Stream data = response.GetResponseStream();
            //Считываем данные с потока
            StreamReader reader = new StreamReader(data, Encoding.UTF8);


            while (line != null)
            {
                line = reader.ReadLine(); //считываем данные посточно
                if (line != null)
                {
                    MatchCollection matches = regexp_paragraph.Matches(line);//проверяем на совпадения с регулярным выражением
                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            //Если совпало записываем в строку
                            text = text + " " + match.Value;
                        }
                    }
                }
            }

            //Закрываем потоки
            data.Close();
            reader.Close();
            return text;
        }
    }
}
