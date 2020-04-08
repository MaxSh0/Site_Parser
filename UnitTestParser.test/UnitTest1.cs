using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserLibrary;
namespace UnitTestParser.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void HeadlineTest()
        {
            //Строка которая должна быть на выходе
            string CorrectTitle = "Нет никого, кто любил бы боль саму по себе, кто искал бы её и кто хотел бы иметь её просто потому, что это боль..";
            //Парсим сайт
            ParserHeadline parser = new ParserHeadline();
            string result = parser.ParseText("https://ru.lipsum.com/");
            //Проверяем входит ли наша подстрока в строку
            Assert.AreEqual(true, result.Contains(CorrectTitle));
        }



    }
}
