using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace CalculatorSpecFlow.StepDefinitions
{
    [Binding]
    public class CalculatorStepDefinition
    {
        private Calculator _calculator;
        private int _firstNumber;
        private int _secondNumber;
        private int _result;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            if (_calculator == null)
            {
                _calculator = new Calculator();
            }

            if (_firstNumber == 0)
            {
                _firstNumber = number; // Сохраняем первое число
            }
            else
            {
                _secondNumber = number; // Сохраняем второе число
            }
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Sum(_firstNumber, _secondNumber);
        }

        [When(@"I press subtract")]
        public void WhenIPressSubtract()
        {
            _result = _calculator.Subtract(_firstNumber, _secondNumber);
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            _result = _calculator.Multiply(_firstNumber, _secondNumber);
        }

        [When(@"I press divide")]
        public void WhenIPressDivide()
        {
            if (_secondNumber == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            _result = _calculator.Divide(_firstNumber, _secondNumber);
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            Assert.AreEqual(expectedResult, _result);
        }
    }
}
