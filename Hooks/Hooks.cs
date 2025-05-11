using Microsoft.Playwright;
using TechTalk.SpecFlow;
using BoDi;

[Binding]
public class Hooks
{
    private static IPlaywright? _playwright;
    private static IBrowser? _browser;
    private readonly IObjectContainer _container;

    public Hooks(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public async Task BeforeScenario()
    {
        if (_playwright == null)
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 100 });
        }

        var context = await _browser.NewContextAsync();
        var page = await context.NewPageAsync();
        _container.RegisterInstanceAs<IPage>(page);
    }

    [AfterScenario]
    public async Task AfterScenario()
    {
        if (_browser != null)
        {
            await _browser.CloseAsync();
        }
        _playwright?.Dispose();
    }
}