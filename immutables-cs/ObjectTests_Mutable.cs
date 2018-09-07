using System;
using Xunit;
using FluentAssertions;

namespace immutables_cs
{
  public class ObjectTests_Mutable
  {
    private class Address
    {
      public string Street1 { get; set; }
      public string Street2 { get; set; }
      public string City { get; set; }
      public string State { get; set; }
      public string ZipCode { get; set; }
    }

    [Fact]
    public void ChangingAProperty()
    {
      var original = new Address
      {
        Street1 = "123 Fake St.",
        Street2 = "Apt B",
        City = "Pittsburg",
        State = "PA",
        ZipCode = "15106",
      };

      original.City = "Pittsburgh";

      original.Should().BeEquivalentTo(new
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