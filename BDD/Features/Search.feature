Feature: Go to home page and search for products

Background: Go to homepage
	Given I am on homepage


Scenario Outline: Search for a general product type
	When I search for <SearchInput>
	Then I should see results containing <SearchOutput> under product title

	Examples: Search input and output
	| SearchInput | SearchOutput |
	| Cartridge   | Cartridge    |

	Scenario Outline: Search and filter by Brand
	When I search for <SearchInput>
	And I filter by <Brand>
	Then I should see results containing <SearchOutput> under product title

	Examples: Search input and output
	| SearchInput | Brand | SearchOutput |
	| Printer     | Canon | Canon        |

	Scenario Outline: Search for a product
	When I search for <SearchInput>
	Then I should see the result with <SearchOutput>

	Examples: Search input and output
	| SearchInput                      | SearchOutput                     |
	| Canon 9622B010AA LIDE120 Scanner | Canon 9622B010AA LIDE120 Scanner |


	Scenario Outline: Invalid search input
	When I search for <SearchInput>
	Then I should see invalid search message <SearchErrorMessage>

	Examples: Search input and output
	| SearchInput | SearchErrorMessage                                                     |
	| £"$$%$^&*(  | Sorry, your search for "£"$$%$^&*(" did not match any of our products. |  