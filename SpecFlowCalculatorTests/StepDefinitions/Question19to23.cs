using ICT3101_Calculator;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;

//19.Given the requirements above. Devise an Epic description to represent this set of
//requirements.
//Ans: Enable system quality engineers to perform software quality and reliability metrics using a single calculator command. 
//Correction (Make abit more specific)

//20. Define some User Story examples for the Features.
//ANS:
//In order to assess the defect rate of the software system.
//As a quality engineer,
//I want to calculate defect density given the total number of defects and shipped source instructions,

//In order to estimate the reliability of the software over execution time.
//As a quality engineer,
//I want to compute the current failure intensity using Musa’s logarithmic model,


//21. Translate these User Stories into two Features that cover this Epic. Then generate the
//corresponding feature files using SpecFlow.

//Feature1
//Feature: UsingCalculatorQualityMetrics
//    In order to evaluate software quality metrics
//    As a system quality engineer
//    I want to use the calculator to compute defect density and shipped source instructions

//@Metrics
//Scenario: Calculate defect density
//    Given I have a calculator
//    When I have entered 50 defects and 10000 SSI into the calculator and press DefectDensity
//    Then the metric result should be 0.005

//@Metrics
//Scenario: Calculate shipped source instructions for successive releases
//    Given I have a calculator
//    When I have entered 10000 SSI from the previous release and 2000 new SSI into the calculator and press ShippedSSI
//    Then the metric result should be 12000

//FEATURE 2
//Feature: UsingCalculatorMusaLogarithmic
//    In order to calculate software reliability using Musa’s model
//    As a system quality engineer
//    I want to use the calculator to compute current failure intensity and expected failures

//@Reliability
//Scenario: Calculate current failure intensity λ(τ)
//    Given I have a calculator
//    When I have entered 10 as initial failure intensity, 100 as total expected failures, and 30 observed failures into the calculator and press MusaFailureIntensity
//    Then the Musa result should be 7

//@Reliability
//Scenario: Calculate expected failures μ(τ)
//    Given I have a calculator
//    When I have entered 10 as initial failure intensity, 100 as total expected failures, and 20 as execution time into the calculator and press MusaExpectedFailures
//    Then the Musa result should be 86.47


//22.Create a set of acceptance tests for these Features as Gherkin Scenarios. Add these sets of
//Scenarios into the corresponding SpecFlow Features and use the BDD process to develop the
//necessary functions.

//23. In using the BDD process to develop the new functions(and corresponding functionality)
//what were some of the issues you faced? How did you resolve them to get things running?
//
//Precision in floating-point assertions – Musa Expected Failures produced floating-point results that didn’t always match exactly. 
//resolved this by using Assert.That(...).Within(0.01) in the step definitions to allow for tolerance.