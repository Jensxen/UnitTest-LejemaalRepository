using EjendomBeregner;
using EjendomBeregner;
using Moq;
using Xunit;
namespace BusinessLogic.Test
{
    public class BeregnKvadratmeterTests
    {
        [Fact]
        public void Kvadratmeter_Sum_Stemmer_Med_Lejemaalsum()
        {
            // Arrange
            var lejemaals = new List<Lejemaal>
            {
                new Lejemaal {Kvadratmeter = 5},
                new Lejemaal {Kvadratmeter = 20},
                new Lejemaal {Kvadratmeter = 30}
            };


            var expected = lejemaals.Sum(l => l.Kvadratmeter);

            var lejemaalMock = new Mock<ILejemaalRepository>();
            lejemaalMock.Setup(l => l.HentLejemaal()).Returns(lejemaals);

            var sut = new EjendomBeregnerService(lejemaalMock.Object);
            // Act 
            var actual = sut.BeregnKvadratmeter();
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}