describe("methods", () => {
  describe("simple method variables", () => {
    test("mutable", () => {
      let price = 250.0;
      price = price * 0.8;

      expect(price).toEqual(200);
    });

    test("immutable", () => {
      const basePrice = 250.0;
      const salePrice = basePrice * 0.8;

      expect(basePrice).toEqual(250);
      expect(salePrice).toEqual(200);
    });
  });

  describe("loops", () => {
    test("mutable", () => {
      let sum = 0;

      for (let x = 1; x <= 10; x++) {
        sum += x;
      }

      expect(sum).toEqual(55);
    });

    test("immutable", () => {
      function getSum(min, max) {
        if (min === max) return min;

        return min + getSum(min + 1, max);
      }

      const sum = getSum(1, 10);
      expect(sum).toEqual(55);
    });
  });
});
