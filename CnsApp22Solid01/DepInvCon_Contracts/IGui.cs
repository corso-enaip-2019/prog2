using System;

namespace DepInvCon_Contracts
{
    public interface IGui
    {
        int ReadInt(string message);
        void Write(string message);
    }

    public interface IMath
    {
        bool IsPrime(int number);
    }
}