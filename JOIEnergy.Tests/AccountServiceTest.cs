using JOIEnergy.Enums;
using JOIEnergy.Services;
using JOIEnergy.Services.Interface;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace JOIEnergy.Tests
{
    public class AccountServiceTest
    {
        private const Supplier PRICE_PLAN_ID = Supplier.PowerForEveryone;
        private const String SMART_METER_ID = "smart-meter-id";

        private AccountService accountService;

        public AccountServiceTest()
        {
            //Arrange
            Dictionary<String, Supplier> smartMeterToPricePlanAccounts = new Dictionary<string, Supplier>();
            smartMeterToPricePlanAccounts.Add(SMART_METER_ID, PRICE_PLAN_ID);
            accountService = new AccountService(smartMeterToPricePlanAccounts);
        }

        [Theory]
        [InlineData("smart-meter-id")]
        public void Account_GetPricePlanIdForSmartMeterId_ReturnExpectedValue(string smartId)
        {
            //act
            var result = accountService.GetPricePlanIdForSmartMeterId(smartId);

            //Assert
            Assert.Equal(Supplier.PowerForEveryone, result);
        }
        
        [Theory]
        [InlineData("bob-carolgees")]
        public void Account_GetPricePlanIdForSmartMeterId_ReturnNullValue(string smartId)
        {
            //Arrange
            var excepted = Supplier.NullSupplier;

            //act
            var result = accountService.GetPricePlanIdForSmartMeterId(smartId);

            //Assert
            Assert.Equal(excepted, result);
        }

        [Theory]
        [InlineData("smart-meter-id")]
        public void Account_GetPricePlanIdForSmartMeterId_ReturnTheGreenEco(string smartId)
        {
            //Arrange            
            var excepted = Supplier.PowerForEveryone;

            var mockSupplier = new Mock<IAccountService>();
            mockSupplier.Setup(c => c.GetPricePlanIdForSmartMeterId(smartId)).Returns(Supplier.PowerForEveryone);

            //act
            var result = mockSupplier.Object.GetPricePlanIdForSmartMeterId(smartId);

            //Assert
            Assert.Equal(excepted, result);
        }
    }
}