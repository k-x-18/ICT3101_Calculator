Feature: UsingCalculatorFactorial
    In order to calculate factorials
    As a math enthusiast
    I want to understand factorial operations

@Factorial
Scenario: Factorial of a positive number
    Given I have a calculator
    When I have entered 5 into the calculator and press factorial
    Then the factorial result should be 120

@Factorial
Scenario: Factorial of zero
    Given I have a calculator
    When I have entered 0 into the calculator and press factorial
    Then the factorial result should be 1
