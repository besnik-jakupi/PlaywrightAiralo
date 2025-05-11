using Microsoft.Playwright;

public abstract class BasePage
{
    protected IPage Page { get; }

    public BasePage(IPage page)
    {
        Page = page;
    }
}
