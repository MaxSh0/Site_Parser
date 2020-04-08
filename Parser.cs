using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;


namespace Parser
{
    class Parser
    {

        public string[] text = new string[10000];
        public void Parse(string HTMLparse)
        {
            string line = "1";
            int i = 0;
            //Регулярное выражение которое находит заголовки
            Regex regexp_paragraph = new Regex(@"<h\d>.*?<\/h\d>");

            //Выполняем запрос к ресурсу и считываем его HTTP кодировку
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ru.lipsum.com/");
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
                            text[i] = match.Value;
                            i++;
                        }
                    }
                }
            }

            //Закрываем потоки
            data.Close();
            reader.Close();

            Console.ReadKey();
        }
    }
}
