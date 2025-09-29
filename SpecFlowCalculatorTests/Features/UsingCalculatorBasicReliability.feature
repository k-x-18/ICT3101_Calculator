Feature: UsingCalculatorBasicReliability
    In order to calculate the Basic Musa model's failures/intensities
    As a Software Quality Metric enthusiast
    I want to use my calculator to do this

@Reliability
Scenario: Calculating current failure intensity λ(τ)
    Given I have a calculator
    When I have entered 10 as initial failure intensity, 100 as total expected failures, and 30 as observed failures into the calculator and press MusaFailureIntensity
    Then the Musa result should be 7

@Reliability
Scenario: Calculating expected failures μ(τ)
    Given I have a calculator
    When I have entered 10 as initial failure intensity, 100 as total expected failures, and 20 as execution time into the calculator and press MusaExpectedFailures
    Then the Musa result should be 86.47
