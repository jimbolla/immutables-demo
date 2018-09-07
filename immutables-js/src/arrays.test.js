describe("arrays", () => {
  describe("adding elements", () => {
    test("mutable", () => {
      var original = ["a", "b"];
      var length = original.push("c");

      expect(original).toEqual(["a", "b", "c"]);
      expect(length).toEqual(3);
    });

    test("mutable (frozen)", () => {
      var original = ["a", "b"];
      Object.freeze(original);

      expect(() => {
        original.push("c");
      }).toThrowError("Cannot add property 2, object is not extensible");
    });

    test("immutable (ES5)", () => {
      var original = ["a", "b"];
      var copy = original.concat("c");

      expect(original).toEqual(["a", "b"]);
      expect(copy).toEqual(["a", "b", "c"]);
    });

    test("immutable (ES2015)", () => {
      var original = ["a", "b"];
      var copy = [...original, "c"];

      expect(original).toEqual(["a", "b"]);
      expect(copy).toEqual(["a", "b", "c"]);
    });
  });

  describe("removing elements", () => {
    test("mutable", () => {
      var original = ["a", "b", "c", "d", "e", "f", "g"];
      var deleted = original.splice(3, 2);

      expect(original).toEqual(["a", "b", "c", "f", "g"]);
      expect(deleted).toEqual(["d", "e"]);
    });

    test("immutable (ES5)", () => {
      var original = ["a", "b", "c", "d", "e", "f", "g"];
      var outer = original.slice(0, 3).concat(original.slice(5));
      var inner = original.slice(3, 5);

      expect(original).toEqual(["a", "b", "c", "d", "e", "f", "g"]);
      expect(outer).toEqual(["a", "b", "c", "f", "g"]);
      expect(inner).toEqual(["d", "e"]);
    });
  });
});
