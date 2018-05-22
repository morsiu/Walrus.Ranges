﻿// Copyright (C) 2013 Łukasz Mrozek
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using NUnit.Framework;
using System;
using Mors.Ranges.Generation;
using Mors.Ranges.Test.Support.RangeOperations;

namespace Mors.Ranges
{
    [TestFixture]
    public class RangeOperationsTests
    {
        [Test]
        [TestCaseSource(typeof(RangePairTestCases), nameof(RangePairTestCases.AllNullRangePairs))]
        public void IntersectsWithShouldThrowGivenNullRange(RangePair testCase)
        {
            Assert.Throws<ArgumentNullException>(
                () => RangeOperations.IntersectsWith(testCase.RangeA, testCase.RangeB));
        }

        [Test]
        [TestCaseSource(typeof(RangePairTestCases), nameof(RangePairTestCases.AllNonNullRangePairs))]
        public void IntersectsWithShouldReturnExpectedResult(RangePair testCase)
        {
            var expected = IntersectsWithOperation.Calculate(testCase.RangeA, testCase.RangeB);
            Assert.AreEqual(
                expected,
                RangeOperations.IntersectsWith(testCase.RangeA, testCase.RangeB));
        }

        [Test]
        [TestCaseSource(typeof(RangePairTestCases), nameof(RangePairTestCases.AllNullRangePairs))]
        public void IntersectShouldThrowGivenNullRange(RangePair testCase)
        {
            Assert.Throws<ArgumentNullException>(
                () => RangeOperations.Intersect(testCase.RangeA, testCase.RangeB));
        }

        [Test]
        [TestCaseSource(typeof(RangePairTestCases), nameof(RangePairTestCases.AllNonNullRangePairs))]
        public void IntersectShouldReturnExpectedResult(RangePair testCase)
        {
            var expected = IntersectOperation.Calculate(testCase.RangeA, testCase.RangeB);
            Assert.AreEqual(
                expected,
                RangeOperations.Intersect(testCase.RangeA, testCase.RangeB));
        }

        [Test]
        [TestCaseSource(typeof(RangePairTestCases), nameof(RangePairTestCases.AllNullRangePairs))]
        public void CoversShouldThrowGivenNullRange(RangePair testCase)
        {
            Assert.Throws<ArgumentNullException>(
                () => RangeOperations.Covers(testCase.RangeA, testCase.RangeB));
        }

        [Test]
        [TestCaseSource(typeof(RangePairTestCases), nameof(RangePairTestCases.AllNonNullRangePairs))]
        public void CoversShouldReturnExpectedResult(RangePair testCase)
        {
            var expected = CoversOperation.Calculate(testCase.RangeA, testCase.RangeB);
            Assert.AreEqual(
                expected,
                RangeOperations.Covers(testCase.RangeA, testCase.RangeB));
        }

        [Test]
        [TestCaseSource(typeof(RangePairTestCases), nameof(RangePairTestCases.AllNullRangePairs))]
        public void IsCoveredByShouldThrowGivenNullRange(RangePair testCase)
        {
            Assert.Throws<ArgumentNullException>(
                () => RangeOperations.IsCoveredBy(testCase.RangeA, testCase.RangeB));
        }

        [Test]
        [TestCaseSource(typeof(RangePairTestCases), nameof(RangePairTestCases.AllNonNullRangePairs))]
        public void IsCoveredByShouldReturnExpectedResult(RangePair testCase)
        {
            var expected = IsCoveredByOperation.Calculate(testCase.RangeA, testCase.RangeB);
            Assert.AreEqual(
                expected,
                RangeOperations.IsCoveredBy(testCase.RangeA, testCase.RangeB));
        }

        [Test]
        [TestCaseSource(typeof(RangePairTestCases), nameof(RangePairTestCases.AllNullRangePairs))]
        public void SpanShouldThrowGivenNullRange(RangePair testCase)
        {
            Assert.Throws<ArgumentNullException>(
                () => RangeOperations.Span(testCase.RangeA, testCase.RangeB));
        }

        [Test]
        [TestCaseSource(typeof(RangePairTestCases), nameof(RangePairTestCases.AllNonNullRangePairs))]
        public void SpanShouldReturnExpectedResult(RangePair testCase)
        {
            var expected = SpanOperation.Calculate(testCase.RangeA, testCase.RangeB);
            Assert.AreEqual(
                expected,
                RangeOperations.Span(testCase.RangeA, testCase.RangeB));
        }
    }
}
