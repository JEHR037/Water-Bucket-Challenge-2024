using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WaterJugApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WaterJugController : ControllerBase
    {
        public class JugState
        {
            public int X { get; set; }
            public int Y { get; set; }
            public string Action { get; set; }
            public JugState? Previous { get; set; }

            public JugState(int x, int y, string action, JugState? previous)
            {
                X = x;
                Y = y;
                Action = action;
                Previous = previous;
            }
        }

        public class JugRequest
        {
            public int XCapacity { get; set; }
            public int YCapacity { get; set; }
            public int ZAmountWanted { get; set; }
        }

        public class SimpleJugState
        {
            public int X { get; set; }
            public int Y { get; set; }
            public string Action { get; set; }

            public SimpleJugState(int x, int y, string action)
            {
                X = x;
                Y = y;
                Action = action;
            }
        }

        public class JugResponse
        {
            public List<SimpleJugState>? Solution { get; set; }
        }

        [HttpPost("measure")]
        public IActionResult Measure([FromBody] JugRequest request)
        {
            var solution = GetSteps(request.XCapacity, request.YCapacity, request.ZAmountWanted);
            if (solution == null)
            {
                return NotFound(new { message = "No solution possible" });
            }

            var simpleSolution = SimplifySolution(solution);

            var response = new JugResponse
            {
                Solution = simpleSolution
            };

            return Ok(response);
        }

        public static List<JugState>? GetSteps(int xCapacity, int yCapacity, int zAmountWanted)
    {
    int gcd(int a, int b)
    {
        if (b == 0)
            return a;
        return gcd(b, a % b);
    }

    if (zAmountWanted % gcd(xCapacity, yCapacity) != 0)
    {
        return null;
    }
    var queue = new Queue<JugState>();
    var visited = new HashSet<(int, int)>();
    queue.Enqueue(new JugState(0, 0, "Start", null));

    while (queue.Count > 0)
    {
        var currentState = queue.Dequeue();

        if (currentState.X == zAmountWanted || currentState.Y == zAmountWanted)
        {
            var solution = new List<JugState>();
            while (currentState != null)
            {
                solution.Insert(0, currentState);
                currentState = currentState.Previous;
            }
            return solution;
        }

        if (visited.Contains((currentState.X, currentState.Y)))
        {
            continue;
        }

        visited.Add((currentState.X, currentState.Y));

        var nextStates = new List<JugState>
        {
            new JugState(xCapacity, currentState.Y, "Fill X", currentState),
            new JugState(currentState.X, yCapacity, "Fill Y", currentState),
            new JugState(0, currentState.Y, "Empty X", currentState),
            new JugState(currentState.X, 0, "Empty Y", currentState),
            new JugState(currentState.X - Math.Min(currentState.X, yCapacity - currentState.Y), currentState.Y + Math.Min(currentState.X, yCapacity - currentState.Y), "Transfer X to Y", currentState),
            new JugState(currentState.X + Math.Min(currentState.Y, xCapacity - currentState.X), currentState.Y - Math.Min(currentState.Y, xCapacity - currentState.X), "Transfer Y to X", currentState)
        };

        foreach (var state in nextStates)
        {
            if (!visited.Contains((state.X, state.Y)))
            {
                queue.Enqueue(state);
            }
        }
    }

    return null;
    }
        public static List<SimpleJugState> SimplifySolution(List<JugState> solution)
        {
            var simpleSolution = new List<SimpleJugState>();

            foreach (var state in solution)
            {
                simpleSolution.Add(new SimpleJugState(state.X, state.Y, state.Action));
            }

            return simpleSolution;
        }
    }
}
