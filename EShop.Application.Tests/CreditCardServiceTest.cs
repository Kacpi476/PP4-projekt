using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Tests
{
    public class CreditCardServiceTest
    {
        [Fact]
        public void CreditCard_LenOptimal_IsTooShort()
        {
            // arrange
            var CreditCardService = new CreditCardService();

            string cardNumber = "1111";

            //act

            var result = CreditCardService.ValidateCardNumber(cardNumber);

            //assert

            Assert.False(result);
        }
        [Fact]
        public void CreditCard_LenOptimal_IsTooLong()
        {
            // arrange
            var CreditCardService = new CreditCardService();

            string cardNumber = "12345678910111213141516";

            //act

            var result = CreditCardService.ValidateCardNumber(cardNumber);

            //assert

            Assert.False(result);
        }
        [Fact]
        public void CreditCard_LenOptimal_IsInRange()
        {
            // arrange
            var CreditCardService = new CreditCardService();

            string cardNumber = "371749049767380";

            //act

            bool result = CreditCardService.ValidateCardNumber(cardNumber);

            //assert

            Assert.True(result);
        }
        [Fact]
        public void CreditCard_MasterCard_IsTrue()
        {
            // arrange
            var CreditCardService = new CreditCardService();

            string cardNumber = "2557007014243297";

            //act

            var result = Application.CreditCardService.GetCardType(cardNumber);

            //assert

            Assert.Equal("MasterCard",result);
        }
    }


}