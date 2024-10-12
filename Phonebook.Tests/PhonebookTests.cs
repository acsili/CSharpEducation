using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook.Tests
{
  [TestFixture]
  public class PhonebookTests
  {
    private Phonebook phonebook;
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
      phonebook = new Phonebook();
    }

    [TearDown]
    public void TearDown()
    {
      phonebook.ClearPhonebookList();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
      phonebook = null;
    }

    [Test]
    public void AddSubscriber_ShouldAddSubscriber()
    {
      // Arrange
      var subscriber = new Subscriber(Guid.NewGuid(), "test name", 
        new List<PhoneNumber>());

      // Act
      phonebook.AddSubscriber(subscriber);

      // Assert
      var result = phonebook.GetSubscriber(subscriber.Id);
      Assert.That(result, Is.EqualTo(subscriber));
    }

    [Test]
    public void AddSubscriber_ShouldThrowException_WhenIdEmptyExists()
    {
      // Arrange
      var subscriber = new Subscriber(Guid.Empty, "test name",
        new List<PhoneNumber>() { new PhoneNumber("+1 (123) 452-7892",
        PhoneNumberType.Personal) });

      // Assert
      Assert.Throws<ArgumentNullException>(() => phonebook.AddSubscriber(subscriber));
    }

    [Test]
    public void AddSubscriber_ShouldThrowException_WhenSubscriberAlreadyExists()
    {
      // Arrange
      var subscriber = new Subscriber(Guid.NewGuid(), "test name",
        new List<PhoneNumber>());

      // Act
      phonebook.AddSubscriber(subscriber);

      // Assert
      Assert.Throws<InvalidOperationException>(() => phonebook.AddSubscriber(subscriber));
    }

    [Test]
    public void GetSubscriber_ShouldReturnSubscriber_WhenExists()
    {
      // Arrange
      var subscriber = new Subscriber(Guid.NewGuid(), "test name",
        new List<PhoneNumber>());

      // Act
      phonebook.AddSubscriber(subscriber);
      var result = phonebook.GetSubscriber(subscriber.Id);

      // Assert
      Assert.That(result, Is.EqualTo(subscriber));
    }

    [Test]
    public void GetSubscriber_ShouldThrowException_WhenSubscriberNotExists()
    {
      // Arrange
      var subscriber = new Subscriber(Guid.NewGuid(), "test name",
        new List<PhoneNumber>());
      var newId = Guid.NewGuid();

      // Act
      phonebook.AddSubscriber(subscriber);

      // Assert
      Assert.Throws<ArgumentNullException>(() => phonebook.GetSubscriber(newId));
    }

    [Test]
    public void DeleteSubscriber_ShouldRemoveSubscriber()
    {
      // Arrange
      var subscriber = new Subscriber(Guid.NewGuid(), "test name",
        new List<PhoneNumber>() { new PhoneNumber("+1 (123) 452-7292",
        PhoneNumberType.Personal) });

      // Act
      phonebook.AddSubscriber(subscriber);
      phonebook.DeleteSubscriber(subscriber);

      // Assert
      Assert.Throws<ArgumentNullException>(() => phonebook.GetSubscriber(subscriber.Id));
    }

    [Test]
    public void RenameSubscriber_ShouldChangeName()
    {
      // Arrange
      var subscriber = new Subscriber(Guid.NewGuid(), "test name",
        new List<PhoneNumber>() { new PhoneNumber("+1 (123) 452-1292",
        PhoneNumberType.Personal) });
      string newName = "new test name";

      // Act
      phonebook.AddSubscriber(subscriber);
      phonebook.RenameSubscriber(subscriber, newName);
      var updatedSubscriber = phonebook.GetSubscriber(subscriber.Id);

      // Assert
      Assert.That(updatedSubscriber.Name, Is.EqualTo(newName));
    }

    [Test]
    public void AddNumberToSubscriber_ShouldAddPhoneNumber()
    {
      // Arrange
      var subscriber = new Subscriber(Guid.NewGuid(), "test name",
        new List<PhoneNumber>() { new PhoneNumber("+1 (123) 452-1292",
        PhoneNumberType.Personal) });
      var phoneNumber = new PhoneNumber("+7 (123) 452-1292", PhoneNumberType.Personal);

      // Act
      phonebook.AddSubscriber(subscriber);
      phonebook.AddNumberToSubscriber(subscriber, phoneNumber);
      var updatedSubscriber = phonebook.GetSubscriber(subscriber.Id);

      // Assert
      Assert.That(updatedSubscriber.PhoneNumbers.ToList(), Does.Contain(phoneNumber));
    }

    [Test]
    public void UpdateSubscriber_ShouldUpdateDetails()
    {
      // Arrange
      var subscriber = new Subscriber(Guid.NewGuid(), "test name",
        new List<PhoneNumber>() { new PhoneNumber("+1 (173) 452-1292",
        PhoneNumberType.Personal) });
      var newPhoneNumber = new PhoneNumber("+2 (173) 452-1292", PhoneNumberType.Personal);
      var updatedSubscriber = new Subscriber(subscriber.Id, "updated Name", new List<PhoneNumber> { newPhoneNumber });

      // Act
      phonebook.AddSubscriber(subscriber);
      phonebook.UpdateSubscriber(subscriber, updatedSubscriber);
      var result = phonebook.GetSubscriber(subscriber.Id);

      // Assert
      Assert.Multiple(() =>
      {
        Assert.That(result.Name, Is.EqualTo(updatedSubscriber.Name));
        Assert.That(result.PhoneNumbers.ToList(), Does.Contain(newPhoneNumber));
      });
    }

    [Test]
    public void GetAll_ShouldReturnAllSubscribers()
    {
      // Arrange
      var subscriber = new Subscriber(Guid.NewGuid(), "test name",
        new List<PhoneNumber>() { new PhoneNumber("+2 (173) 452-1292",
        PhoneNumberType.Personal) });
      var secondSubscriber = new Subscriber(Guid.NewGuid(), "second test name", 
        new List<PhoneNumber>() { new PhoneNumber("+1 (673) 452-1212",
        PhoneNumberType.Personal)});

      // Act
      phonebook.AddSubscriber(subscriber);
      phonebook.AddSubscriber(secondSubscriber);
      var allSubscribers = phonebook.GetAll();

      // Assert
      Assert.Multiple(() =>
      {
        Assert.That(allSubscribers.Count(), Is.EqualTo(2));
        Assert.That(allSubscribers.ToList(), Does.Contain(subscriber));
        Assert.That(allSubscribers.ToList(), Does.Contain(secondSubscriber));
      });
      
    }
  }
}