using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Phonebook.Tests
{
  [TestFixture]
  public class PhoneNumberValidatorTests
  {

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
    }

    [Test]
    [TestCase("+1 (123) 456-7890", PhoneNumberType.Personal)]
    [TestCase("+44 (204) 794-0958", PhoneNumberType.Work)]
    [TestCase("+7 (495) 123-4567", PhoneNumberType.Personal)]
    public void Validate_ValidPhoneNumbers_ShouldNotThrowException(string number, PhoneNumberType type)
    {
      // Arrange
      var phoneNumber = new PhoneNumber(number, type);

      // Act 
      void result() => PhoneNumberValidator.Validate(phoneNumber);

      // Assert
      Assert.DoesNotThrow(result);
    }

    [Test]
    [TestCase("1234567890", PhoneNumberType.Personal)]
    [TestCase("+1 123 456 7890", PhoneNumberType.Work)]
    [TestCase("+1 (123) 456-78", PhoneNumberType.Personal)]
    [TestCase("+1 (123) 456-78901", PhoneNumberType.Personal)]
    public void Validate_InvalidPhoneNumbers_ShouldThrowException(string number, PhoneNumberType type)
    {
      // Arrange
      var phoneNumber = new PhoneNumber(number, type);

      // Act 
      void result() => PhoneNumberValidator.Validate(phoneNumber);

      // Assert
      Assert.Throws<ArgumentException>(result);
    }

    [Test]
    public void ValidateList_ValidPhoneNumbers_ShouldNotThrowException()
    {
      // Arrange
      var validNumbers = new List<PhoneNumber>
      {
        new PhoneNumber("+1 (123) 456-7890", PhoneNumberType.Personal),
        new PhoneNumber("+44 (204) 794-0958", PhoneNumberType.Work),
        new PhoneNumber("+7 (495) 123-4567", PhoneNumberType.Personal)
      };

      // Assert
      Assert.DoesNotThrow(() => PhoneNumberValidator.ValidateList(validNumbers));
    }

    [Test]
    public void ValidateList_InvalidPhoneNumbers_ShouldThrowException()
    {
      //  Arrange
      var invalidNumbers = new List<PhoneNumber>
      {
        new PhoneNumber("1234567890", PhoneNumberType.Work),
        new PhoneNumber("+1 123 456 7890", PhoneNumberType.Personal),
        new PhoneNumber("+1 (123) 456-78", PhoneNumberType.Work),
        new PhoneNumber("+1 (123) 456-78901", PhoneNumberType.Personal)
      };

      // Assert
      Assert.Throws<ArgumentException>(() => PhoneNumberValidator.ValidateList(invalidNumbers));
    }
  }
}
