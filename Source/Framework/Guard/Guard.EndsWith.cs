﻿namespace Framework
{
    using System;

    /// <summary>
    /// Determines the validity of an argument and throws Argument exceptions if invalid.
    /// </summary>
    public static partial class Guard
    {
        /// <summary>
        /// Confirms that the string parameter value ends with the expected value, otherwise throws an exception.
        /// </summary>
        /// <param name="value">The string parameter value.</param>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>
        /// The string parameter.
        /// </returns>
        /// <exception cref="System.ArgumentException">Thrown if the string parameter value does not end with the expected value.</exception>
        public static Parameter<string> EndsWith(string value, string expectedValue, string parameterName)
        {
            return new Parameter<string>(value, parameterName).EndsWith(expectedValue);
        }

        /// <summary>
        /// Confirms that the string parameter value ends with the expected value, otherwise throws an exception.
        /// </summary>
        /// <param name="value">The string parameter value.</param>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <returns>
        /// The string parameter.
        /// </returns>
        /// <exception cref="System.ArgumentException">Thrown if the string parameter value does not end with the expected value.</exception>
        public static Parameter<string> EndsWith(string value, string expectedValue, string parameterName, string exceptionMessage)
        {
            return new Parameter<string>(value, parameterName).EndsWith(expectedValue, exceptionMessage);
        }

        /// <summary>
        /// Confirms that the string parameter value ends with the expected value, otherwise throws an exception.
        /// </summary>
        /// <param name="parameter">The string parameter.</param>
        /// <param name="expectedValue">The expected value.</param>
        /// <returns>
        /// The input string parameter.
        /// </returns>
        /// <exception cref="System.ArgumentException">Thrown if the string parameter value does not end with the expected value.</exception>
        public static Parameter<string> EndsWith(this Parameter<string> parameter, string expectedValue)
        {
            return EndsWith(parameter, expectedValue, null);
        }

        /// <summary>
        /// Confirms that the string parameter value ends with the expected value, otherwise throws an exception.
        /// </summary>
        /// <param name="parameter">The string parameter.</param>
        /// <param name="expectedValue">The expected value.</param>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <returns>
        /// The input string parameter.
        /// </returns>
        /// <exception cref="System.ArgumentException">Thrown if the string parameter value does not end with the expected value.</exception>
        public static Parameter<string> EndsWith(this Parameter<string> parameter, string expectedValue, string exceptionMessage)
        {
            parameter = parameter.IsNotNull(exceptionMessage);

            if (parameter.Value.EndsWith(expectedValue))
            {
                return parameter;
            }

            if (string.IsNullOrWhiteSpace(exceptionMessage))
            {
                exceptionMessage = string.Format(
                    "String does not end with the expected value. Expected:<{0}> Actual:<{1}>.",
                    expectedValue,
                    parameter.Value);
            }

            throw new ArgumentException(exceptionMessage, parameter.ParameterName);
        }
    }
}
