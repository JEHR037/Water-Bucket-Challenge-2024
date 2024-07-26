Software WaterJuggApi For Chicks Application.

-------------------------------------------------------------------
To Run Software : 
 
  1 locate in Water-Bucket-Challenge-2024\WaterJugApi
  2 Run in terminal : dotnet run
------------------------------------------------------------------
To Test Software : 

Make a POST  at  http://localhost:5000/waterjug/measure

 Example for POST : 
{
  "xCapacity": 2,
  "yCapacity": 17,
  "zAmountWanted": 4
}

Response expected : 

{
  "solution": [{
      "x": 0,
      "y": 0,
      "action": "Start"
    },{
      "x": 2,
      "y": 0,
      "action": "Fill X"
    },{
      "x": 0,
      "y": 2,
      "action": "Transfer X to Y"
    },{
      "x": 2,
      "y": 2,
      "action": "Fill X"},{
      "x": 0,
      "y": 4,
      "action": "Transfer X to Y"
    }]
}

-----------------------------------------------------------------------------------------------------------------------------------------------
To Run Unit Test: 

 1 locate in Water-Bucket-Challenge-2024\WaterJugApi.Tests
 2 in terminal Execute : dotnet test

Example of Response : 

  Iniciando la ejecución de pruebas, espere...
  1 archivos de prueba en total coincidieron con el patrón especificado.

  Correctas! - Con error:     0, Superado:     3, Omitido:     0, Total:     3, Duración: 2 ms - WaterJugApi.Tests.dll (net8.0)

-----------------------------------------------------------------------------------------------------------------------------------------------
Responses: 

  Response Expected in case of error or not solution possible:

  { 
    "message":"Error" 
  }

  OR 

  {
    "message": "No solution possible"
  }

-------------------------------------------------------------------------------------------------------------------------------------------------

Algorithm explain: 
 The algorithm consists of queuing and connecting to implement the next stage of visiting. setting initial state (0, 0), this is what indicates that both jugs are initialized empy . Then you will enter the tank, which will continue for several minutes while in the stake. In each iteration, go back to the queue state and set it to the target state (any of the jars has z Amount of Water). if so, consider the decision based on the actual condition that was originally used as the property received before each condition. A solution is a list of states, which are passages to preserve the meta. If the state is really not an objective state and does not visit it before, it is united with the visit. However, the general algorithm of all possible states can become part of the actual state. This includes flax kadu-yarra, let go of that yarra and transfer water from one yarra to another, and another that yarra is a vacation or the other liena. Each generated state that has not been visited before it hits the queue to complete the process in the coming iterations. if the tail goes away and you don't encounter any solutions, it means it's impossible to get into the water with water in old jars. In this case, the algorithm has evolved. The Measure method is the final point of the API, which contains a JugRequest object, then a solution that uses the GetSteps method, a lightweight solution converted to a list of SimpleJugState objects, and an evolution of the JugResponse object. If you haven't found any solutions, dig deeper into the 404 state. You will not encounter anything with a message.


Tech Stack : 
 SDK DE .NET:
 Version:           8.0.302
 Commit:            ef14e02af8
 Workload version:  8.0.300-manifests.5273bb1c
 MSBuild version:   17.10.4+10fbfbf2e

Unit Tests : 
  Xunit



Thanks! Att: Javier Hernandez.