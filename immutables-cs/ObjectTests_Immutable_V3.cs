using System;
using Xunit;
using FluentAssertions;

namespace immutables_cs
{
  public class ObjectTests_Immutable_V3
  {
    private class Address
    {
      public Address(
        string street1,
        string street2,
        string city,
        string state,
        string zipCode
      )
      {
        Street1 = street1;
        Street2 = street2;
        City = city;
        State = state;
        ZipCode = zipCode;
      }

      public string Street1 { get; }
      public string Street2 { get; }
      public string City { get; }
      public string State { get; }
      public string ZipCode { get; }

      public Address With(
        Optional<string> street1 = new Optional<string>(),
        Optional<string> street2 = new Optional<string>(),
        Optional<string> city = new Optional<string>(),
        Optional<string> state = new Optional<string>(),
        Optional<string> zipCode = new Optional<string>()
      )
      {
        return new Address(
          street1.HasValue ? street1.Value : Street1,
          street2.HasValue ? street2.Value : Street2,
          city.HasValue ? city.Value : City,
          state.HasValue ? state.Value : State,
          zipCode.HasValue ? zipCode.Value : ZipCode
        );
      }
    }

    public struct Optional<T>
    {
      private readonly bool _hasValue;
      private readonly T _value;

      public Optional(T value)
      {
        _hasValue = true;
        _value = value;
      }

      public bool HasValue { get { return _hasValue; } }

      public T Value { get { return _value; } }

      public static implicit operator Optional<T>(T value)
      {
        return new Optional<T>(value);
      }
    }

    [Fact]
    public void ChangingAProperty()
    {
      var original = new Address(
        street1: "123 Fake St.",
        street2: "Apt B",
        city: "Pittsburg",
        state: "PA",
        zipCode: "15106"
      );


      var copy = original.With(
        city: "Pittsburgh"
      );


      original.Should().BeEquivalentTo(new
      {
        Street1 = "123 Fake St.",
        Street2 = "Apt B",
        City = "Pittsburg",
        State = "PA",
        ZipCode = "15106",
      });

      copy.Should().BeEquivalentTo(new
      {
        Street1 = "123 Fake St.",
        Street2 = "Apt B",
        City = "Pittsburgh",
        State = "PA",
        ZipCode = "15106",
      });
    }

    [Fact]
    public void ChangingAPropertyToNull()
    {
      var original = new Address(
        street1: "123 Fake St.",
        street2: "Apt B",
        city: "Pittsburgh",
        state: "PA",
        zipCode: "15106"
      );


      var copy = original.With(
        street1: "1000 Penn Ave",
        street2: null
      );


      copy.Should().BeEquivalentTo(new
      {
        Street1 = "1000 Penn Ave",
        Street2 = default(string),
        City = "Pittsburgh",
        State = "PA",
        ZipCode = "15106",
      });
    }
  }
}
