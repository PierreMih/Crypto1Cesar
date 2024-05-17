using Crypto1;

namespace Crypto1Tests;

[TestClass]
public class CesarRevert
{
    [DataTestMethod]
    [DataRow("Outil pour décoder/encoder avec le code César (ou chiffre de César), un chiffrement par décalage parmi les plus faciles et les plus connus qui utilise la substitution d'une lettre par une autre plus loin dans l'alphabet.")]
    public void Cesar_RevertCorrectText_ReturnsSameText(string clearMessage)
    {
        clearMessage = StringHelper.NormalizeString(clearMessage);
        
        var revertedMessages = CesarShift.Revert(clearMessage);
        Assert.IsTrue(revertedMessages.Any(message => message == clearMessage));
    }
    
    [DataTestMethod]
    [DataRow("Outil pour décoder/encoder avec le code César (ou chiffre de César), un chiffrement par décalage parmi les plus faciles et les plus connus qui utilise la substitution d'une lettre par une autre plus loin dans l'alphabet.")]
    public void Cesar_Revert_ReturnsCorrectString(string clearMessage)
    {
        clearMessage = StringHelper.NormalizeString(clearMessage);

        var cryptedMessage = CesarShift.Apply(clearMessage, 1);
        var revertedMessages = CesarShift.Revert(cryptedMessage);
        Assert.IsTrue(revertedMessages.Any(message => message == clearMessage));
    }
}