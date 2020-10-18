using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Library.Tests
{
    [TestFixture]
    class ShoppingBasketItemArgumentTest
    {
        [Test]
        public void WhenWrongQuantity_ExpectedThrowException()
        {
            string paramName = "quantity";

            Assert.Throws(
                Is.TypeOf<ArgumentOutOfRangeException>()
                .And.Property("ParamName")
                .EqualTo(paramName),
                () => new Item(0, "Butter", 0.80));
        }

        [Test]
        public void WhenWrongPrice_ExpectedThrowException()
        {
            string paramName = "price";

            Assert.Throws(
                Is.TypeOf<ArgumentOutOfRangeException>()
                .And.Property("ParamName")
                .EqualTo(paramName),
                () => new Item(1, "Butter", 0.0));
        }
    }
}
