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
            //������ ������� ������ ���� �� ������
            string CorrectTitle = "��� ������, ��� ����� �� ���� ���� �� ����, ��� ����� �� � � ��� ����� �� ����� � ������ ������, ��� ��� ����..";
            //������ ����
            ParserHeadline parser = new ParserHeadline();
            string result = parser.ParseText("https://ru.lipsum.com/");
            //��������� ������ �� ���� ��������� � ������
            Assert.AreEqual(true, result.Contains(CorrectTitle));
        }



    }
}
