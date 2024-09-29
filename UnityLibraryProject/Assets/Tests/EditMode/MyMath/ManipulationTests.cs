using NUnit.Framework;
using static MyMath.LinearAlgebraMath;
using static System.Math;
using MyMath;
using System.Collections;
using System;

namespace Tests.EditMode.MyMath.LinearAlgebraMathTests
{
    //Lacking some tests
    public class ManipulationTests
    {
        #region Move Values

        private class TryMoveValueLowerTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
                yield return GetDataTest5();
                yield return GetDataTest6();
            }

            private static (int[,], int, int, int, int[,]) GetDataTest1()
            {
                int[,] initial = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                    {7,8,9 }
                };

                int value = 1;
                int row = 0;
                int column = 0;

                int[,] expected = new int[,]
                {
                    {7,8,9 },
                    {4,5,6},
                    {1,2,3 }
                };

                return (initial, value, row, column, expected);
            }

            private static (int[,], int, int, int, int[,]) GetDataTest2()
            {
                int[,] initial = new int[,]
                {
                    {1,1,1,0 },
                    {2,2,2,2 },
                    {3,3,3,3 },
                    {4,4,4,4 }
                };

                int value = 0;
                int row = 0;
                int column = 3;

                int[,] expected = new int[,]
                {
                    {4,4,4,4 },
                    {2,2,2,2 },
                    {3,3,3,3 },
                    {1,1,1,0 }
                };

                return (initial, value, row, column, expected);
            }

            private static (int[,], int, int, int, int[,]) GetDataTest3()
            {
                int[,] initial = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                    {7,8,9 }
                };

                int value = 3;
                int row = 2;
                int column = 0;

                int[,] expected = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                    {7,8,9 }
                };

                return (initial, value, row, column, expected);
            }

            private static (int[,], int, int, int, int[,]) GetDataTest4()
            {
                int[,] initial = new int[,]
                {
                    {1,0,0 },
                    {1,1,1 },
                    {1,2,2 }
                };

                int value = 1;
                int row = 0;
                int column = 0;

                int[,] expected = new int[,]
                {
                    {1,0,0 },
                    {1,1,1 },
                    {1,2,2 }
                };


                return (initial, value, row, column, expected);
            }

            private static (int[,], int, int, int, int[,]) GetDataTest5()
            {
                int[,] initial = new int[,]
                {
                    {0,0,0 },
                    {0,0,0 },
                    {0,0,1 }
                };

                int value = 1;
                int row = 2;
                int column = 2;

                int[,] expected = new int[,]
                {
                    {0,0,0 },
                    {0,0,0 },
                    {0,0,1 }
                };

                return (initial, value, row, column, expected);
            }

            private static (int[,], int, int, int, int[,]) GetDataTest6()
            {
                int[,] initial = new int[,]
                {
                    {1,2,2},
                    {2,2,3 },
                    {3,3,4 },
                    {1,4,4 },
                };

                int value = 1;
                int row = 0;
                int column = 0;

                int[,] expected = new int[,]
                {
                    {3,3,4},
                    {2,2,3 },
                    {1,2,2},
                    {1,4,4 },
                };

                return (initial, value, row, column, expected);
            }
        }

        //Don't feel the need of doing the test for the exception because it's based on the function IsInMatrix() that was already tested
        [Test]
        [TestCaseSource(typeof(TryMoveValueLowerTestDataSource))]
        public void TryMoveValueLowerTest((int[,] initial, int value, int row, int column, int[,] expected) data)
            => Assert.IsTrue(AreTheSame(data.expected, TryMoveValueLower(data.initial, data.row, data.column, data.value)));

        private class TryMoveValueHigherTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
                yield return GetDataTest5();
                yield return GetDataTest6();
            }

            private static (int[,], int, int, int, int[,]) GetDataTest1()
            {
                int[,] initial = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                    {7,8,9 }
                };

                int value = 8;
                int row = 2;
                int column = 1;

                int[,] expected = new int[,]
                {
                    {7,8,9 },
                    {4,5,6},
                    {1,2,3 }
                };

                return (initial, value, row, column, expected);
            }

            private static (int[,], int, int, int, int[,]) GetDataTest2()
            {
                int[,] initial = new int[,]
                {
                    {1,1,1,1 },
                    {2,2,2,2 },
                    {3,3,3,0 },
                    {4,4,4,4 }
                };

                int value = 0;
                int row = 2;
                int column = 3;

                int[,] expected = new int[,]
                {
                    {3,3,3,0 },
                    {2,2,2,2 },
                    {1,1,1,1 },
                    {4,4,4,4 }
                };

                return (initial, value, row, column, expected);
            }

            private static (int[,], int, int, int, int[,]) GetDataTest3()
            {
                int[,] initial = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                };

                int value = 3;
                int row = 0;
                int column = 0;

                int[,] expected = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                };

                return (initial, value, row, column, expected);
            }

            private static (int[,], int, int, int, int[,]) GetDataTest4()
            {
                int[,] initial = new int[,]
                {
                    {1,0,0 },
                    {1,1,1 },
                    {1,2,2 }
                };

                int value = 1;
                int row = 2;
                int column = 0;

                int[,] expected = new int[,]
                {
                    {1,0,0 },
                    {1,1,1 },
                    {1,2,2 }
                };


                return (initial, value, row, column, expected);
            }

            private static (int[,], int, int, int, int[,]) GetDataTest5()
            {
                int[,] initial = new int[,]
                {
                    {0,0,1 },
                    {0,0,0 },
                    {0,0,0 }
                };

                int value = 1;
                int row = 0;
                int column = 2;

                int[,] expected = new int[,]
                {
                    {0,0,1 },
                    {0,0,0 },
                    {0,0,0 }
                };

                return (initial, value, row, column, expected);
            }

            private static (int[,], int, int, int, int[,]) GetDataTest6()
            {
                int[,] initial = new int[,]
                {
                    {1,2,2},
                    {2,2,3 },
                    {3,3,4 },
                    {1,4,4 },
                };

                int value = 1;
                int row = 3;
                int column = 0;

                int[,] expected = new int[,]
                {
                    {1,2,2},
                    {1,4,4 },
                    {3,3,4 },
                    {2,2,3},
                };

                return (initial, value, row, column, expected);
            }
        }

        //Don't feel the need of doing the test for the exception because it's based on the function IsInMatrix() that was already tested
        [Test]
        [TestCaseSource(typeof(TryMoveValueHigherTestDataSource))]
        public void TryMoveValueHigherTest((int[,] initial, int value, int row, int column, int[,] expected) data)
            => Assert.IsTrue(AreTheSame(data.expected, TryMoveValueHigher(data.initial, data.row, data.column, data.value)));

        private class SwapRowsTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
            }

            private static (int[,], int, int, int[,]) GetDataTest1()
            {
                int[,] input = new int[,]
                {
                    {1,2,3 },
                    {3,4,5 },
                    {6,7,8 }
                };

                int r1 = 0;
                int r2 = 0;

                int[,] output = new int[,]
                {
                    {1,2,3 },
                    {3,4,5 },
                    {6,7,8 }
                };

                return (input, r1, r2, output);
            }

            private static (int[,], int, int, int[,]) GetDataTest2()
            {
                int[,] input = new int[,]
                {
                    {1,2,3 },
                    {3,4,5 },
                    {6,7,8 }
                };

                int r1 = 0;
                int r2 = 1;

                int[,] output = new int[,]
                {
                    {3,4,5 },
                    {1,2,3 },
                    {6,7,8 }
                };

                return (input, r1, r2, output);
            }

            private static (int[,], int, int, int[,]) GetDataTest3()
            {
                int[,] input = new int[,]
                {
                    {1,2,3 },
                    {3,4,5 },
                    {6,7,8 }
                };

                int r1 = 1;
                int r2 = 2;

                int[,] output = new int[,]
                {
                    {1,2,3 },
                    {6,7,8 },
                    {3,4,5 }
                };

                return (input, r1, r2, output);
            }

        }

        //Don't feel the need of doing the test for the exception because it's based on the function IsInMatrix() that was already tested
        [Test]
        [TestCaseSource(typeof(SwapRowsTestDataSource))]
        public void SwapRowsTest((int[,] input, int r1, int r2, int[,] output) data)
            => Assert.IsTrue(AreTheSame(data.output, SwapRows(data.input, data.r1, data.r2)));

        #endregion

        #region Modify Values

        private class MultiplyRowByScalarTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
            }

            private static (int[,], int, int, int[,]) GetDataTest1()
            {
                int[,] input = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                    {7,8,9 }
                };

                int row = 0;
                int scalar = 0;

                int[,] output = new int[,]
                {
                    {0,0,0 },
                    {4,5,6 },
                    {7,8,9 }
                };

                return (input, row, scalar, output);
            }

            private static (int[,], int, int, int[,]) GetDataTest2()
            {
                int[,] input = new int[,]
                {
                    {1,1,1},
                    {1,1,1 }
                };

                int row = 1;
                int scalar = 5;

                int[,] output = new int[,]
                {
                    {1,1,1 },
                    {5,5,5 }
                };

                return (input, row, scalar, output);
            }

            private static (int[,], int, int, int[,]) GetDataTest3()
            {
                int[,] input = new int[,]
                {
                    {1,2 },
                    {2,3 },
                    {3,4 },
                    {4,5 },
                };

                int row = 2;
                int scalar = 10;

                int[,] output = new int[,]
                {
                    {1,2 },
                    {2,3 },
                    {30,40 },
                    {4,5 },
                };

                return (input, row, scalar, output);
            }
        }

        [Test]
        [TestCaseSource(typeof(MultiplyRowByScalarTestDataSource))]
        public void MultiplyRowByScalarTest((int[,] input, int row, int scalar, int[,] output) data)
            => Assert.IsTrue(AreTheSame(data.output, MultiplyRowByScalar(data.input, data.row, data.scalar, (x, y) => x * y)));

        private class MultiplyRowByScalarErrorTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
            }

            private static (int[,], int, bool) GetDataTest1()
            {
                int[,] input = new int[,]
                {
                    {1,2 },
                    {3,4 },
                    {5,6 },
                };

                int row = 0;
                bool expected = false;

                return (input, row, expected);
            }

            private static (int[,], int, bool) GetDataTest2()
            {
                int[,] input = new int[,]
                {
                    {1,2 },
                    {3,4 },
                    {5,6 },
                };

                int row = -1;
                bool expected = true;

                return (input, row, expected);
            }

            private static (int[,], int, bool) GetDataTest3()
            {
                int[,] input = new int[,]
                {
                    {1,2 },
                    {3,4 },
                    {5,6 },
                };

                int row = 3;
                bool expected = true;

                return (input, row, expected);
            }

            private static (int[,], int, bool) GetDataTest4()
            {
                int[,] input = new int[,]
                {
                    {1,2 }
                };

                int row = 2;
                bool expected = true;

                return (input, row, expected);
            }
        }

        [Test]
        [TestCaseSource(typeof(MultiplyRowByScalarErrorTestDataSource))]
        public void MultiplyRowByScalarErrorTest((int[,] input, int row, bool expected) data)
        {
            bool crashed = false;

            try
            {
                MultiplyRowByScalar(data.input, data.row, 0, (x, y) => x * y);
            }
            catch (NotAPartOfTheMatrixException)
            {
                crashed = true;
            }

            Assert.AreEqual(data.expected, crashed);
        }

        private class AddScalledRowsToAnotherTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
            }

            private static (int[,], int, (int, int)[], int[,]) GetDataTest1()
            {
                int[,] input = new int[,]
                {
                    {1,1 },
                    {2,2 }
                };

                int row = 0;
                (int row, int scalar)[] operations = new (int, int)[] { (1, 1) };

                int[,] output = new int[,]
                {
                    {3,3 },
                    {2,2 }
                };

                return (input, row, operations, output);
            }

            private static (int[,], int, (int, int)[], int[,]) GetDataTest2()
            {
                int[,] input = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                    {7,8,9 }
                };

                int row = 1;
                (int row, int scalar)[] operations = new (int, int)[] { (0, 3), (2, 2) };

                int[,] output = new int[,]
                {
                    {1,2,3 },
                    {21, 27, 33 },
                    {7,8,9 }
                };

                return (input, row, operations, output);
            }
            private static (int[,], int, (int, int)[], int[,]) GetDataTest3()
            {
                int[,] input = new int[,]
                {
                    {1,1,1 },
                    {2,2,2 },
                    {3,3,3, },
                    {4,4,4 },
                    {5,5,5 }
                };

                int row = 3;
                (int row, int scalar)[] operations = new (int, int)[] { (0, 0), (1, 1), (2, 2), (4, 4) };

                int[,] output = new int[,]
                {
                    {1,1,1 },
                    {2,2,2 },
                    {3,3,3, },
                    {32,32,32 },
                    {5,5,5 }
                };

                return (input, row, operations, output);
            }
        }

        [Test]
        [TestCaseSource(typeof(AddScalledRowsToAnotherTestDataSource))]
        public void AddScalledRowsToAnotherTest((int[,] input, int row, (int, int)[] operations, int[,] output) data)
            => Assert.IsTrue(AreTheSame(data.output, AddScalledRowsToAnother(data.input, data.row, (x, y) => x + y, (x, y) => x * y, data.operations)));

        private class AddScalledRowsToAnotherErrorTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
                yield return GetDataTest5();
                yield return GetDataTest6();
            }

            private static (int[,], int, (int, int)[], bool) GetDataTest1()
            {
                int[,] input = new int[,]
                {
                    {1,2 },
                    {3,4 },
                    {5,6 },
                };

                int row = 0;
                (int row, int scalar)[] operations = new (int, int)[] { (1, 1) };
                bool expected = false;

                return (input, row, operations, expected);
            }
            private static (int[,], int, (int, int)[], bool) GetDataTest2()
            {
                int[,] input = new int[,]
                {
                    {1,2 },
                    {3,4 },
                    {5,6 },
                };

                int row = 0;
                (int row, int scalar)[] operations = new (int, int)[] { (1, 1), (-1, 0) };
                bool expected = true;

                return (input, row, operations, expected);
            }
            private static (int[,], int, (int, int)[], bool) GetDataTest3()
            {
                int[,] input = new int[,]
                {
                    {1,2 },
                    {3,4 },
                    {5,6 },
                };

                int row = -1;
                (int row, int scalar)[] operations = new (int, int)[] { (1, 1) };
                bool expected = true;

                return (input, row, operations, expected);
            }
            private static (int[,], int, (int, int)[], bool) GetDataTest4()
            {
                int[,] input = new int[,]
                {
                    {1,2 },
                    {3,4 },
                    {5,6 },
                };

                int row = 0;
                (int row, int scalar)[] operations = new (int, int)[] { (5, 0) };
                bool expected = true;

                return (input, row, operations, expected);
            }
            private static (int[,], int, (int, int)[], bool) GetDataTest5()
            {
                int[,] input = new int[,]
                {
                    {1,2 },
                    {3,4 },
                    {5,6 },
                };

                int row = 10;
                (int row, int scalar)[] operations = new (int, int)[] { (0, 0), (-1, 5) };
                bool expected = true;

                return (input, row, operations, expected);
            }
            private static (int[,], int, (int, int)[], bool) GetDataTest6()
            {
                int[,] input = new int[,]
                {
                    {1,2 },
                    {3,4 },
                    {5,6 },
                };

                int row = 0;
                (int row, int scalar)[] operations = new (int, int)[] { (1, 1), (2, 2), (2, 4), (1000, 0) };
                bool expected = true;

                return (input, row, operations, expected);
            }
        }

        [Test]
        [TestCaseSource(typeof(AddScalledRowsToAnotherErrorTestDataSource))]
        public void AddScalledRowsToAnotherErrorTest((int[,] input, int row, (int, int)[] operations, bool expected) data)
        {
            bool crashed = false;

            try
            {
                AddScalledRowsToAnother(data.input, data.row, (x, y) => x + y, (x, y) => x * y, data.operations);
            }
            catch (NotAPartOfTheMatrixException)
            {
                crashed = true;
            }

            Assert.AreEqual(data.expected, crashed);
        }

        #endregion

        private class GetMatrixDeterminantTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
                yield return GetDataTest5();
                yield return GetDataTest6();
                yield return GetDataTest7();
            }

            private static (int[,], int) GetDataTest1()
            {
                int[,] matrix = new int[,]
                {
                {1,0,0 },
                {0,1,0 },
                {0,0,1},
                };

                int output = 1;

                return (matrix, output);
            }

            private static (int[,], int) GetDataTest2()
            {
                int[,] matrix = new int[,]
                {
                {1,2 },
                {3,4 },
                };

                int output = -2;

                return (matrix, output);
            }

            private static (int[,], int) GetDataTest3()
            {
                int[,] matrix = new int[,]
                {
                {1,2,3 },
                {4,5,6 },
                {7,8,9},
                };

                int output = 0;

                return (matrix, output);
            }

            private static (int[,], int) GetDataTest4()
            {
                int[,] matrix = new int[,]
                {
                {0,2,},
                {4,0,},
                };

                int output = -8;

                return (matrix, output);
            }

            private static (int[,], int) GetDataTest5()
            {
                int[,] matrix = new int[,]
                {
                {1,2,},
                {4,0,},
                };

                int output = -8;

                return (matrix, output);
            }

            private static (int[,], int) GetDataTest6()
            {
                int[,] matrix = new int[,]
                {
                {0,1,2,3},
                {4,5,6,7},
                {8,9,10,11 },
                {12,13,14,15}
                };

                int output = 0;

                return (matrix, output);
            }

            private static (int[,], int) GetDataTest7()
            {
                int[,] matrix = new int[,]
                {
                {0,1,452,453},
                {0,45451,4542,453},
                {0,451,4542,35454},
                {0,6441,4652,345},
                };

                int output = 0;

                return (matrix, output);
            }
        }

        [Test]
        [TestCaseSource(typeof(GetMatrixDeterminantTestDataSource))]
        public void GetMatrixDeterminantTest((int[,] matrix, int output) data)
            => Assert.AreEqual(data.output, GetMatrixDeterminant(data.matrix));

        private class GetMatrixDeterminantExceptionTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
                yield return GetDataTest5();
            }

            private static (int[,], bool) GetDataTest1()
            {
                int[,] input = new int[,]
                {
                    {1,2,3},
                    {4,5,6},
                    {7,8,9 }
                };

                bool exception = false;

                return (input, exception);
            }

            private static (int[,], bool) GetDataTest2()
            {
                int[,] input = new int[,]
                {
                    {1,2,3},
                    {4,5,6},
                };

                bool exception = true;

                return (input, exception);
            }

            private static (int[,], bool) GetDataTest3()
            {
                int[,] input = new int[,]
                {
                    {1,2},
                    {4,5},
                };

                bool exception = false;

                return (input, exception);
            }

            private static (int[,], bool) GetDataTest4()
            {
                int[,] input = new int[,]
                {
                    {1,2}
                };

                bool exception = true;

                return (input, exception);
            }

            private static (int[,], bool) GetDataTest5()
            {
                int[,] input = new int[,]
                {
                    {1 }

                };

                bool exception = false;

                return (input, exception);
            }
        }

        [Test]
        [TestCaseSource(typeof(GetMatrixDeterminantExceptionTestDataSource))]
        public void GetMatrixDeterminantExceptionTest((int[,] input, bool exception) data)
        {
            bool crashed = false;
            try
            {
                GetMatrixDeterminant(data.input);
            }
            catch (NotSquareMatrixException)
            {
                crashed = true;
            }
            Assert.AreEqual(data.exception, crashed);
        }

        private static float GetMatrixDeterminant(int[,] matrix)
            => GetMatrixDeterminant<int, float>(matrix, 0, 1, (x) => x, (x, y) => x + y, (x, y) => x * y, (x) => 1 / x, (x) => -x, (x, y) => Abs(x - y) < 0.00001f);


        private class CreateIndentityMatrixTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
            }

            private static (int, int[,]) GetDataTest1()
            {
                int size = 2;

                int[,] expected = new int[,]
                {
                    {1,0 },
                    {0,1 }
                };

                return (size, expected);
            }
            private static (int, int[,]) GetDataTest2()
            {
                int size = 3;

                int[,] expected = new int[,]
                {
                    {1,0,0 },
                    {0,1,0 },
                    {0,0,1 }
                };

                return (size, expected);
            }
            private static (int, int[,]) GetDataTest3()
            {
                int size = 4;

                int[,] expected = new int[,]
                {
                    {1,0,0,0 },
                    {0,1,0,0 },
                    {0,0,1,0 },
                    {0,0,0,1 }
                };

                return (size, expected);
            }



        }
        [Test]
        [TestCaseSource(typeof(CreateIndentityMatrixTestDataSource))]
        public void CreateIdentityMatrixTest((int size, int[,] expected) data)
            => Assert.IsTrue(AreTheSame(data.expected, CreateIdentityMatrix(0, 1, data.size)));

        #region Related Matrices
        private class GetMatrixMinorDeterminantTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();

            }

            private static (int[,], int, int, int[,]) GetDataTest1()
            {
                int[,] matrix = new int[,]
                {
                    {1,0,0 },
                    {0,1,0},
                    {0,0,1},
                };

                int row = 0;

                int column = 0;

                int[,] output = new int[,]
                {
                    {1,0 },
                    {0,1 }
                };

                return (matrix, row, column, output);
            }

            private static (int[,], int, int, int[,]) GetDataTest2()
            {
                int[,] matrix = new int[,]
                {
                    {1,2,3,4 },
                    {5,6,7,8 }
                };

                int row = 1;

                int column = 2;

                int[,] output = new int[,]
                {
                    {1,2,4 }
                };

                return (matrix, row, column, output);
            }

            private static (int[,], int, int, int[,]) GetDataTest3()
            {
                int[,] matrix = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                    {7,8,9 },
                    {10,11,12 },
                    {13,14,15 }
                };

                int row = 2;

                int column = 1;

                int[,] output = new int[,]
                {
                    {1,3 },
                    {4,6 },
                    {10,12 },
                    {13,15 }
                };

                return (matrix, row, column, output);
            }
        }

        //Don't feel the need of doing the test for the exception because it's based on the function IsInMatrix() that was already tested
        [Test]
        [TestCaseSource(typeof(GetMatrixMinorDeterminantTestDataSource))]
        public void GetMatrixMinor((int[,] matrix, int row, int column, int[,] output) data)
            => Assert.IsTrue(AreTheSame(data.output, GetMinor(data.matrix, data.row, data.column)));

        private class TransposeMatrixTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
            }

            private static (int[,], int[,]) GetDataTest1()
            {
                int[,] input = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                    {7,8,9 }
                };

                int[,] output = new int[,]
                {
                    {1,4,7 },
                    {2,5,8 },
                    {3,6,9 }
                };

                return (input, output);
            }

            private static (int[,], int[,]) GetDataTest2()
            {
                int[,] input = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 }
                };

                int[,] output = new int[,]
                {
                    {1,4 },
                    {2, 5},
                    {3,6 }
                };

                return (input, output);
            }

            private static (int[,], int[,]) GetDataTest3()
            {
                int[,] input = new int[,]
                {
                    {1,2 },
                    {3,4 },
                    {5,6 },
                    {7,8 }
                };

                int[,] output = new int[,]
                {
                    {1,3,5,7 },
                    {2,4,6,8 }
                };

                return (input, output);
            }
        }

        [Test]
        [TestCaseSource(typeof(TransposeMatrixTestDataSource))]
        public void TransposeMatrixTest((int[,] input, int[,] output) data)
            => Assert.IsTrue(AreTheSame(TransposeMatrix(data.input), data.output));

        private class GetCofactorMatrixTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
            }

            private static (int[,], float[,]) GetDataTest1()
            {
                int[,] input = new int[,]
                {
                    {1,1,1 },
                    {1,1,1 },
                    {1,1,1 }
                };

                float[,] output = new float[,]
                {
                    {0,0,0 },
                    {0,0,0 },
                    {0,0,0 }
                };

                return (input, output);
            }
            private static (int[,], float[,]) GetDataTest2()
            {
                int[,] input = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                    {7,8,9 }
                };

                float[,] output = new float[,]
                {
                    {-3, 6, -3},
                    {6, -12, 6 },
                    {-3, 6, -3 }
                };

                return (input, output);
            }
            private static (int[,], float[,]) GetDataTest3()
            {
                int[,] input = new int[,]
                {
                    {10,29,98 },
                    {34,34,73 },
                    {46,5,74 }
                };

                float[,] output = new float[,]
                {
                    {2151, 842, -1394},
                    {-1656, -3768, 1284 },
                    {-1215, 2602, -646 }
                };

                return (input, output);
            }
        }

        [Test]
        [TestCaseSource(typeof(GetCofactorMatrixTestDataSource))]
        public void GetCofactorMatrixTest((int[,] input, float[,] output) data)
            => Assert.IsTrue(AreTheSame(data.output, GetCofactorMatrix(data.input, 0, 1, (x) => (float)x, (x, y) => x + y, (x, y) => x * y, (x) => 1 / x, (x) => -x, (x, y) => Abs(x - y) < .1), (x, y) => Abs(x - y) < .1));

        private class GetInverseMatrixTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
            }

            private static (int[,], float[,]) GetDataTest1()
            {
                int[,] input = new int[,]
                {
                    {1,0,0 },
                    {0,1,0 },
                    {0,0, 1 },
                };

                float[,] output = new float[,]
                {
                    {1, 0, 0 },
                    {0, 1, 0 },
                    {0, 0, 1 }
                };

                return (input, output);
            }

            private static (int[,], float[,]) GetDataTest2()
            {
                int[,] input = new int[,]
                {
                    {1,2 },
                    {3,4 }
                };

                float[,] output = new float[,]
                {
                    {-2, 1 },
                    {1.5f, -.5f }
                };

                return (input, output);
            }

            private static (int[,], float[,]) GetDataTest3()
            {
                int[,] input = new int[,]
                {
                    {3,4 },
                    {5,6 }
                };

                float[,] output = new float[,]
                {
                    {-3,2 },
                    {2.5f, -1.5f }
                };

                return (input, output);
            }

            private static (int[,], float[,]) GetDataTest4()
            {
                int[,] input = new int[,]
                {
                    {4,-9,2 },
                    {7,2,7 },
                    {8, 3, 8 }
                };

                float[,] output = new float[,]
                {
                    {.5f, -7.8f, 6.7f },
                    {0, -1.6f, 1.4f },
                    {-.5f, 8.4f, -7.1f }
                };

                return (input, output);
            }
        }

        [Test]
        [TestCaseSource(typeof(GetInverseMatrixTestDataSource))]
        public void GetInverseMatrixTest((int[,] input, float[,] output) data)
        => Assert.IsTrue(AreTheSame(data.output, GetInverseMatrix(data.input), (x, y) => Abs(x - y) < .0001));


        private class GetInverseMatrixErrorTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
            }

            private static (int[,], bool) GetDataTest1()
            {
                int[,] matrix = new int[,]
                {
                    {1,2,3 },
                    {0,2,2 },
                    {1,4,5 }
                };

                bool expected = true;

                return (matrix, expected);
            }
            private static (int[,], bool) GetDataTest2()
            {
                int[,] matrix = new int[,]
                {
                    {1,0 },
                    {0,1 }
                };

                bool expected = false;

                return (matrix, expected);
            }
            private static (int[,], bool) GetDataTest3()
            {
                int[,] matrix = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                    {7,8,9},
                };

                bool expected = true;

                return (matrix, expected);
            }
            private static (int[,], bool) GetDataTest4()
            {
                int[,] matrix = new int[,]
                {
                    {9, 4, 4, 3, 8, 5 },
                    {8, 7, 5, 3, 6, 6 },
                    {2, 5, 4, 1, 9, 7 },
                    {5, 6, 0, 4, 9, 8 },
                    {5, 9, 7, 6, 4, 2 },
                    {5, 9, 7, 2, 3, 5 }
                };

                bool expected = false;

                return (matrix, expected);
            }
        }
        [Test]
        [TestCaseSource(typeof(GetInverseMatrixErrorTestDataSource))]
        public void GetInverseMatrixErrorTest((int[,] matrix, bool expected) data)
        {
            bool crashed = false;
            try
            {
                GetInverseMatrix(data.matrix);
            }
            catch (ZeroDeterminantException)
            {
                crashed = true;
            }

            Assert.AreEqual(data.expected, crashed);
        }


        private static float[,] GetInverseMatrix(int[,] input)
            => LinearAlgebraMath.GetInverseMatrix(input, 0, 1, (x) => (float)x, (x, y) => x + y, (x, y) => x * y, (x) => -x, (x) => 1 / x, (x, y) => Abs(x - y) < .0001);

        #endregion


    }
}
