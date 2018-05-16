﻿// Copyright (C) 2017 Łukasz Mrozek
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System.Collections.Generic;
using System.Linq;
using Mors.Ranges.Test.Support.RangeGeneration;

namespace Mors.Ranges.Operations
{
    public static class PairsOfClosedRanges
    {
        public static IEnumerable<(ClosedRange, ClosedRange)> OfAllPossibleRelations()
        {
            return RangePairGenerator.GeneratePairs(RangePairKinds.AllNonNull())
                .Where(x => IsClosedOrEmpty(x.RangeA) && IsClosedOrEmpty(x.RangeB))
                .Select(x => (new ClosedRange(x.RangeA), new ClosedRange(x.RangeB)));
        }

        private static bool IsClosedOrEmpty(IRange<int> x)
        {
            return x.IsEmpty || (!x.HasOpenStart && !x.HasOpenEnd);
        }
    }
}
