using System;

namespace Wikipedia.Patterns.Strategy
{
    // MainApp test application
    class MainApp
    {
        static void Main()
        {
            Context context;

            // Three contexts following different strategies
            context = new Context(new ConcreteStrategyA());
            context.Execute();

            context = new Context(new ConcreteStrategyB());
            context.Execute();

            context = new Context(new ConcreteStrategyC());
            context.Execute();

        }
    }

    // The classes that implement a concrete strategy should implement this
    // The context class uses this to call the concrete strategy
    interface IStrategy
    {
        void Execute();
    }

    // Implements the algorithm using the strategy interface
    class ConcreteStrategyA : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Called ConcreteStrategyA.Execute()");
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Called ConcreteStrategyB.Execute()");
        }
    }

    class ConcreteStrategyC : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Called ConcreteStrategyC.Execute()");
        }
    }

    // Configured with a ConcreteStrategy object and maintains a reference to a Strategy object
    class Context
    {
        IStrategy strategy;

        // Constructor
        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Execute()
        {
            strategy.Execute();
        }
    }
}