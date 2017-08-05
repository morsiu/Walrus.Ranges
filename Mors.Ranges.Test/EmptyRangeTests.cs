﻿// Copyright (C) 2013 Łukasz Mrozek
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using NUnit.Framework;
using System;

namespace Mors.Ranges
{
    [TestFixture]
    public class EmptyRangeTests
    {
        [Test]
        public void InstanceShouldNotReturnNullReference()
        {
            Assert.IsNotNull(EmptyRange<int>.Value);
        }

        [TestFixture]
        public class AfterConstruction
        {
            private EmptyRange<int> _emptyRange;

            [TestFixtureSetUp]
            public void SetUp()
            {
                _emptyRange = EmptyRange<int>.Value;
            }

            [Test]
            public void ShouldBeEmpty()
            {
                Assert.IsTrue(_emptyRange.IsEmpty);
            }

            [Test]
            public void StartShouldThrowInvalidOperationException()
            {
                Assert.Throws<InvalidOperationException>(
                    () => { var foo = _emptyRange.Start; });
            }

            [Test]
            public void EndShouldThrowInvalidOperationException()
            {
                Assert.Throws<InvalidOperationException>(
                    () => { var foo = _emptyRange.End; });
            }

            [Test]
            public void HasOpenStartShouldThrowInvalidOperationException()
            {
                Assert.Throws<InvalidOperationException>(
                    () => { var foo = _emptyRange.HasOpenStart; });
            }

            [Test]
            public void HasOpenEndShouldThrowInvalidOperationException()
            {
                Assert.Throws<InvalidOperationException>(
                    () => { var foo = _emptyRange.HasOpenEnd; });
            }
        }
    }
}