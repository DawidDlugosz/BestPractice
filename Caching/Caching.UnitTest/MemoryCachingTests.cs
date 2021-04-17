using System;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using NUnit.Framework;

namespace Caching.UnitTest
{
    public class MemoryCachingTests
    {
        [SetUp]
        public void Setup()
        {}

        [Test]
        public void AddOrExecute_SHOULD_return_proper_value()
        {
            //Arrange
            var keyName = "GetDateTime";
            var expectedValue = new DateTime(2020, 01, 02);
            Func<DateTime> methodToExecute = () => expectedValue;
            var cache = new MemoryCache();

            //Act
            var executionResult = cache.AddOrExecute<DateTime>(keyName, methodToExecute);

            //Assert
            executionResult.Should().Be(expectedValue);
        }
    }
}