using Microsoft.AspNetCore.Mvc;
using EShop.Application;
using EShop.Domain.Exceptions.CardNumber;

namespace EShopService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreditCardController : ControllerBase
{
    public readonly CreditCardService _creditCardService;

    public CreditCardController()
    {
        _creditCardService = new CreditCardService();
    }

    [HttpPost("validate/{cardNumber}")]
    public IActionResult ValidateCardNumber([FromRoute] string cardNumber)
    {
        try
        {
            bool isValid = _creditCardService.ValidateCardNumber(cardNumber);
            return Ok(new { Valid = isValid });
        }
        catch (CardNumberTooShortException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
        catch (CardNumberTooLongException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
        catch (CardNumberInvalidException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpPost("getCardType/{cardNumber}")]
    public IActionResult GetCardType([FromRoute] string cardNumber)
    {
        try
        {
            var cardType = _creditCardService.GetCardType(cardNumber);
            return Ok(new { CardType = cardType });
        }
        catch (CardNumberInvalidException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }


}