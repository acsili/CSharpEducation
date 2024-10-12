using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Phonebook.Tests
{
  [TestFixture]
  public class PhoneNumberValidatorTests
  {
    private List<PhoneNumber> validNumbers;
    private List<PhoneNumber> invalidNumbers;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
      validNumbers = new List<PhoneNumber>
      {
        new PhoneNumber("+1 (123) 456-7890", PhoneNumberType.Personal),
        new PhoneNumber("+44 (204) 794-0958", PhoneNumberType.Work),
        new PhoneNumber("+7 (495) 123-4567", PhoneNumberType.Personal)
      };

      invalidNumbers = new List<PhoneNumber>
      {
        new PhoneNumber("1234567890", PhoneNumberType.Work),
        new PhoneNumber("+1 123 456 7890", PhoneNumberType.Personal),
        new PhoneNumber("+1 (123) 456-78", PhoneNumberType.Work),
        new PhoneNumber("+1 (123) 456-78901", PhoneNumberType.Personal)
      };
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
      validNumbers = null;
      invalidNumbers = null;
    }

    [Test]
    public void Validate_ValidPhoneNumbers_ShouldNotThrowException()
    {
      // Assert
      foreach (var number in validNumbers)
      {
        Assert.DoesNotThrow(() => PhoneNumberValidator.Validate(number));
      }
    }

    [Test]
    public void Validate_InvalidPhoneNumbers_ShouldThrowException()
    {
      // Assert
      foreach (var number in invalidNumbers)
      {
        Assert.Throws<ArgumentException>(() => PhoneNumberValidator.Validate(number));
      }
    }

    [Test]
    public void ValidateList_ValidPhoneNumbers_ShouldNotThrowException()
    {
      // Assert
      Assert.DoesNotThrow(() => PhoneNumberValidator.ValidateList(validNumbers));
    }

    [Test]
    public void ValidateList_InvalidPhoneNumbers_ShouldThrowException()
    {
      //  Arrange
      var mixedNumbers = new List<PhoneNumber>(validNumbers);

      // Act
      mixedNumbers.AddRange(invalidNumbers);

      // Assert
      Assert.Throws<ArgumentException>(() => PhoneNumberValidator.ValidateList(mixedNumbers));
    }
  }
}
