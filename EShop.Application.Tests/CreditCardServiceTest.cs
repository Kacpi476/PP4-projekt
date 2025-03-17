using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Tests
{
    public class CreditCardServiceTest
    {
        [Fact]
        public void CreditCard_LenOptimal_IsTooShort()
        {
            // arrange
            var creditCardService = new CreditCardService();

            string cardNumber = "1111";

            //act & assert
            
            Assert.Throws<CardNumberTooShortException>(() => creditCardService.ValidateCardNumber(cardNumber));

            
        }
        [Fact]
        public void CreditCard_LenOptimal_IsTooLong()
        {
            // arrange
            var creditCardService = new CreditCardService();

            string cardNumber = "12345678910111213141516";

            //act

            var result = creditCardService.ValidateCardNumber(cardNumber);

            //assert

            Assert.False(result);
        }
        [Fact]
        public void CreditCard_LenOptimal_IsInRange()
        {
            // arrange
            var creditCardService = new CreditCardService();

            string cardNumber = "371749049767380";

            //act

            bool result = creditCardService.ValidateCardNumber(cardNumber);

            //assert

            Assert.True(result);
        }
        [Fact]
        public void CreditCard_MasterCard_IsTrue()
        {
            // arrange
            var creditCardService = new CreditCardService();

            string cardNumber = "5555 5555 5555 4444";

            //act

            var result = creditCardService.GetCardType(cardNumber);

            //assert

            Assert.Equal("MasterCard",result);
        }

        [Theory]
        [InlineData("American Express", "3497 7965 8312 797")]
        [InlineData("American Express", "345-470-784-783-010")]
        [InlineData("American Express", "378523393817437")]
        [InlineData("Visa", "4024-0071-6540-1778")]
        [InlineData("Visa", "4532 2080 2150 4434")]
        [InlineData("Visa", "4532289052809181")]
        [InlineData("MasterCard", "5530016454538418")]
        [InlineData("MasterCard", "5551561443896215")]
        [InlineData("MasterCard", "5131208517986691")]

        public void GetCardType_ShouldReturnCorrectResult(string expectedResult, string cardNumber)
        {
            var creditCardService = new CreditCardService();
            var result = creditCardService.GetCardType(cardNumber);
            Assert.Equal(expectedResult, result);
        }
            
    }


}