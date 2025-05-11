using TechTalk.SpecFlow;
using Microsoft.Playwright;

[Binding]
public class StepDefinitions
{
    private readonly IPage _page;
    private readonly MainPage _mainPage;
    private readonly BasePage _basePage;
    private readonly string _baseUrl;

    public StepDefinitions(IPage page)
    {
        _page = page;
        _mainPage = new MainPage(page);
        _mainPage = _mainPage;
        _baseUrl = ConfigReader.GetBaseUrl();
    }

    [Given(@"user navigates to airalo website")]
    public async Task GivenUserNavigatesTo()
    {
        await _page.GotoAsync(_baseUrl);
    }

    [When("user enters '([^']*)' on search destination field on main page")]
    public async Task WhenUserEntersOnSearchDestinationFieldOnMainPage(string destination)
    {
        await _mainPage.EnterDestinationAsync(destination);
    }

    [When("user clicks on '([^']*)' local option")]
    public async Task WhenUserClicksOnLocalOption(string contryName)
    {
        await _mainPage.SelectCountryFromDropdownAsync(contryName);
    }

    [When("user clicks Buy now button on first eSim package")]
    public async Task WhenUserClicksBuyNowButtonOnESimPackage()
    {
        await _mainPage.ClickFirstBuyNonSimPackageItemAsync();
    }

    [Then("the purchase confirmation popup displays the correct details")]
    public async Task ThenThePurchaseConfirmationPopupDisplaysTheCorrectDetails(Table table)
    {
        var expectedDetails = table.Rows.ToDictionary(row => row[0], row => row[1]);
        await _mainPage.VerifyConfirmationPopupDetailsAsync(expectedDetails);
    }
}
