<!-- Logo -->
<p align="center">
  <a href="#">
    <img height="128" width="128" src="https://raw.githubusercontent.com/0xF6/Ivy.Extensions.DependencyInjection.LightProps/master/icon.png">
  </a>
</p>

<!-- Name -->
<h1 align="center">
  Microsoft Dependency Property Injection
</h1>
<p align="center">
  <a href="#">
    <img alr="MIT License" src="http://img.shields.io/:license-MIT-blue.svg">
    <img alt="Release" src="https://img.shields.io/github/release/0xF6/Ivy.Extensions.DependencyInjection.LightProps.svg">
  </a>
  <a href="https://www.nuget.org/packages/Ivy.Extensions.DependencyInjection.LightProps/">
    <img alt="Nuget" src="https://img.shields.io/nuget/v/Ivy.Extensions.DependencyInjection.LightProps.svg?color=%23884499">
  </a>
  <a href="https://t.me/ivysola">
    <img alt="Telegram" src="https://img.shields.io/badge/Ask%20Me-Anything-1f425f.svg">
  </a>
</p>
<p align="center">
  <a href="#">
    <img src="https://forthebadge.com/images/badges/made-with-c-sharp.svg">
    <img src="https://forthebadge.com/images/badges/ages-12.svg">
    <img src="https://forthebadge.com/images/badges/oooo-kill-em.svg">
    <img src="https://forthebadge.com/images/badges/powered-by-oxygen.svg">
  </a>
</p>


#### Attention
`Maybe conflict with AspCore.Mvc.Components.*`

### Default Usage

```csharp

using Microsoft.Extensions.DependencyInjection;

public class SampleClass 
{
    [Inject]
    public ILogger<SampleClass> logger { get; set; }

    public SampleClass(IServiceProvider provider) // need IServiceProvider for auto resolve props
        => provider.InjectFor(this);

}

// in DI configure


services.AddScoped<SampleClass>(); // or etc lifetime
```


### Mvc usage or etc

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

public abstract class MyGreatSuperWebController : Controller
{
    protected MyGreatSuperWebController(IServiceProvider provider)
        => provider.InjectFor(this);
}


// in other controllers


public class WeatherController : MyGreatSuperWebController
{
    public WeatherController(IServiceProvider provider) : base(provder) {}
    
    [Inject] protected ILogger<WeatherController> logger { get; set; }
    [Inject] protected myBeautifulDbContext { get; set; }
    
    
    public async Task<IActionResult> ViewWeather([FromQuery] string location)
    {
        logger.LogInformation($"call ViewWeather with location '{location}' 💫!!1");
        return View(await myBeautifulDbContext.Set<Weather>().ToListAsync());
    }
}

```

#### Install

```
Install-Package Ivy.Extensions.DependencyInjection.LightProps
```


<p align="center">
   <a href="https://ko-fi.com/P5P7YFY5">
    <img src="https://www.ko-fi.com/img/githubbutton_sm.svg">
  </a>
</p>
