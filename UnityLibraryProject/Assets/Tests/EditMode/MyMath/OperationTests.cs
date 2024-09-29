using static Utilities.IEnumerableExtensions;
using static MyMath.LinearAlgebraMath;
using MyMath;
using NUnit.Framework;
using System.Collections;

namespace Tests.EditMode.MyMath.LinearAlgebraMathTests
{
    public class OperationTests
    {
        #region Adition

        private class MatrixAdditionTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetTest1Data();
                yield return GetTest2Data();
                yield return GetTest3Data();
                yield return GetTest4Data();
                yield return GetTest5Data();
            }

            private static (int[,], int[,], int[,]) GetTest1Data()
            {

                int[,] m1 = new int[,]
                {
                    { 1, 1 },
                    { 1, 1 }
                };

                int[,] m2 = new int[,]
                {
                    {0,0 },
                    {1, 0 }
                };

                int[,] result = new int[,]
                {
                    {1,1 },
                    {2,1 }
                };

                return (m1, m2, result);
            }

            private static (int[,], int[,], int[,]) GetTest2Data()
            {
                int[,] m1 = new int[,]
                {
                    { 1, 10 },
                    { -18, 4 }
                };

                int[,] m2 = new int[,]
                {
                    {-99, 20 },
                    {8, 22 }
                };

                int[,] result = new int[,]
                {
                    {-98,30 },
                    {-10,26 }
                };

                return (m1, m2, result);
            }

            private static (int[,], int[,], int[,]) GetTest3Data()
            {
                int[,] m1 = new int[,]
                {
                    { 41, 0 },
                    { -1, 4 },
                    {20,45 }
                };

                int[,] m2 = new int[,]
                {
                    {-9, 12 },
                    {82, 222 },
                    {38, 33 }
                };

                int[,] result = new int[,]
                {
                    {32,12 },
                    {81,226 },
                    {58,78}
                };

                return (m1, m2, result);
            }

            private static (int[,], int[,], int[,]) GetTest4Data()
            {
                int[,] m1 = new int[,]
                {
                    { 1, 2, 3, 4, 5},
                    { 6, 7, 8, 9, 10}
                };

                int[,] m2 = new int[,]
                {
                    {10, 20, 30, 40, 50},
                    {60, 70, 80, 90, 100}
                };

                int[,] result = new int[,]
                {
                    {11,22,33,44,55 },
                    {66,77,88,99,110}
                };

                return (m1, m2, result);
            }

            private static (int[,], int[,], int[,]) GetTest5Data()
            {
                int[,] m1 = new int[,]
                {
                    { 1, 5, 6, 7, 10, 34 },
                    { 9, 23, 56, 6, 2, 21 },
                    {0, 18, 34, 12, 1, 66 }
                };

                int[,] m2 = new int[,]
                {
                    { 1, 5, 6, 7, 10, 34 },
                    { 9, 23, 56, 6, 2, 21 },
                    {0, 18, 34, 12, 1, 66 }
                };

                int[,] result = new int[,]
                {
                    { 2, 10, 12, 14, 20, 68 },
                    { 18, 46, 112, 12, 4, 42 },
                    {0, 36, 68, 24, 2, 132 }
                };

                return (m1, m2, result);
            }
        }

        [Test]
        [TestCaseSource(typeof(MatrixAdditionTestDataSource))]
        public void MatrixAdditionTest((int[,] m1, int[,] m2, int[,] result) data)
            => Assert.IsTrue(AreTheSame(data.result, MatrixAddition(data.m1, data.m2, (x, y) => x + y)));


        private class MatrixAdditionExceptionTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetTest1Data();
                yield return GetTest2Data();
                yield return GetTest3Data();
                yield return GetTest4Data();
                yield return GetTest5Data();
                yield return GetTest6Data();
                yield return GetTest7Data();
            }

            private static (int[,], int[,], bool) GetTest1Data()
            {
                int[,] m1 = new int[,]
                {
                    { 1, 1 },
                    { 1, 1 }
                };

                int[,] m2 = new int[,]
                {
                    {0,0,5,5 },
                    {1, 0,5,5 }
                };

                bool expected = true;


                return (m1, m2, expected);
            }

            private static (int[,], int[,], bool) GetTest2Data()
            {
                int[,] m1 = new int[,]
                {
                    { 1, 10 },
                    { -18, 4 }
                };

                int[,] m2 = new int[,]
                {
                    {-99, 20 },
                };

                bool expected = true;

                return (m1, m2, expected);
            }

            private static (int[,], int[,], bool) GetTest3Data()
            {
                int[,] m1 = new int[,]
                {
                    { 41, 0 },
                    { -1, 4 },
                    {20,45 },
                    {1,1}
                };

                int[,] m2 = new int[,]
                {
                    {-9, 12, 4, 4 },
                    {82, 222, 5 ,5 },
                };

                bool expected = true;

                return (m1, m2, expected);
            }

            private static (int[,], int[,], bool) GetTest4Data()
            {
                int[,] m1 = new int[,]
                {
                    { 1, 2, 3, 4, 5,1,1,1},
                    { 6, 7, 8, 9, 10,1,1,1},
                    {1,1,1,1,1,1,1,1 }
                };

                int[,] m2 = new int[,]
                {
                    {10, 20 },
                    {60, 70},
                    {1,1 },
                    {1,1 },
                    {1,1 }
                };

                bool expected = true;


                return (m1, m2, expected);
            }

            private static (int[,], int[,], bool) GetTest5Data()
            {
                int[,] m1 = new int[,]
                 {
                    { 1},
                    { 9},
                 };

                int[,] m2 = new int[,]
                {
                    { 1, 5, 6, 7, 10},
                    { 9, 23, 56, 6, 2 },
                    {0, 18, 34, 12, 1 },
                    {1,1,1,1, 1 }
                };

                bool expected = true;

                return (m1, m2, expected);
            }

            private static (int[,], int[,], bool) GetTest6Data()
            {
                int[,] m1 = new int[,]
                 {
                    { 1},
                    { 9},
                 };

                int[,] m2 = new int[,]
                {
                    {1 },
                    {9 }
                };

                bool expected = false;

                return (m1, m2, expected);
            }

            private static (int[,], int[,], bool) GetTest7Data()
            {
                int[,] m1 = new int[,]
                 {
                    { 1,2,3},
                    { 4,5,6},
                    {7,8,9 }
                 };

                int[,] m2 = new int[,]
                {
                    {11,12,13 },
                    {14,15,16 },
                    {17,18,19 }
                };

                bool expected = false;

                return (m1, m2, expected);
            }
        }

        [Test]
        [TestCaseSource(typeof(MatrixAdditionExceptionTestDataSource))]
        public void MatrixAdditionExceptionTest((int[,] m1, int[,] m2, bool expected) data)
        {
            bool crashed = false;
            try
            {
                MatrixAddition(data.m1, data.m2, (x, y) => x + y);
            }
            catch (IncompatibleMatricesSizeException)
            {
                crashed = true;
            }

            Assert.AreEqual(data.expected, crashed);
        }

        private class VectorAdditionTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
            }

            private static (int[], int[], int[]) GetDataTest1()
            {
                const int LENGTH = 3;

                int[] v1 = new int[LENGTH] { 1, 2, 3 };
                int[] v2 = new int[LENGTH] { 1, 2, 3 };
                int[] expected = new int[LENGTH] { 2, 4, 6 };

                return (v1, v2, expected);
            }

            private static (int[], int[], int[]) GetDataTest2()
            {
                const int LENGTH = 8;

                int[] v1 = new int[LENGTH] { 1, 2, 3, 4, 5, 6, 7, 8 };
                int[] v2 = new int[LENGTH] { 9, 10, 11, 12, 13, 14, 15, 16 };
                int[] expected = new int[LENGTH] { 10, 12, 14, 16, 18, 20, 22, 24 };

                return (v1, v2, expected);
            }

            private static (int[], int[], int[]) GetDataTest3()
            {
                const int LENGTH = 1;

                int[] v1 = new int[LENGTH] { 1 };
                int[] v2 = new int[LENGTH] { 89 };
                int[] expected = new int[LENGTH] { 90 };

                return (v1, v2, expected);
            }

            private static (int[], int[], int[]) GetDataTest4()
            {
                const int LENGTH = 2;

                int[] v1 = new int[LENGTH] { 56, 87 };
                int[] v2 = new int[LENGTH] { -12, 43 };
                int[] expected = new int[LENGTH] { 44, 130 };

                return (v1, v2, expected);
            }
        }

        [Test]
        [TestCaseSource(typeof(VectorAdditionTestDataSource))]
        public void VectorAdditionTest((int[] v1, int[] v2, int[] expected) data)
            => Assert.IsTrue(HaveTheSameContent(data.expected, VectorAddition(data.v1, data.v2, (x, y) => x + y)));


        [Test]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, false)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 }, true)]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3 }, true)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6 }, true)]
        [TestCase(new int[] { 1, 2, 3, 5, 6, 7, 8 }, new int[] { 1, 2, 3, 5, 6, 7, 8 }, false)]
        public void VectorAdditionErrorTest(int[] v1, int[] v2, bool expected)
        {
            bool crashed = false;

            try
            {
                VectorAddition(v1, v2, (x, y) => x + y);
            }
            catch (IncompatibleVectorsSizeException)
            {
                crashed = true;
            }

            Assert.AreEqual(expected, crashed);
        }

        #endregion

        private class GetVectorFromMatrixTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
            }

            private static (int[,], int, int[]) GetDataTest1()
            {
                int[,] matrix = new int[,]
                {
                    {1,2,3,4,5,6,7,8 },
                    {1,2,3,4,5,6,7,8 },
                    {1,2,3,4,5,6,7,8 }
                };

                int which = 3;

                int[] vector = new int[] { 4, 4, 4 };

                return (matrix, which, vector);
            }

            private static (int[,], int, int[]) GetDataTest2()
            {
                int[,] matrix = new int[,]
                {
                    {1,2,3,4,5,6,7,8 },
                    {9,10,11,12,13,14,15,16 },
                    {17,18,19,20,21,22,23,24},
                    {25,26,27,28,29,30,31,32},
                    {33,34,35,36,37,38,39,40 }
                };

                int which = 4;

                int[] vector = new int[] { 5, 13, 21, 29, 37 };

                return (matrix, which, vector);
            }

            private static (int[,], int, int[]) GetDataTest3()
            {
                int[,] matrix = new int[,]
                {
                    {1 },
                    {2 },
                    {3 },
                    {4 },
                    {5 },
                    {6 }
                };

                int which = 0;

                int[] vector = new int[] { 1, 2, 3, 4, 5, 6 };

                return (matrix, which, vector);
            }

            private static (int[,], int, int[]) GetDataTest4()
            {
                int[,] matrix = new int[,]
                {
                    {1,2,3,4,5,6,7,8 },
                };

                int which = 5;

                int[] vector = new int[] { 6 };

                return (matrix, which, vector);
            }
        }

        [Test]
        [TestCaseSource(typeof(GetVectorFromMatrixTestDataSource))]
        public void GetVectorFromMatrixTest((int[,] matrix, int which, int[] vector) data)
            => Assert.IsTrue(HaveTheSameContent(GetVectorFromMatrix(data.matrix, data.which), data.vector, (x, y) => x == y));

        private class GetVectorFromMatrixErrorTestDataSource : IEnumerable
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
                int[,] matrix = new int[,]
                {
                    {1,2 },
                    {1,2 }
                };

                int wich = 0;

                bool expected = false;

                return (matrix, wich, expected);
            }

            private static (int[,], int, bool) GetDataTest2()
            {
                int[,] matrix = new int[,]
                {
                    {1,2 },
                    {1,2 }
                };

                int wich = 1;

                bool expected = false;

                return (matrix, wich, expected);
            }

            private static (int[,], int, bool) GetDataTest3()
            {
                int[,] matrix = new int[,]
                {
                    {1,2 },
                    {1,2 }
                };

                int wich = 2;

                bool expected = true;

                return (matrix, wich, expected);
            }

            private static (int[,], int, bool) GetDataTest4()
            {
                int[,] matrix = new int[,]
                {
                    {1,2 },
                    {1,2 }
                };

                int wich = -1;

                bool expected = true;

                return (matrix, wich, expected);
            }
        }

        [Test]
        [TestCaseSource(typeof(GetVectorFromMatrixErrorTestDataSource))]
        public void GetVectorFromMatrixErrorTest((int[,] matrix, int wich, bool expected) data)
        {
            bool crashed = false;
            try
            {
                GetVectorFromMatrix(data.matrix, data.wich);
            }
            catch (NotAPartOfTheMatrixException)
            {
                crashed = true;
            }

            Assert.AreEqual(data.expected, crashed);
        }

        #region Multiplication

        private class MultiplyByScalarTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
            }

            private static (int[,], int, int[,]) GetDataTest1()
            {
                int[,] input = new int[,]
                {
                    {1,1 },
                    {1,1},
                };

                int scalar = 1;

                int[,] output = new int[,]
                {
                    {1,1 },
                    {1,1},
                };

                return (input, scalar, output);
            }

            private static (int[,], int, int[,]) GetDataTest2()
            {
                int[,] input = new int[,]
                {
                    {10,5 },
                    {-1,9},
                };

                int scalar = 5;

                int[,] output = new int[,]
                {
                    {50,25 },
                    {-5,45},
                };

                return (input, scalar, output);
            }

            private static (int[,], int, int[,]) GetDataTest3()
            {
                int[,] input = new int[,]
                {
                    {5,7,8 },
                    {8,-8,8 }
                };

                int scalar = -2;

                int[,] output = new int[,]
                {
                    {-10, -14, -16 },
                    {-16, 16, -16 }
                };

                return (input, scalar, output);
            }

            private static (int[,], int, int[,]) GetDataTest4()
            {
                int[,] input = new int[,]
                {
                    {10,5,7,8,9,0 },
                    {-1,9,23,-32,45,4},
                    {5,6,732,2432,53,23 }
                };

                int scalar = 0;

                int[,] output = new int[,]
                {
                    {0,0,0,0,0,0 },
                    {0,0,0,0,0,0 },
                    {0,0,0,0,0,0 }
                };

                return (input, scalar, output);
            }
        }

        [Test]
        [TestCaseSource(typeof(MultiplyByScalarTestDataSource))]
        public void MultiplyMatrixByScalarTest((int[,] input, int scalar, int[,] output) data)
            => Assert.IsTrue(AreTheSame(MultiplyMatrixByScalar(data.input, data.scalar, (x, y) => x * y), data.output));

        private class MultiplyMatrixByMatrixTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();

            }

            private static (int[,], int[,], int[,]) GetDataTest1()
            {
                int[,] input1 = new int[,]
                {
                    {1,3 },
                    {2,4 }
                };

                int[,] input2 = new int[,]
                {
                    {5,6 },
                    {7,8 }
                };

                int[,] output = new int[,]
                {
                    {26, 30 },
                    {38, 44 }
                };

                return (input1, input2, output);
            }

            private static (int[,], int[,], int[,]) GetDataTest2()
            {
                int[,] input1 = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 }
                };

                int[,] input2 = new int[,]
                {
                    {7,8 },
                    {9,10 },
                    {11,12 }
                };

                int[,] output = new int[,]
                {
                    {58, 64 },
                    {139, 154 }
                };

                return (input1, input2, output);
            }

            private static (int[,], int[,], int[,]) GetDataTest3()
            {
                int[,] input1 = new int[,]
                {
                    {1,1 },
                    {2,2 },
                    {3,3 },
                    {4,4 }
                };

                int[,] input2 = new int[,]
                {
                    {1,1,1,1,1,1,1 },
                    {2,2,2,2,2,2,2}
                };

                int[,] output = new int[,]
                {
                    {3,3,3,3,3,3,3 },
                    {6,6,6,6,6,6,6 },
                    {9,9,9,9,9,9,9 },
                    {12,12,12,12,12,12,12 }
                };

                return (input1, input2, output);
            }
        }

        [Test]
        [TestCaseSource(typeof(MultiplyMatrixByMatrixTestDataSource))]
        public void MultiplyMatrixByMatrixTest((int[,] input1, int[,] intput2, int[,] output) data)
            => Assert.IsTrue(AreTheSame(MultiplyMatrixByMatrix(data.input1, data.intput2, 0, (x, y) => x + y, (x, y) => x * y), data.output));

        private class MultiplyMatrixByMatrixExceptionsTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
            }

            private static (int[,], int[,]) GetDataTest1()
            {
                int[,] input1 = new int[,]
                {
                    {1,1,1 }
                };

                int[,] input2 = new int[,]
                {
                    {1,1,1, }
                };

                return (input1, input2);
            }

            private static (int[,], int[,]) GetDataTest2()
            {
                int[,] input1 = new int[,]
                {
                    {1,1 },
                    {1,1 },
                };

                int[,] input2 = new int[,]
                {
                    {1,1,1 },
                    {1,1,1 },
                    {1,1,1 }
                };

                return (input1, input2);
            }

            private static (int[,], int[,]) GetDataTest3()
            {
                int[,] input1 = new int[,]
                {
                    {1,1,1 }
                };

                int[,] input2 = new int[,]
                {
                    {1,1,1, },
                    {1,1,1, },
                    {1,1,1, },
                    {1,1,1}
                };

                return (input1, input2);
            }
        }

        [Test]
        [TestCaseSource(typeof(MultiplyMatrixByMatrixExceptionsTestDataSource))]
        public void MultiplyMatrixByMatrixException((int[,] input1, int[,] intput2) data)
        {
            bool sucess;
            try
            {
                MultiplyMatrixByMatrix(data.input1, data.intput2, 0, (x, y) => x + y, (x, y) => x * y);
                sucess = false;
            }
            catch (IncompatibleMatricesSizeException)
            {
                sucess = true;
            }

            Assert.IsTrue(sucess);
        }

        private class MultiplyMatrixByVectorTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
            }

            private static (int[,], int[], int[]) GetDataTest1()
            {
                int[,] matrix = new int[,]
                {
                    {1,2 },
                    {3,4 }
                };

                int[] vector = new int[] { 1, 2 };

                int[] output = new int[] { 5, 11 };

                return (matrix, vector, output);
            }

            private static (int[,], int[], int[]) GetDataTest2()
            {
                int[,] matrix = new int[,]
                {
                    {1,2 ,3},
                    {4,5,6 },
                    {7,8,9 }
                };

                int[] vector = new int[] { 1, 2, 3 };

                int[] output = new int[] { 14, 32, 50 };

                return (matrix, vector, output);
            }

            private static (int[,], int[], int[]) GetDataTest3()
            {
                int[,] matrix = new int[,]
                {
                    {1,2 },
                    {3,4 },
                    {5,6 }
                };

                int[] vector = new int[] { 1, 2 };

                int[] output = new int[] { 5, 11, 17 };

                return (matrix, vector, output);
            }

            private static (int[,], int[], int[]) GetDataTest4()
            {
                int[,] matrix = new int[,]
                {
                    {1,2, 3 },
                    {4,5,6 }
                };

                int[] vector = new int[] { 1, 2, 3 };

                int[] output = new int[] { 14, 32 };

                return (matrix, vector, output);
            }

        }

        [Test]
        [TestCaseSource(typeof(MultiplyMatrixByVectorTestDataSource))]
        public void MultiplyMatrixByVectorTest((int[,] matrix, int[] vector, int[] output) data)
        {
            int[] result = MultiplyMatrixByVector(data.matrix, data.vector, 0, (x, y) => x + y, (x, y) => x * y);

            Assert.IsTrue(HaveTheSameContent(data.output, result));
        }

        private class MultiplyMatrixByVectorErrorTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
            }

            private static (int[,], int[], bool) GetDataTest1()
            {
                int[,] matrix = new int[,]
                {
                    {1,2,3 },
                    {1,2,3 },
                    {1,2,3 }
                };

                int[] vector = new int[] { 1, 2, 3 };

                bool expected = false;

                return (matrix, vector, expected);
            }

            private static (int[,], int[], bool) GetDataTest2()
            {
                int[,] matrix = new int[,]
                {
                    {1,2,3 },
                    {1,2,3 }
                };

                int[] vector = new int[] { 1, 2, 3 };

                bool expected = false;

                return (matrix, vector, expected);
            }

            private static (int[,], int[], bool) GetDataTest3()
            {
                int[,] matrix = new int[,]
                {
                    {1,2,3 },
                    {1,2,3 }
                };

                int[] vector = new int[] { 1, 2 };

                bool expected = true;

                return (matrix, vector, expected);
            }

            private static (int[,], int[], bool) GetDataTest4()
            {
                int[,] matrix = new int[,]
                {
                    {1,2, },
                    {1,2 },
                    {1,2 }
                };

                int[] vector = new int[] { 1, 2, 3 };

                bool expected = true;

                return (matrix, vector, expected);
            }
        }

        [Test]
        [TestCaseSource(typeof(MultiplyMatrixByVectorErrorTestDataSource))]
        public void MultiplyMatrixByVectorErrorTest((int[,] matrix, int[] vecotr, bool expected) data)
        {
            bool crashed = false;
            try
            {
                MultiplyMatrixByVector(data.matrix, data.vecotr, 0, (x, y) => x + y, (x, y) => x * y);
            }
            catch (IncompatibleMatrixVectorSizeException)
            {
                crashed = true;
            }

            Assert.AreEqual(data.expected, crashed);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 4, 8, 12 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 2, 4, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10, new int[] { 10, 20, 30, 40, 50 })]
        [TestCase(new int[] { 0, 1, 2, 1, 0 }, 12, new int[] { 0, 12, 24, 12, 0 })]
        public void MultiplyVectorByScalarTest(int[] input, int scalar, int[] output)
            => Assert.IsTrue(HaveTheSameContent(MultiplyVectorByScalar(input, scalar, (x, y) => x * y), output, (x, y) => x == y));

        [Test]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, 14)]
        [TestCase(new int[] { 0, 1, 2, 2, 3 }, new int[] { 9, 0, 2, 3, 3 }, 19)]
        [TestCase(new int[] { 1, 2, 1, 2 }, new int[] { 1, 2, 1, 2 }, 10)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 1, 1, 1 }, new int[] { 5, -5, 5, 5, 5, 5, -5, 5 }, 5)]
        public void VectorDotProductTest(int[] v1, int[] v2, int dotProduct)
            => Assert.AreEqual(dotProduct, VectorDotProduct(v1, v2, 0, (x, y) => x * y, (x, y) => x + y));

        [Test]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, false)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 }, true)]
        [TestCase(new int[] { 1 }, new int[] { 1, 2, 3 }, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3 }, true)]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, true)]
        public void VectorDotProductErrorTest(int[] v1, int[] v2, bool expected)
        {
            bool crashed = false;
            try
            {
                VectorDotProduct(v1, v2, 0, (x, y) => x * y, (x, y) => x + y);
            }
            catch (IncompatibleVectorsSizeException)
            {
                crashed = true;
            }

            Assert.AreEqual(expected, crashed);
        }

        [Test]
        [TestCase(new int[] { 1, 0, 0 }, new int[] { 0, 1, 0 }, new int[] { 0, 0, 1 })]
        [TestCase(new int[] { 0, 8, 0 }, new int[] { 0, 0, 8 }, new int[] { 64, 0, 0 })]
        [TestCase(new int[] { 0, 0, 2 }, new int[] { 2, 0, 0 }, new int[] { 0, 4, 0 })]
        [TestCase(new int[] { 1, 1, 1 }, new int[] { -2, -2, -2 }, new int[] { 0, 0, 0 })]
        [TestCase(new int[] { 5, 7, 8 }, new int[] { 1, 2, 3 }, new int[] { 5, -7, 3 })]
        public void VectorCrossProduct3DTest(int[] v1, int[] v2, int[] expected)
            => Assert.IsTrue(HaveTheSameContent(expected, VectorCrossProduct3D(v1, v2, (x, y) => x * y, (x, y) => x - y)));

        [Test]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, false)]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3 }, true)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 }, true)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 }, true)]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2 }, true)]
        public void VectorCrossProduct3DErrorTest(int[] v1, int[] v2, bool expected)
        {
            bool crashed = false;
            try
            {
                VectorCrossProduct3D(v1, v2, (x, y) => x * y, (x, y) => x - y);
            }
            catch (Not3DVectorException)
            {
                crashed = true;
            }

            Assert.AreEqual(expected, crashed);
        }

        #endregion

    }
}
