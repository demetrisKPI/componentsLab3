using IIG.BinaryFlag;
using System;
using Xunit;

namespace TestBinaryFlag
{
    public class UnitTest1
    {
        [Fact]
        public void TestConstructor()
        {
            MultipleBinaryFlag bFlag = new MultipleBinaryFlag(4);
            Assert.True(bFlag.GetFlag());
        }
        [Fact]
        public void TestConstructorSecondArgument()
        {
            MultipleBinaryFlag bFlag = new MultipleBinaryFlag(4, false);
            Assert.False(bFlag.GetFlag());
        }
        [Fact]
        public void TestConstructorLowEndLengthLimit()
        {
            try
            {
                MultipleBinaryFlag bFlag = new MultipleBinaryFlag(1);
            }
            catch (Exception e)
            {
                string errorMsg = "Length of Flag must be bigger than one";
                bool pass = e.Message.Contains(errorMsg);
                Assert.True(pass);
            }
        }
        [Fact]
        public void TestConstructorHighEndLengthLimit()
        {
            try
            {
                MultipleBinaryFlag bFlag = new MultipleBinaryFlag(123456789012);
            }
            catch (Exception e)
            {
                string errorMsg = "Length of Flag must be lesser than '17179868705'";
                bool pass = e.Message.Contains(errorMsg);
                Assert.True(pass);
            }
        }
        [Fact]
        public void TestSetFlag()
        {
            ulong length = 10;
            MultipleBinaryFlag bFlag = new MultipleBinaryFlag(length, false);
            for (ulong i = 0; i < length; i++) bFlag.SetFlag(i);
            Assert.True(bFlag.GetFlag());
        }
        [Fact]
        public void TestResetFlag()
        {
            ulong length = 10;
            MultipleBinaryFlag bFlag = new MultipleBinaryFlag(length);
            for (ulong i = 0; i < length; i++) bFlag.ResetFlag(i);
            Assert.False(bFlag.GetFlag());
        }
        [Fact]
        public void TestSetFlagExceedsLength()
        {
            try
            {
                MultipleBinaryFlag bFlag = new MultipleBinaryFlag(10, false);
                bFlag.SetFlag(15);
            }
            catch (Exception e)
            {
                string errorMsg = "Position must be lesser than length";
                bool pass = e.Message.Contains(errorMsg);
                Assert.True(pass);
            }
        }
        [Fact]
        public void TestResetFlagExceedsLength()
        {
            try
            {
                MultipleBinaryFlag bFlag = new MultipleBinaryFlag(10, false);
                bFlag.ResetFlag(15213);
            }
            catch (Exception e)
            {
                string errorMsg = "Position must be lesser than length";
                bool pass = e.Message.Contains(errorMsg);
                Assert.True(pass);
            }
        }
    }
}