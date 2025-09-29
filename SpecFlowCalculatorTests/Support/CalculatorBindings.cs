using ICT3101_Calculator;
using Reqnroll;
using Reqnroll.BoDi;

namespace SpecFlowCalculatorTests.Support
{
    [Binding]
    public class CalculatorBindings
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _container;

        public CalculatorBindings(ScenarioContext scenarioContext, IObjectContainer container)
        {
            _scenarioContext = scenarioContext;
            _container = container;
        }

        [BeforeScenario]
        public void CreateCalculator()
        {
            // Register shared instances in the scenario container for constructor injection
            _container.RegisterInstanceAs(new Calculator());
            _container.RegisterInstanceAs(new CalculationContext());
        }
    }
}
