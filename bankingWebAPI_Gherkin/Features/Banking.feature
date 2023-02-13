Feature: Banking
Banking test automation to verify the following:
Get, Put, Post and Delete requests in the API
Background: 
Given account number is 1
	And account is active
	And name on account is 'Basso, Melanie'
	And account balance is 100.00

@mytag
Scenario: Withdrawing from an account with less than 100 in it
	And user attempts to withdraw an amount of 20.00
	Then I expect an exception to be thrown
	Then I expect to see the following output
			| Name           | AccountNo | IsActive | Balance |
			| Basso, Melanie | 1         | true     | 100.00  |

Scenario: Depositing money into an account
	And user attempts to deposit 1200.00 into account
	Then I expect to see the following output
		| Name           | AccountNo | IsActive | Balance |
		| Basso, Melanie | 1         | true     | 1300.00 |

Scenario: Withdrawing more than 90% of current balance in account
	And user attempts to withdraw an amount of 1081.00
	Then I expect an exception to be thrown
	Then I expect to see the following output
		| Name           | AccountNo | IsActive | Balance |
		| Basso, Melanie | 1         | true     | 1300.00 |

Scenario: Depositing more than 10000 in one transaction
	And user attempts to deposit 10001.00 into account
	Then I expect an exception to be thrown
	Then I expect to see the following output
		| Name           | AccountNo | IsActive | Balance |
		| Basso, Melanie | 1         | true     | 1300.00 |

Scenario: Withdrawing money from an account
	And user attempts to withdraw an amount of 300.00
	Then I expect to see the following output
		| Name           | AccountNo | IsActive | Balance |
		| Basso, Melanie | 1         | true     | 1000.00 |
