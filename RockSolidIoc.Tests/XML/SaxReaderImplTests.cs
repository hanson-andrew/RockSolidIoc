using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using JordansLibrary.Xml;

namespace Xml
{

  [TestClass()]
  public class SaxReaderImplTests
  {

    [TestMethod()]
    public void ParseTests()
    {
      var saxHandler = new Mock<ISaxHandler>();
      SaxReaderImpl saxReader = new SaxReaderImpl();
      using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
      {
        using (System.IO.StreamReader reader = new System.IO.StreamReader(ms))
        {
          saxReader.Parse(reader, saxHandler as ISaxHandler);
        }
      }
      saxHandler.Verify(c => c.StartDocument());
    }
  }

}