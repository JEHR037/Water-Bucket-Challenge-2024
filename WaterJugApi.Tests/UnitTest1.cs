using Xunit;
using WaterJugApi.Controllers; 
namespace WaterJugApi.Tests
{
    public class WaterJugControllerTests
    {
        [Fact]
        public void GetSteps_ShouldReturnCorrectSolution_WhenSolutionExists()
        {
            // Arrange
            int xCapacity = 2;
            int yCapacity = 10;
            int zAmountWanted = 4;

            var result = WaterJugController.GetSteps(xCapacity, yCapacity, zAmountWanted);

            Assert.NotNull(result);
            Assert.Equal(5, result.Count);
            Assert.Equal(new List<string> { "Start", "Fill X", "Transfer X to Y", "Fill X", "Transfer X to Y" }, result.Select(r => r.Action).ToList());
            Assert.Equal(4, result.Last().Y);
        }

        [Fact]
        public void GetSteps_ShouldReturnNull_WhenNoSolutionExists()
        {
            // Arrange
            int xCapacity = 55;
            int yCapacity = 99;
            int zAmountWanted = 15; 

            var result = WaterJugController.GetSteps(xCapacity, yCapacity, zAmountWanted);

            Assert.Null(result);
        }

        [Fact]
        public void SimplifySolution_ShouldReturnCorrectSimplifiedSolution()
        {
            // Arrange
            var solution = new List<WaterJugController.JugState>
            {
                new WaterJugController.JugState(0, 0, "Start", null),
                new WaterJugController.JugState(2, 0, "Fill X", null),
                new WaterJugController.JugState(0, 2, "Transfer X to Y", null),
                new WaterJugController.JugState(2, 2, "Fill X", null),
                new WaterJugController.JugState(0, 4, "Transfer X to Y", null)
            };

            var simplifiedSolution = WaterJugController.SimplifySolution(solution);

            Assert.Equal(5, simplifiedSolution.Count);
            Assert.Equal(new List<string> { "Start", "Fill X", "Transfer X to Y", "Fill X", "Transfer X to Y" }, simplifiedSolution.Select(r => r.Action).ToList());
            Assert.Equal(4, simplifiedSolution.Last().Y);
        }
    }
}
