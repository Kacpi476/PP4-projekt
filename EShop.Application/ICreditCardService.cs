namespace EShop.Application;

public interface ICreditCardService
{
    public bool ValidateCardNumber(string cardNumber);

    public string GetCardType(string cardNumber);
}