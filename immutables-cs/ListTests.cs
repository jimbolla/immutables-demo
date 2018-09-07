using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace immutables_cs
{
  public class ListTests
  {
    [Fact]
    public void AddingElements_Mutable()
    {
      var original = new List<string>() { "a", "b" };
      original.Add("c");

      original.Should().Equal("a", "b", "c");
    }

    [Fact]
    public void AddingElements_Immutable_Using_List()
    {
      var original = new List<string> { "a", "b" };
      var copy = original.Concat(new[] { "c" }).ToList();

      original.Should().Equal("a", "b");
      copy.Should().Equal("a", "b", "c");
    }

    [Fact]
    public void AddingElements_Immutable_Using_ImmutableList()
    {
      var original = ImmutableList.Create<string>("a", "b");
      var copy = original.Add("c");

      original.Should().Equal("a", "b");
      copy.Should().Equal("a", "b", "c");
    }

    [Fact]
    public void RemovingElements_Mutable()
    {
      var original = new List<string> { "a", "b", "c", "d", "e", "f", "g" };
      original.RemoveRange(3, 2);

      original.Should().Equal("a", "b", "c", "f", "g");
    }

    [Fact]
    public void RemovingElements_Immutable_Using_List()
    {
      var original = new List<string> { "a", "b", "c", "d", "e", "f", "g" };
      var copy = new List<string>(original);
      copy.RemoveRange(3, 2);

      original.Should().Equal("a", "b", "c", "d", "e", "f", "g");
      copy.Should().Equal("a", "b", "c", "f", "g");
    }

    [Fact]
    public void RemovingElements_Immutable_Using_ImmutableList()
    {
      var original = ImmutableList.Create<string>("a", "b", "c", "d", "e", "f", "g");
      var copy = original.RemoveRange(3, 2);

      original.Should().Equal("a", "b", "c", "d", "e", "f", "g");
      copy.Should().Equal("a", "b", "c", "f", "g");
    }
  }
}
