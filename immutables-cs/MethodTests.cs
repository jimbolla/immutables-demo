using System;
using Xunit;
using FluentAssertions;

namespace immutables_cs
{
  public class MethodTests
  {
    [Fact]
    public void SimpleMethodVariables_Mutable()
    {
      var price = 250.0;
      price = price * 0.8;

      price.Should().Be(200.0);
    }

    [Fact]
    public void SimpleMethodVariables_Immutable()
    {
      var basePrice = 250.0;
      var salePrice = basePrice * 0.8;

      basePrice.Should().Be(250.0);
      salePrice.Should().Be(200.0);
    }

    [Fact]
    public void Loops_Mutable()
    {
      var sum = 0;
      for (var x = 1; x <= 10; x++)
      {
        sum += x;
      }

      sum.Should().Be(55);
    }

    [Fact]
    public void Loops_Immutable()
    {
      int GetSum(int min, int max)
      {
        if (min == max) return min;
        return min + GetSum(min + 1, max);
      }

      var sum = GetSum(1, 10);
      sum.Should().Be(55);
    }
  }
}
