using Crypto1;

namespace Crypto1Tests;

[TestClass]
public class CesarApply
{
    [DataTestMethod]
    [DataRow("a",0)]
    [DataRow("agfzeazg",0)]
    public void Cesar_ApplyWithShift0_ReturnsSameString(string clearMessage, int shiftRightToApply)
    {
        clearMessage = StringHelper.NormalizeString(clearMessage);
        var actualCryptedMessage = CesarShift.Apply(clearMessage, shiftRightToApply);
        Assert.AreEqual(clearMessage, actualCryptedMessage);
    }
    
    [DataTestMethod]
    [DataRow("a",1,"b")]
    [DataRow("Bonjour",2,"dqplqwt")]
    [DataRow("Nez",2,"pgb")]
    public void Cesar_Apply_ReturnsCorrectString(string clearMessage, int shiftRightToApply, string expectedCryptedMessage)
    {
        clearMessage = StringHelper.NormalizeString(clearMessage);
        expectedCryptedMessage = StringHelper.NormalizeString(expectedCryptedMessage);

        var actualCryptedMessage = CesarShift.Apply(clearMessage, shiftRightToApply);
        Assert.AreEqual(expectedCryptedMessage, actualCryptedMessage);
    }
}