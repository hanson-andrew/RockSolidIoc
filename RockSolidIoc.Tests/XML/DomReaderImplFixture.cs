using Microsoft.VisualStudio.TestTools.UnitTesting;

using JordansLibrary.Xml;

namespace JordansLibrary.Tests.Xml
{

  [TestClass()]
  public class DomReaderImplFixture
  {

    private string _xmlToParse = @"<?xml version=""1.0"" encoding=""UTF-8""?><root><element1></element1><element2 /><element3 attr1=""val1"">Test</element3></root>";

    [TestMethod()]
    public void TestParse()
    {
      System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
      memoryStream.Write(new System.Text.UTF8Encoding().GetBytes(_xmlToParse), 0, _xmlToParse.Length);
      memoryStream.Position = 0;

      DomReaderImpl domReaderImpl = new DomReaderImpl();
      Document document = domReaderImpl.Parse(new System.IO.StreamReader(memoryStream));

      Assert.AreEqual(document.RootNode.LocalName, "root");
      Assert.AreEqual(document.RootNode.ChildElements[0].LocalName, "element1");
      Assert.AreEqual(document.RootNode.ChildElements[1].LocalName, "element2");
      Assert.AreEqual(document.RootNode.ChildElements[2].LocalName, "element3");
      Assert.AreEqual(document.RootNode.ChildElements[2].Attributes.Count, 1);
    }

  }

}