using System;
using Xunit;
using FluentAssertions;

namespace immutables_cs
{
  public class ObjectTests_Immutable_V2
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
        string street1 = null,
        string street2 = null,
        string city = null,
        string state = null,
        string zipCode = null
      )
      {
        return new Address(
          street1 ?? Street1,
          street2 ?? Street2,
          city ?? City,
          state ?? State,
          zipCode ?? ZipCode
        );
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
        Street2 = "Apt B", // <--------            Unexpected. Why not null?!?!
        City = "Pittsburgh",
        State = "PA",
        ZipCode = "15106",
      });
    }

  }
}
