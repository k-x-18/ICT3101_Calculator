using ICT3101_Calculator;
using NUnit.Framework;
using SpecFlowCalculatorTests.Support;
namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorStepDefinitions
    {
        private readonly Calculator _calculator;
        private readonly CalculationContext _context;

        public UsingCalculatorStepDefinitions(Calculator calculator, CalculationContext context)
        {
            _calculator = calculator;
            _context = context;
        }
        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator() { }

        [When(@"I have entered (.*) and (.*) into the calculator and press add")]
        public void WhenIHaveEnteredAndIntoTheCalculator(double p0, double p1)
        {
            _context.Result = _calculator.Add(p0, p1);
        }

        // Division ---------------------------------------------------------------------------------------------------
        [When(@"I have entered (.*) and (.*) into the calculator and press divide")]
        public void WhenIHaveEnteredDivideIntoTheCalculator(double p0, double p1)
        {
            _context.Result = _calculator.Divide(p0, p1);
        }

        [Then(@"the result should be (.*)")]
        [Then(@"the division result should be (.*)")]
        public void ThenTheResultShouldBe(double expected)
        {
            Assert.That(_context.Result, Is.EqualTo(expected));
        }

        [Then(@"the division result equals positive_infinity")]
        public void ThenTheDivisionResultIsPositiveInfinity()
        {
            Assert.That(_context.Result, Is.EqualTo(double.PositiveInfinity));
        }

        // Factorial ------------------------------------------------------------------------------------------------------------------------------------------------
        [When(@"I have entered (.*) into the calculator and press factorial")]
        public void WhenIHaveEnteredIntoTheCalculatorAndPressFactorial(double number)
        {
            _context.Result = _calculator.Factorial(number);
        }

        [Then(@"the factorial result should be (.*)")]
        public void ThenTheFactorialResultShouldBe(double expected)
        {
            Assert.That(_context.Result, Is.EqualTo(expected));
        }
        //  steps for MTBF And Availability-------------------------------------------------------------------------------------------------------------------------
        [When(@"I have entered (.*) and (.*) into the calculator and press MTBF")]
        public void WhenIHaveEnteredIntoTheCalculatorAndPressMTBF(double operatingTime, double failures)
        {
            _context.Result = _calculator.MTBF(operatingTime, failures);
        }


        [When(@"I have entered (.*) and (.*) into the calculator and press Availability")]
        public void WhenIHaveEnteredIntoTheCalculatorAndPressAvailability(double mtbf, double mttr)
        {
            _context.Result = _calculator.Availability(mtbf, mttr);
        }

        [Then(@"the availability result should be (.*)")]
        public void ThenTheAvailabilityResultShouldBe(double expected)
        {
            Assert.That(_context.Result, Is.EqualTo(expected));
        }
        [Then(@"the mtbf result should be (.*)")]
        public void ThenTheMTBFResultShouldBe(double expected)
        {
            Assert.That(_context.Result, Is.EqualTo(expected));
        }
        // Basic Reliability ---------------------------------------------------------------------------------------------------
        [When(@"I have entered (.*) as initial failure intensity, (.*) as total expected failures, and (.*) as observed failures into the calculator and press MusaFailureIntensity")]
        public void WhenICalculateMusaFailureIntensity(double lambda0, double N, double muTau)
        {
            _context.Result = _calculator.MusaFailureIntensity(lambda0, N, muTau);
        }

        [When(@"I have entered (.*) as initial failure intensity, (.*) as total expected failures, and (.*) as execution time into the calculator and press MusaExpectedFailures")]
        public void WhenICalculateMusaExpectedFailures(double lambda0, double N, double tau)
        {
            _context.Result = _calculator.MusaExpectedFailures(lambda0, N, tau);
        }

        [Then(@"the Musa result should be (.*)")]
        public void ThenTheMusaResultShouldBe(double expected)
        {
            Assert.That(_context.Result, Is.EqualTo(expected).Within(0.01));
        }

        // question 2x
        [When(@"I have entered (.*) defects and (.*) SSI into the calculator and press DefectDensity")]
        public void WhenICalculateDefectDensity(double defects, double ssi)
        {
            _context.Result = _calculator.DefectDensity(defects, ssi);
        }

        [When(@"I have entered (.*) SSI from the previous release and (.*) new SSI into the calculator and press ShippedSSI")]
        public void WhenICalculateShippedSSI(double prevSsi, double newSsi)
        {
            _context.Result = _calculator.ShippedSSI(prevSsi, newSsi);
        }

        [Then(@"the metric result should be (.*)")]
        public void ThenTheMetricResultShouldBe(double expected)
        {
            Assert.That(_context.Result, Is.EqualTo(expected).Within(0.0001));
        }
    }
}