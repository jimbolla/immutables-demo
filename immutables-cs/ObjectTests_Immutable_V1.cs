using System;
using Xunit;
using FluentAssertions;

namespace immutables_cs
{
  public class ObjectTests_Immutable_V1
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


      var copy = new Address(
        street1: original.Street1,
        street2: original.Street2,
        city: "Pittsburgh",
        state: original.State,
        zipCode: original.ZipCode
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
  }
}
