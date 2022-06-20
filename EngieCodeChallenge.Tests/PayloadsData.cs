using System.Text.Json;
using EngieCodeChallenge.ProductionPlan.Dto;

namespace EngieCodeChallenge.Tests;

public class PayloadsData : TheoryData<Payload>
{
    private void AddJson(string json)
        => Add(JsonSerializer.Deserialize<Payload>(json) ?? throw new NullReferenceException());
    protected void Add1()
        => AddJson((@"{
  ""load"": 480,
  ""fuels"":
  {
    ""gas(euro/MWh)"": 13.4,
    ""kerosine(euro/MWh)"": 50.8,
    ""co2(euro/ton)"": 20,
    ""wind(%)"": 60
  },
  ""powerplants"": [
    {
      ""name"": ""gasfiredbig1"",
      ""type"": ""gasfired"",
      ""efficiency"": 0.53,
      ""pmin"": 100,
      ""pmax"": 460
    },
    {
      ""name"": ""gasfiredbig2"",
      ""type"": ""gasfired"",
      ""efficiency"": 0.53,
      ""pmin"": 100,
      ""pmax"": 460
    },
    {
      ""name"": ""gasfiredsomewhatsmaller"",
      ""type"": ""gasfired"",
      ""efficiency"": 0.37,
      ""pmin"": 40,
      ""pmax"": 210
    },
    {
      ""name"": ""tj1"",
      ""type"": ""turbojet"",
      ""efficiency"": 0.3,
      ""pmin"": 0,
      ""pmax"": 16
    },
    {
      ""name"": ""windpark1"",
      ""type"": ""windturbine"",
      ""efficiency"": 1,
      ""pmin"": 0,
      ""pmax"": 150
    },
    {
      ""name"": ""windpark2"",
      ""type"": ""windturbine"",
      ""efficiency"": 1,
      ""pmin"": 0,
      ""pmax"": 36
    }
  ]
}
"));
    protected void Add2()
    => AddJson(@"{
    ""load"": 480,
    ""fuels"":
    {
      ""gas(euro/MWh)"": 13.4,
      ""kerosine(euro/MWh)"": 50.8,
      ""co2(euro/ton)"": 20,
      ""wind(%)"": 0
    },
    ""powerplants"": [
      {
        ""name"": ""gasfiredbig1"",
        ""type"": ""gasfired"",
        ""efficiency"": 0.53,
        ""pmin"": 100,
        ""pmax"": 460
      },
      {
        ""name"": ""gasfiredbig2"",
        ""type"": ""gasfired"",
        ""efficiency"": 0.53,
        ""pmin"": 100,
        ""pmax"": 460
      },
      {
        ""name"": ""gasfiredsomewhatsmaller"",
        ""type"": ""gasfired"",
        ""efficiency"": 0.37,
        ""pmin"": 40,
        ""pmax"": 210
      },
      {
        ""name"": ""tj1"",
        ""type"": ""turbojet"",
        ""efficiency"": 0.3,
        ""pmin"": 0,
        ""pmax"": 16
      },
      {
        ""name"": ""windpark1"",
        ""type"": ""windturbine"",
        ""efficiency"": 1,
        ""pmin"": 0,
        ""pmax"": 150
      },
      {
        ""name"": ""windpark2"",
        ""type"": ""windturbine"",
        ""efficiency"": 1,
        ""pmin"": 0,
        ""pmax"": 36
      }
    ]
  }
  ");
    protected void Add3()
        => AddJson((@"{
  ""load"": 910,
  ""fuels"":
  {
    ""gas(euro/MWh)"": 13.4,
    ""kerosine(euro/MWh)"": 50.8,
    ""co2(euro/ton)"": 20,
    ""wind(%)"": 60
  },
  ""powerplants"": [
    {
      ""name"": ""gasfiredbig1"",
      ""type"": ""gasfired"",
      ""efficiency"": 0.53,
      ""pmin"": 100,
      ""pmax"": 460
    },
    {
      ""name"": ""gasfiredbig2"",
      ""type"": ""gasfired"",
      ""efficiency"": 0.53,
      ""pmin"": 100,
      ""pmax"": 460
    },
    {
      ""name"": ""gasfiredsomewhatsmaller"",
      ""type"": ""gasfired"",
      ""efficiency"": 0.37,
      ""pmin"": 40,
      ""pmax"": 210
    },
    {
      ""name"": ""tj1"",
      ""type"": ""turbojet"",
      ""efficiency"": 0.3,
      ""pmin"": 0,
      ""pmax"": 16
    },
    {
      ""name"": ""windpark1"",
      ""type"": ""windturbine"",
      ""efficiency"": 1,
      ""pmin"": 0,
      ""pmax"": 150
    },
    {
      ""name"": ""windpark2"",
      ""type"": ""windturbine"",
      ""efficiency"": 1,
      ""pmin"": 0,
      ""pmax"": 36
    }
  ]
}
"));
    protected void Add4()
    => AddJson((@"{
  ""load"": 4800,
  ""fuels"":
  {
    ""gas(euro/MWh)"": 13.4,
    ""kerosine(euro/MWh)"": 50.8,
    ""co2(euro/ton)"": 20,
    ""wind(%)"": 60
  },
  ""powerplants"": [
    {
      ""name"": ""gasfiredbig1"",
      ""type"": ""gasfired"",
      ""efficiency"": 0.53,
      ""pmin"": 100,
      ""pmax"": 460
    },
    {
      ""name"": ""gasfiredbig2"",
      ""type"": ""gasfired"",
      ""efficiency"": 0.53,
      ""pmin"": 100,
      ""pmax"": 460
    },
    {
      ""name"": ""gasfiredsomewhatsmaller"",
      ""type"": ""gasfired"",
      ""efficiency"": 0.37,
      ""pmin"": 40,
      ""pmax"": 210
    },
    {
      ""name"": ""tj1"",
      ""type"": ""turbojet"",
      ""efficiency"": 0.3,
      ""pmin"": 0,
      ""pmax"": 16
    },
    {
      ""name"": ""windpark1"",
      ""type"": ""windturbine"",
      ""efficiency"": 1,
      ""pmin"": 0,
      ""pmax"": 150
    },
    {
      ""name"": ""windpark2"",
      ""type"": ""windturbine"",
      ""efficiency"": 1,
      ""pmin"": 0,
      ""pmax"": 36
    }
  ]
}
"));
    protected void Add5()
    => AddJson(@"{
    ""load"": 4800,
    ""fuels"":
    {
      ""gas(euro/MWh)"": 13.4,
      ""kerosine(euro/MWh)"": 50.8,
      ""co2(euro/ton)"": 20,
      ""wind(%)"": 0
    },
    ""powerplants"": [
      {
        ""name"": ""gasfiredbig1"",
        ""type"": ""gasfired"",
        ""efficiency"": 0.53,
        ""pmin"": 100,
        ""pmax"": 460
      },
      {
        ""name"": ""gasfiredbig2"",
        ""type"": ""gasfired"",
        ""efficiency"": 0.53,
        ""pmin"": 100,
        ""pmax"": 460
      },
      {
        ""name"": ""gasfiredsomewhatsmaller"",
        ""type"": ""gasfired"",
        ""efficiency"": 0.37,
        ""pmin"": 40,
        ""pmax"": 210
      },
      {
        ""name"": ""tj1"",
        ""type"": ""turbojet"",
        ""efficiency"": 0.3,
        ""pmin"": 0,
        ""pmax"": 16
      },
      {
        ""name"": ""windpark1"",
        ""type"": ""windturbine"",
        ""efficiency"": 1,
        ""pmin"": 0,
        ""pmax"": 150
      },
      {
        ""name"": ""windpark2"",
        ""type"": ""windturbine"",
        ""efficiency"": 1,
        ""pmin"": 0,
        ""pmax"": 36
      }
    ]
  }
  ");
    protected void Add6()
        => AddJson((@"{
  ""load"": 9100,
  ""fuels"":
  {
    ""gas(euro/MWh)"": 13.4,
    ""kerosine(euro/MWh)"": 50.8,
    ""co2(euro/ton)"": 20,
    ""wind(%)"": 60
  },
  ""powerplants"": [
    {
      ""name"": ""gasfiredbig1"",
      ""type"": ""gasfired"",
      ""efficiency"": 0.53,
      ""pmin"": 100,
      ""pmax"": 460
    },
    {
      ""name"": ""gasfiredbig2"",
      ""type"": ""gasfired"",
      ""efficiency"": 0.53,
      ""pmin"": 100,
      ""pmax"": 460
    },
    {
      ""name"": ""gasfiredsomewhatsmaller"",
      ""type"": ""gasfired"",
      ""efficiency"": 0.37,
      ""pmin"": 40,
      ""pmax"": 210
    },
    {
      ""name"": ""tj1"",
      ""type"": ""turbojet"",
      ""efficiency"": 0.3,
      ""pmin"": 0,
      ""pmax"": 16
    },
    {
      ""name"": ""windpark1"",
      ""type"": ""windturbine"",
      ""efficiency"": 1,
      ""pmin"": 0,
      ""pmax"": 150
    },
    {
      ""name"": ""windpark2"",
      ""type"": ""windturbine"",
      ""efficiency"": 1,
      ""pmin"": 0,
      ""pmax"": 36
    }
  ]
}
"));
}

public class SuccessfulPayloadsData : PayloadsData
{
    public SuccessfulPayloadsData()
    {
        Add1();
        Add2();
        Add3();
    }
}

public class UnsuccessfulPayloadsData : PayloadsData
{
    public UnsuccessfulPayloadsData()
    {
        Add4();
        Add5();
        Add6();
    }
}