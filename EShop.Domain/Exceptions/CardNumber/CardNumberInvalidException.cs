namespace EShop.Domain.Exceptions.CardNumber;

public class CardNumberInvalidException : Exception
{

    public CardNumberInvalidException() : base("ERROR 406, wydawca karty jest nieobsługiwany")
    { }

    public CardNumberInvalidException(Exception innerException) : base("ERROR 406, wydawca karty jest nieobsługiwany", innerException)
    { }
}