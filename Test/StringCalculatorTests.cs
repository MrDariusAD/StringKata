using System;
using FluentAssertions;
using Xunit;

namespace Test {
    public class StringCalculatorTests {

        // ZuTestendeMethode_Testfallbeschreibung_Ergebnis
        [Fact]
        public void Add_Leerstring_wird_übergeben_0_ist_das_Ergebnis() {
            // Arrange
            string numbers = "";
            var calculator = new StringCalculator();
            
            // Act
            var ergebnis = calculator.Add(numbers);
            
            // Assert
            Assert.Equal(0, ergebnis);
            ergebnis.Should().Be(0);

        }

        [Fact]
        public void Add_5_wird_übergeben_5_ist_das_Ergebnis() {
            // Arrange
            string numbers = "5";
            var calculator = new StringCalculator();

            // Act
            var ergebnis = calculator.Add(numbers);

            // Assert
            ergebnis.Should().Be(5);
        }


        [Fact]
        public void Add_Zahlen_werden_mit_kommas_getrennt_übergeben_Summe_der_Zahlen_ist_das_Ergebnis() {
            // Arrange
            string numbers = "5,9,8";
            var calculator = new StringCalculator();

            // Act
            var ergebnis = calculator.Add(numbers);

            // Assert
            ergebnis.Should().Be(22);
        }

        [Fact]
        public void Add_Zahlen_werden_mit_absätzen_und_kommas_getrennt_übergeben_Summe_der_Zahlen_ist_das_Ergebnis() {
            // Arrange
            string numbers = "5\n9,8";
            var calculator = new StringCalculator();

            // Act
            var ergebnis = calculator.Add(numbers);

            // Assert
            ergebnis.Should().Be(22);
        }

        [Fact]
        public void Add_Negative_Zahlen_werden_übergeben_es_wird_eine_exception_mit_den_negativen_Zahlen_geworfen() {
            // Arrange
            string numbers = "//?\n-5\n-9?8";
            var calculator = new StringCalculator();

            // Act
            Action action = () => calculator.Add(numbers);
            
            // Assert
            action.Should().Throw<Exception>();

        }

        [Fact]
        public void Add_Zahl_über_1000_wird_übergeben_Zahlen_über_1000_werden_ignoriert() {
            // Arrange
            string numbers = "10,2,10000";
            var calculator = new StringCalculator();

            // Act
            int ergebnis = calculator.Add(numbers);

            // Assert
            ergebnis.Should().Be(12);
        }

        [Fact]
        public void Add_Trennzeichen_mit_mehreren_Stellen_wird_übergeben_Summe_der_Zahlen_ist_das_Ergebnis() {
            // Arrange
            string numbers = "//[***]10,2***123";
            var calculator = new StringCalculator();

            // Act
            int ergebnis = calculator.Add(numbers);

            // Assert
            ergebnis.Should().Be(135);
        }
        [Fact]
        public void Add_mehrere_Trennzeichen_mit_mehreren_Stellen_werden_übergeben_Summe_der_Zahlen_ist_das_Ergebnis() {
            // Arrange
            string numbers = "//[***][%%][§]10§2***123%%5";
            var calculator = new StringCalculator();

            // Act
            int ergebnis = calculator.Add(numbers);

            // Assert
            ergebnis.Should().Be(140);
        }

    }
}
