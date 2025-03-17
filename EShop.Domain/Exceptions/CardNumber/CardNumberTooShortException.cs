namespace EShop.Domain.Exceptions.CardNumber;

public class CardNumberTooShortException : Exception
{
    public CardNumberTooShortException() : base("ERROR 400, numer karty za krótki") { }

    public CardNumberTooShortException(Exception innerException) : base("ERROR 400, numer karty za krótki", innerException) { }
}