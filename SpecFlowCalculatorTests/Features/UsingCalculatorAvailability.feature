Feature: UsingCalculatorAvailability
	In order to calculate MTBF and Availability
	As someone who struggles with math
	I want to be able to use my calculator to do this
@Availability
Scenario: Calculating MTBF
	Given I have a calculator
	When I have entered 100 and 5 into the calculator and press MTBF
	Then the mtbf result should be 20
@Availability
Scenario: Calculating Availability
	Given I have a calculator
	When I have entered 20 and 5 into the calculator and press Availability
	Then the availability result should be 0.8
@Availability
Scenario: High reliability system with very few failures
    Given I have a calculator
    When I have entered 1000 and 1 into the calculator and press MTBF
    Then the availability result should be 1000

@Availability
Scenario: Availability when MTTR is 0
    Given I have a calculator
    When I have entered 50 and 0 into the calculator and press Availability
    Then the availability result should be 1