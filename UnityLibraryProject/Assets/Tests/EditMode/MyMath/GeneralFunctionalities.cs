using NUnit.Framework;
using static MyMath.LinearAlgebraMath;
using System.Collections;
using System;

namespace Tests.EditMode.MyMath.LinearAlgebraMathTests
{
    public class GeneralFunctionalities
    {
        private class IsSquareTestDataSource : IEnumerable
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

            private static (int[,], bool) GetDataTest1()
            {
                int[,] matrix = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                    {7,8,9},
                };

                bool result = true;

                return (matrix, result);
            }

            private static (int[,], bool) GetDataTest2()
            {
                int[,] matrix = new int[,]
                {
                    {1,2,3 }
                };

                bool result = false;

                return (matrix, result);
            }

            private static (int[,], bool) GetDataTest3()
            {
                int[,] matrix = new int[,]
                {
                    {1,2 },
                    {3,4 }
                };

                bool result = true;

                return (matrix, result);
            }

            private static (int[,], bool) GetDataTest4()
            {
                int[,] matrix = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 },
                    {7,8,9},
                    {10,11,12},
                };

                bool result = false;

                return (matrix, result);
            }

            private static (int[,], bool) GetDataTest5()
            {
                int[,] matrix = new int[,]
                {
                    {2 }
                };

                bool result = true;

                return (matrix, result);
            }

            private static (int[,], bool) GetDataTest6()
            {
                int[,] matrix = new int[,]
                {
                    {2, 2},
                    {5,5 },
                    {5,5 },
                    {5,5 }
                };

                bool result = false;

                return (matrix, result);
            }
        }

        [Test]
        [TestCaseSource(typeof(IsSquareTestDataSource))]
        public void IsSquareTest((int[,] matrix, bool output) data)
            => Assert.AreEqual(data.output, IsSquare(data.matrix));

        private class AreTheSameTest1DataSource : IEnumerable
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

            private static (int[,], int[,], bool) GetDataTest1()
            {
                int[,] m1 = new int[,]
                {
                    {1,2 },
                    {3,4 }
                };

                int[,] m2 = new int[,]
                {
                    {1,2 },
                    {3,4 }
                };

                bool result = true;

                return (m1, m2, result);
            }

            private static (int[,], int[,], bool) GetDataTest2()
            {
                int[,] m1 = new int[,]
                {
                    {1,1 },
                    {1,1 }
                };

                int[,] m2 = new int[,]
                {
                    {1,1 },
                    {1,2 }
                };

                bool result = false;

                return (m1, m2, result);
            }

            private static (int[,], int[,], bool) GetDataTest3()
            {
                int[,] m1 = new int[,]
                {
                    {1,1 },
                    {2,1 }
                };

                int[,] m2 = new int[,]
                {
                    {1,1 },
                    {1,1 }
                };

                bool result = false;

                return (m1, m2, result);
            }

            private static (int[,], int[,], bool) GetDataTest4()
            {
                int[,] m1 = new int[,]
                {
                    {1,2 },
                    {1,1 }
                };

                int[,] m2 = new int[,]
                {
                    {1,1 },
                    {2,1 }
                };

                bool result = false;

                return (m1, m2, result);
            }

            private static (int[,], int[,], bool) GetDataTest5()
            {
                int[,] m1 = new int[,]
                {
                    {1,2,3 },
                    {1,2,3 }
                };

                int[,] m2 = m1;

                bool result = true;

                return (m1, m2, result);
            }

            private static (int[,], int[,], bool) GetDataTest6()
            {
                int[,] m1 = new int[,]
                {
                    {1,2 }
                };

                int[,] m2 = new int[,]
                {
                    { 1, 2, 3 }
                };

                bool result = false;

                return (m1, m2, result);
            }

            private static (int[,], int[,], bool) GetDataTest7()
            {
                int[,] m1 = new int[,]
                {
                    {1,2 }
                };

                int[,] m2 = new int[,]
                {
                    { 1, 2 },
                    {1,2 }
                };

                bool result = false;

                return (m1, m2, result);
            }
        }

        [Test]
        [TestCaseSource(typeof(AreTheSameTest1DataSource))]
        public void AreTheSameTest1((int[,] m1, int[,] m2, bool output) data)
            => Assert.AreEqual(data.output, AreTheSame(data.m1, data.m2));

        private class AreTheSameTest2DataSource : IEnumerable
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
                yield return GetDataTest8();
                yield return GetDataTest9();
                yield return GetDataTest10();
            }

            private static (float[,], float[,], Func<float, float, bool>, bool) GetDataTest1()
            {
                float[,] m1 = new float[,]
                {
                    {1.1f,2 },
                    {3,4.5f }
                };

                float[,] m2 = new float[,]
                {
                    {1.1f,2 },
                    {3,4.5f }
                };

                Func<float, float, bool> equals = (x, y) => x == y;

                bool result = true;

                return (m1, m2, equals, result);
            }

            private static (float[,], float[,], Func<float, float, bool>, bool) GetDataTest2()
            {
                float[,] m1 = new float[,]
                {
                    {1,1.0000000001f },
                    {1,1 }
                };

                float[,] m2 = new float[,]
                {
                    {1,1 },
                    {1,2 }
                };

                Func<float, float, bool> equals = (x, y) => x == y;

                bool result = false;

                return (m1, m2, equals, result);
            }

            private static (float[,], float[,], Func<float, float, bool>, bool) GetDataTest3()
            {
                float[,] m1 = new float[,]
                {
                    {1,1 },
                    {2,1 }
                };

                float[,] m2 = new float[,]
                {
                    {1,1 },
                    {1,1 }
                };

                Func<float, float, bool> equals = (x, y) => x == y;

                bool result = false;

                return (m1, m2, equals, result);
            }

            private static (float[,], float[,], Func<float, float, bool>, bool) GetDataTest4()
            {
                float[,] m1 = new float[,]
                {
                    {1,2 },
                    {1,1 }
                };

                float[,] m2 = new float[,]
                {
                    {1,1 },
                    {2,1 }
                };

                Func<float, float, bool> equals = (x, y) => x == y;

                bool result = false;

                return (m1, m2, equals, result);
            }

            private static (float[,], float[,], Func<float, float, bool>, bool) GetDataTest5()
            {
                float[,] m1 = new float[,]
                {
                    {1,2,3 },
                    {1,2,3 }
                };

                float[,] m2 = m1;

                Func<float, float, bool> equals = (x, y) => x == y;

                bool result = true;

                return (m1, m2, equals, result);
            }

            private static (float[,], float[,], Func<float, float, bool>, bool) GetDataTest6()
            {
                float[,] m1 = new float[,]
                {
                    {0, 1.0000001f}
                };

                float[,] m2 = new float[,]
                {
                    {0, 1.0001f }
                };

                Func<float, float, bool> equals = (x, y) => MathF.Abs(x - y) <= 0.01f;

                bool result = true;

                return (m1, m2, equals, result);
            }

            private static (float[,], float[,], Func<float, float, bool>, bool) GetDataTest7()
            {
                float[,] m1 = new float[,]
                {
                    {0, 1.0000001f}
                };

                float[,] m2 = new float[,]
                {
                    {0, 1,001f }
                };

                Func<float, float, bool> equals = (x, y) => MathF.Abs(x - y) <= 0.00001f;

                bool result = false;

                return (m1, m2, equals, result);
            }

            private static (float[,], float[,], Func<float, float, bool>, bool) GetDataTest8()
            {
                float[,] m1 = new float[,]
                {
                    {0, 0}
                };

                float[,] m2 = new float[,]
                {
                    {1,1 }
                };

                Func<float, float, bool> equals = (x, y) => true;

                bool result = true;

                return (m1, m2, equals, result);
            }

            private static (float[,], float[,], Func<float, float, bool>, bool) GetDataTest9()
            {
                float[,] m1 = new float[,]
                {
                    {0, 1.0000001f, 1, 2, 2}
                };

                float[,] m2 = new float[,]
                {
                    {0, 1.0001f }
                };

                Func<float, float, bool> equals = (x, y) => true;

                bool result = false;

                return (m1, m2, equals, result);
            }

            private static (float[,], float[,], Func<float, float, bool>, bool) GetDataTest10()
            {
                float[,] m1 = new float[,]
                {
                    {0,0,0,0},
                    {0,0,0,0}
                };

                float[,] m2 = new float[,]
                {
                    {0, 1,0001f }
                };

                Func<float, float, bool> equals = (x, y) => x == y;

                bool result = false;

                return (m1, m2, equals, result);
            }
        }

        [Test]
        [TestCaseSource(typeof(AreTheSameTest2DataSource))]
        public void AreTheSameTest2((float[,] m1, float[,] m2, Func<float, float, bool> equals, bool output) data)
            => Assert.AreEqual(data.output, AreTheSame(data.m1, data.m2, data.equals));

        private class ConvertMatrixTypeTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
            }

            private static (int[,], Func<int, float>, float[,]) GetDataTest1()
            {
                int[,] input = new int[,]
                {
                    {1,2,3 },
                    {4,5,6 }
                };

                Func<int, float> transformation = (x) => 2.5f * x;

                float[,] output = new float[,]
                {
                    {2.5f, 5, 7.5f },
                    {10, 12.5f, 15 }
                };

                return (input, transformation, output);
            }

            private static (int[,], Func<int, float>, float[,]) GetDataTest2()
            {
                int[,] input = new int[,]
                {
                    {0,4,7,8 },
                    {1,2,3,4},
                    {8,10,12,2 }
                };

                Func<int, float> transformation = (x) => .1f * x;

                float[,] output = new float[,]
                {
                    {0,.4f,.7f,.8f },
                    {.1f,.2f,.3f,.4f},
                    {.8f,1,1.2f,.2f }
                };

                return (input, transformation, output);
            }
        }

        [Test]
        [TestCaseSource(typeof(ConvertMatrixTypeTestDataSource))]
        public void ConvertMatrixTypeTest((int[,] input, Func<int, float> transformation, float[,] output) data)
            => Assert.AreEqual(data.output, ConvertMatrixType(data.input, data.transformation));


        private class AreTheSameSizeTestDataSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return GetDataTest1();
                yield return GetDataTest2();
                yield return GetDataTest3();
                yield return GetDataTest4();
                yield return GetDataTest5();
            }

            private static (int[,], int[,], bool) GetDataTest1()
            {
                int[,] m1 = new int[,]
                {
                    {1,2 },
                    {3,4 }
                };

                int[,] m2 = new int[,]
                {
                    {1,2 },
                    {3,4 }
                };

                bool expected = true;

                return (m1, m2, expected);
            }

            private static (int[,], int[,], bool) GetDataTest2()
            {
                int[,] m1 = new int[,]
                {
                    {1,2 },
                    {3,4 }
                };

                int[,] m2 = new int[,]
                {
                    {1,2,3,4 }
                };

                bool expected = false;

                return (m1, m2, expected);
            }

            private static (int[,], int[,], bool) GetDataTest3()
            {
                int[,] m1 = new int[,]
                {
                    {1,2,3 },
                    {1,2,3 }
                };

                int[,] m2 = new int[,]
                {
                    {1,2,3 },
                    {1,2,3 },
                    {1,2,3 }
                };

                bool expected = false;

                return (m1, m2, expected);
            }

            private static (int[,], int[,], bool) GetDataTest4()
            {
                int[,] m1 = new int[,]
                {
                    {1,2 },
                    {1,2 }
                };

                int[,] m2 = new int[,]
                {
                    {1,2,3 },
                    {1,2,3 }
                };

                bool expected = false;

                return (m1, m2, expected);
            }

            private static (int[,], int[,], bool) GetDataTest5()
            {
                int[,] m1 = new int[,]
                {
                    {1,2,3,4,5, },
                    {1,2,3,4,5 },
                    {1,2,3,4,5 }
                };

                int[,] m2 = new int[,]
                {
                    {11,12,13,14,15 },
                    {11,12,13,14,15 },
                    {11,12,13,14,15 }
                };

                bool expected = true;

                return (m1, m2, expected);
            }
        }

        [Test]
        [TestCaseSource(typeof(AreTheSameSizeTestDataSource))]
        public void AreTheSameSizeTest((int[,] m1, int[,] m2, bool expected) data)
            => Assert.AreEqual(data.expected, AreTheSameSize(data.m1, data.m2));

        private class IsInTheMatrixTestDataSource : IEnumerable
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

            private static (int[,], int, int, bool) GetDataTest1()
            {
                int[,] m = new int[,]
                {
                    {1,2 },
                    {1,2 }
                };

                int row = 0;

                int column = 0;

                bool expected = true;

                return (m, row, column, expected);
            }

            private static (int[,], int, int, bool) GetDataTest2()
            {
                int[,] m = new int[,]
                {
                    {1,2 },
                    {1,2 }
                };

                int row = -1;

                int column = 0;

                bool expected = false;

                return (m, row, column, expected);
            }

            private static (int[,], int, int, bool) GetDataTest3()
            {
                int[,] m = new int[,]
                {
                    {1,2 },
                    {1,2 }
                };

                int row = 2;

                int column = 0;

                bool expected = false;

                return (m, row, column, expected);
            }

            private static (int[,], int, int, bool) GetDataTest4()
            {
                int[,] m = new int[,]
                {
                    {1,2 },
                    {1,2 }
                };

                int row = 0;

                int column = -1;

                bool expected = false;

                return (m, row, column, expected);
            }

            private static (int[,], int, int, bool) GetDataTest5()
            {
                int[,] m = new int[,]
                {
                    {1,2 },
                    {1,2 }
                };

                int row = 0;

                int column = 2;

                bool expected = false;

                return (m, row, column, expected);
            }

            private static (int[,], int, int, bool) GetDataTest6()
            {
                int[,] m = new int[,]
                {
                    {1,2 },
                    {1,2 }
                };

                int row = -1;

                int column = 5;

                bool expected = false;

                return (m, row, column, expected);
            }
        }

        [Test]
        [TestCaseSource(typeof(IsInTheMatrixTestDataSource))]
        public void IsInTheMatrixTest((int[,] m, int row, int column, bool expected) data)
            => Assert.AreEqual(data.expected, IsInTheMatrix(data.m, data.row, data.column));

    }
}
