﻿// Copyright (C) 2019 Łukasz Mrozek
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using Mors.Ranges.Inequations;
using System;

namespace Mors.Ranges.Operations.Reference
{
    internal readonly struct OpenRange<T> : IOpenRange<T>
        where T : IComparable<T>
    {
        private readonly T _start;
        private readonly T _end;
        private readonly bool _openStart;
        private readonly bool _openEnd;
        private readonly bool _notEmpty;

        public OpenRange(in T start, in T end, bool openStart, bool openEnd)
        {
            _start = start;
            _end = end;
            _openStart = openStart;
            _openEnd = openEnd;
            _notEmpty = true;
        }

        public bool ClosedEnd() => !_openEnd;

        public bool ClosedStart() => !_openStart;

        public bool Empty() => !_notEmpty;

        public T End() => _end;

        public T Start() => _start;
    }
}