using Microsoft.Playwright;

public class MainPage : BasePage
{
    public MainPage(IPage page) : base(page) { }
    public ILocator SearchInput => Page.GetByTestId("search-input");
    public ILocator GetDropdownOptionByCountry(string country) => Page.GetByTestId($"{country}-name");
    public ILocator SecondSimPackageItem => Page.GetByTestId("sim-package-item").Nth(1);
    public ILocator ConfirmationPopup => Page.GetByTestId("package-detail");
    public ILocator PopupTitle => ConfirmationPopup.GetByTestId("sim-detail-operator-title");
    public ILocator PopupCoverage => ConfirmationPopup.GetByTestId("COVERAGE-value");
    public ILocator PopupData => ConfirmationPopup.GetByTestId("DATA-value");
    public ILocator PopupValidity => ConfirmationPopup.GetByTestId("VALIDITY-value");
    public ILocator PopupPrice => ConfirmationPopup.GetByTestId("PRICE-value");

    public async Task EnterDestinationAsync(string name)
    {
        await SearchInput.FillAsync(name);
    }

    public async Task SelectCountryFromDropdownAsync(string country)
    {
        var option = GetDropdownOptionByCountry(country);
        await option.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        await option.ClickAsync();
    }

    public async Task ClickFirstBuyNonSimPackageItemAsync()
    {
        await SecondSimPackageItem.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        await SecondSimPackageItem.ClickAsync();
    }

    public async Task VerifyConfirmationPopupDetailsAsync(Dictionary<string, string> expectedDetails)
    {
        try
        {
            await ConfirmationPopup.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 5000 });

            string? title = (await PopupTitle.TextContentAsync())?.Trim();
            string? coverage = (await PopupCoverage.TextContentAsync())?.Trim();
            string? data = (await PopupData.TextContentAsync())?.Trim();
            string? validity = (await PopupValidity.TextContentAsync())?.Trim();
            string? price = (await PopupPrice.TextContentAsync())?.Replace(" USD", "").Trim();

            Assert.AreEqual(expectedDetails["Title"].Trim(), title, "Title mismatch");
            Assert.AreEqual(expectedDetails["Coverage"].Trim(), coverage, "Coverage mismatch");
            Assert.AreEqual(expectedDetails["Data"].Trim(), data, "Data mismatch");
            Assert.AreEqual(expectedDetails["Validity"].Trim(), validity, "Validity mismatch");
            Assert.AreEqual(expectedDetails["Price"].Trim(), price, "Price mismatch");
        }
        catch (TimeoutException)
        {
            Assert.Fail("Confirmation popup did not appear within the timeout period.");
        }
    }
}