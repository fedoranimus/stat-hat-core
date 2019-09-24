# StatHat

A modern, async StatHat library for .NET Core.

## Getting Started

A great place to start is the [StatHat documentation](https://www.stathat.com/manual/start).

### Adding StatHat to IServiceCollection

```C#
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddStatHat("insert-ez-key");
}
```

### Injecting the StatHatClient into a class

```C#
public ValuesController(IStatHatClient statHatClient)
```

## Using the Stat Hat Client

### Counters

 Counter stats are summed up over time.
 ```C#
 await _statHatClient.CountAsync("testCountStat", 1);
 ```

### Values

Value stats are averaged over time. 
```C#
await _statHatClient.ValueAsync("testValueStat", 1);
```