namespace CinemaX.Messager.Services.Base;

using CinemaX.Messager.Messages.Base;
using System;

public interface IMessenger
{
    void Send<TKey>(TKey arg) where TKey : IMessage;
    void Subscribe<TKey>(Action<IMessage> action) where TKey : IMessage;
}