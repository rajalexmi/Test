Feature: AmazonShopping
	Shopping Harry potter book

Background:
	Given I have opened the amazon shopping site
	And I accept the cookie button

Scenario: 1-Validating correct site is opened
	Then I expect the amazon logo is displayed

Scenario: 2-Search a book
	When I select "Books" section in the department section
	And I enter "Harry Potter and the Cursed Child" in the search bar
	And I click the search button
	And I expect to see the results displayed are for the books "Harry Potter and the Cursed Child"
	And I expect the first item returned to have the following properties
		| BadgeName   | Title                                                  | SelectedType | Price |
		| Best Seller | Harry Potter and the Cursed Child - Parts One and Two: | Paperback    | £4.00 |

Scenario: 3-View Book details
	When I select "Books" section in the department section
	And I enter "Harry Potter and the Cursed Child" in the search bar
	And I click the search button
	And I click the first product in the result
	Then I expect to see the back to results button to confirm the book details page is displayed

Scenario: 4-Validate Book details
	When I select "Books" section in the department section
	And I enter "Harry Potter and the Cursed Child" in the search bar
	And I click the search button
	And I click the first product in the result
	Then I expect the book details are displayed in the product details page as follows
		| Title                                                  | BadgeName      | Price | SelectedType |
		| Harry Potter and the Cursed Child - Parts One and Two: | #1 Best Seller | £4.00 | Paperback    |

Scenario: 5-Add book to basket
	When I select "Books" section in the department section
	And I enter "Harry Potter and the Cursed Child" in the search bar
	And I click the search button
	And I click the first product in the result
	And I click the add to basket button
	Then I expect to see the notification of product added to basket is displayed
	And I confirm that the product added is having the correct productid as "0751565369"
	And I expect to see the title "Added to Basket"
	And I expect to see "Basket subtotal (1 item)" is added in the basket

Scenario: 6-Edit book in the basket
	When I select "Books" section in the department section
	And I enter "Harry Potter and the Cursed Child" in the search bar
	And I click the search button
	And I click the first product in the result
	And I click the add to basket button
	And I click on edit the basket
	Then I expect to see the book is displayed with the correct book information as below
		| Title                                                  | BadgeName      | Price | SelectedType |
		| Harry Potter and the Cursed Child - Parts One and Two: | #1 Best Seller | £4.00 | Paperback    |