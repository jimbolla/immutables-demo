describe("objects", () => {
  describe("changing a property", () => {
    test("mutable", () => {
      var original = {
        street1: "123 Fake St.",
        street2: null,
        city: "Pittsburg",
        state: "PA",
        zipCode: "15106"
      };

      original.city = "Pittsburgh";

      expect(original).toEqual({
        street1: "123 Fake St.",
        street2: null,
        city: "Pittsburgh",
        state: "PA",
        zipCode: "15106"
      });
    });

    test("mutable (frozen)", () => {
      var original = {
        street1: "123 Fake St.",
        street2: null,
        city: "Pittsburg",
        state: "PA",
        zipCode: "15106"
      };

      Object.freeze(original);

      expect(() => {
        original.city = "Pittsburgh";
      }).toThrowError(/Cannot assign to read only property 'city'/);
    });

    test("immutable (ES5)", () => {
      var original = {
        street1: "123 Fake St.",
        street2: null,
        city: "Pittsburg",
        state: "PA",
        zipCode: "15106"
      };

      var copy = Object.assign({}, original, { city: "Pittsburgh" });

      expect(original).toEqual({
        street1: "123 Fake St.",
        street2: null,
        city: "Pittsburg",
        state: "PA",
        zipCode: "15106"
      });

      expect(copy).toEqual({
        street1: "123 Fake St.",
        street2: null,
        city: "Pittsburgh",
        state: "PA",
        zipCode: "15106"
      });
    });

    test("immutable (ES2015)", () => {
      var original = {
        street1: "123 Fake St.",
        street2: null,
        city: "Pittsburg",
        state: "PA",
        zipCode: "15106"
      };

      var copy = { ...original, city: "Pittsburgh" };

      expect(original).toEqual({
        street1: "123 Fake St.",
        street2: null,
        city: "Pittsburg",
        state: "PA",
        zipCode: "15106"
      });

      expect(copy).toEqual({
        street1: "123 Fake St.",
        street2: null,
        city: "Pittsburgh",
        state: "PA",
        zipCode: "15106"
      });
    });
  });
});
