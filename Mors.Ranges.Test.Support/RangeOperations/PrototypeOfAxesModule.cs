﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mors.Ranges.Test.Support.RangeOperations
{
    public static class PrototypeOfAxesModule
    {
        public enum AxisPoint
        {
            InsideRange,
            OutsideRange
        }

        public struct AxisPosition
        {
            public AxisVector Subtract(AxisPosition other)
            {
                throw new NotImplementedException();
            }

            public AxisPosition Add(AxisVector other)
            {
                throw new NotImplementedException();
            }
        }

        public struct AxisVector
        {
            public AxisDistance Distance()
            {
                throw new NotImplementedException();
            }

            public bool Left()
            {
                throw new NotImplementedException();
            }

            public bool Zero()
            {
                throw new NotImplementedException();
            }
        }

        public struct AxisDistance
        {
            public int Magnitude() => 0;

            public AxisVector Subtract(AxisDistance other)
            {
                throw new NotImplementedException();
            }
        }

        public sealed class EmptyAxis : IAxisSegment
        {
            public IEnumerator<AxisPoint> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public AxisDistance Length()
            {
                throw new NotImplementedException();
            }

            public AxisPosition Start()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public sealed class RangeOnAxis : IAxisSegment
        {
            public RangeOnAxis(int startPosition, int endPosition)
            {
            }

            public IEnumerator<AxisPoint> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public AxisDistance Length()
            {
                throw new NotImplementedException();
            }

            public AxisPosition Start()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public sealed class LeftPaddingOfAxisSegment : IAxisSegment
        {
            public LeftPaddingOfAxisSegment(IAxisSegment segment, AxisDistance leftPadding)
            {
            }

            public IEnumerator<AxisPoint> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public AxisDistance Length()
            {
                throw new NotImplementedException();
            }

            public AxisPosition Start()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public sealed class RightPaddingOfAxisSegment : IAxisSegment
        {
            public RightPaddingOfAxisSegment(IAxisSegment segment, AxisDistance leftPadding)
            {
            }

            public IEnumerator<AxisPoint> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public AxisDistance Length()
            {
                throw new NotImplementedException();
            }

            public AxisPosition Start()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public interface IAxisSegment : IEnumerable<AxisPoint>
        {
            AxisPosition Start();

            AxisDistance Length();
        }

        public interface IAxisOperation<TState, TResult>
            where TState : IAxisOperationState<TState, TResult>
        {
            TState Start();
        }

        public interface IAxisOperationState<TSelf, TResult>
        {
            TSelf Next(AxisPoint left, AxisPoint right);

            TResult Result();
        }

        public struct PairOfAxisSegments
        {
            private readonly IAxisSegment _left;
            private readonly IAxisSegment _right;

            public PairOfAxisSegments(IAxisSegment left, IAxisSegment right)
            {
                _left = left;
                _right = right;
            }

            public TResult Transform<TState, TResult>(IAxisOperation<TState, TResult> operation)
                where TState : IAxisOperationState<TState, TResult>
            {
                return
                    new TransformationOfPairsOfAxisSegments<TState, TResult>(
                            new ZipOfAxisSegments(_left, _right),
                            operation)
                        .Result();
            }
        }

        public struct ZipOfAxisSegments : IEnumerable<PairOfAxisPoints>
        {
            private readonly IAxisSegment _left;
            private readonly IAxisSegment _right;

            public ZipOfAxisSegments(IAxisSegment left, IAxisSegment right)
            {
                _left = left;
                _right = right;
            }

            public IEnumerator<PairOfAxisPoints> GetEnumerator()
            {
                var differenceBetweenStarts = _left.Start().Subtract(_right.Start());
                var differenceBetweenLengths = _left.Length().Subtract(_right.Length());
                var leftEnumerator = Left(differenceBetweenStarts, differenceBetweenLengths).GetEnumerator();
                var rightEnumerator = Right(differenceBetweenStarts, differenceBetweenLengths).GetEnumerator();
                // Assumption: Left().Distance() == Right().Distance() => leftEnumerator.MoveNext() == rightEnumerator.MoveNext();
                while (leftEnumerator.MoveNext() && rightEnumerator.MoveNext())
                {
                    yield return new PairOfAxisPoints(leftEnumerator.Current, rightEnumerator.Current);
                }
            }

            private IAxisSegment Left(AxisVector differenceBetweenStarts, AxisVector differenceBetweenLengths)
            {
                return
                    new RightPaddingOfAxisSegment(
                        new LeftPaddingOfAxisSegment(
                            _left,
                            differenceBetweenStarts.Zero() || !differenceBetweenStarts.Left() ? new AxisDistance() : differenceBetweenStarts.Distance()),
                        differenceBetweenLengths.Zero() || differenceBetweenLengths.Left() ? new AxisDistance() : differenceBetweenLengths.Distance());
            }

            private IAxisSegment Right(AxisVector differenceBetweenStarts, AxisVector differenceBetweenLengths)
            {
                return
                    new RightPaddingOfAxisSegment(
                        new LeftPaddingOfAxisSegment(
                            _right,
                            differenceBetweenStarts.Zero() || differenceBetweenStarts.Left() ? new AxisDistance() : differenceBetweenStarts.Distance()),
                        differenceBetweenLengths.Zero() || !differenceBetweenLengths.Left() ? new AxisDistance() : differenceBetweenLengths.Distance());
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public struct TransformationOfPairsOfAxisSegments<TState, TResult>
            where TState : IAxisOperationState<TState, TResult>
        {
            private readonly IEnumerable<PairOfAxisPoints> _pairsOfPoints;
            private readonly IAxisOperation<TState, TResult> _operation;

            public TransformationOfPairsOfAxisSegments(IEnumerable<PairOfAxisPoints> pairsOfPoints, IAxisOperation<TState, TResult> operation)
            {
                _pairsOfPoints = pairsOfPoints;
                _operation = operation;
            }

            public TResult Result()
            {
                return
                    _pairsOfPoints.Aggregate(
                        _operation.Start(),
                        (state, pairOfPoints) => pairOfPoints.NextState<TState, TResult>(state),
                        state => state.Result());
            }
        }

        public struct PairOfAxisPoints
        {
            private readonly AxisPoint _left;
            private readonly AxisPoint _right;

            public PairOfAxisPoints(AxisPoint left, AxisPoint right)
            {
                _left = left;
                _right = right;
            }

            public TState NextState<TState, TResult>(TState state)
                where TState : IAxisOperationState<TState, TResult>
            {
                return state.Next(_left, _right);
            }
        }
    }
}