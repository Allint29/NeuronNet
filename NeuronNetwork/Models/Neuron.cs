using System;
using System.Collections.Generic;
using System.Text;
using NeuronNetwork.Enums;

namespace NeuronNetwork.Models
{
    public class Neuron
    {
        public List<double> Weights { get; }
        public NeuronType NeuronType { get; }
        public double Output { get; private set; }

        public Neuron(int inputCount, NeuronType type = NeuronType.Normal)
        {
            NeuronType = type;
            Weights = new List<double>();

            for (int i = 0; i < inputCount; i++)
            {
                Weights.Add(1.0);
            }
        }

        public double FeedForward(List<double> inputs)
        {
            var sum = 0.0;
            for (int i = 0; i < inputs.Count; i++)
            {
                sum += inputs[i] * Weights[i];
            }

            Output = Sigmoid(sum);
            return Output;

        }

        public double Sigmoid(double x) => 1.0 / (1.0 + Math.Pow(Math.E, -x));

        public override string ToString() => Output.ToString();
    }
}
