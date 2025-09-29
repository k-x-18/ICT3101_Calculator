Feature: UsingCalculatorQualityMetrics
    In order to evaluate software quality metrics
    As a system quality engineer
    I want to use the calculator to compute defect density and shipped source instructions

@Metrics
Scenario: Calculate defect density
    Given I have a calculator
    When I have entered 50 defects and 10000 SSI into the calculator and press DefectDensity
    Then the metric result should be 0.005

@Metrics
Scenario: Calculate shipped source instructions for successive releases
    Given I have a calculator
    When I have entered 10000 SSI from the previous release and 2000 new SSI into the calculator and press ShippedSSI
    Then the metric result should be 12000
