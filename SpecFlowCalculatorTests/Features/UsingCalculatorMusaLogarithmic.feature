Feature: UsingCalculatorMusaLogarithmic
    In order to calculate software reliability using Musa’s model
    As a system quality engineer
    I want to use the calculator to compute current failure intensity and expected failures

@Reliability
Scenario: Calculate current failure intensity
    Given I have a calculator
    When I have entered 10 as initial failure intensity, 100 as total expected failures, and 30 observed failures into the calculator and press MusaFailureIntensity
    Then the Musa result should be 7

@Reliability
Scenario: Calculate expected failures
    Given I have a calculator
    When I have entered 10 as initial failure intensity, 100 as total expected failures, and 20 as execution time into the calculator and press MusaExpectedFailures
    Then the Musa result should be 86.47
