﻿// Copyright (C) 2018 Łukasz Mrozek
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using NUnit.Framework;

namespace Mors.Ranges.Sequences.Tests
{
    public class LeftPaddingTests
    {
        [Test]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 1, ExpectedResult = 0)]
        [TestCase(1, 0, ExpectedResult = 0)]
        public int StartTest(int mainStart, int otherStart)
        {
            return new LeftPadding(mainStart, otherStart).Start;
        }

        [Test]
        [TestCase(-1, 0, ExpectedResult = 0)]
        [TestCase(-1, 1, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 1, ExpectedResult = 0)]
        [TestCase(1, -1, ExpectedResult = 2)]
        [TestCase(1, 0, ExpectedResult = 1)]
        public int LengthTest(int mainStart, int otherStart)
        {
            return new LeftPadding(mainStart, otherStart).Length;
        }
    }
}