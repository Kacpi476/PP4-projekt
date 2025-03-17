namespace EShop.Domain.Exceptions.CardNumber;

public class CardNumberTooLongException : Exception
{
    public CardNumberTooLongException() : base("ERROR 414,numer karty za długi") { }

    public CardNumberTooLongException(Exception innerException) : base("ERROR 414,numer karty za długi", innerException) { }
}