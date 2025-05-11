Feature: Purchase Esim


@purchaseEsim
Scenario: Purchase Japan Esim
	Given user navigates to airalo website
	When user enters 'Japan' on search destination field on main page
	And user clicks on 'Japan' local option
	And user clicks Buy now button on first eSim package
	Then the purchase confirmation popup displays the correct details
	  | Field    | Value       |
	  | Title    | Moshi Moshi |
	  | Coverage | Japan       |
	  | Data     | 1 GB        |
	  | Validity | 7 Days      |
	  | Price    | $4.50       |