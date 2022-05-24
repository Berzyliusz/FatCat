using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Timer;
using NSubstitute;

public class TimerTests
{
    [Test]
    public void CreatedHandleIsNotNull()
    {
        // Arrange
        var timer = Timer.SetTimer(null, 1);

        // Assert
        Assert.AreNotEqual(timer, null);
    }

    [Test]
    [TestCase(1.0f)]
    [TestCase(3.0f)]
    [TestCase(21.37f)]
    public void TimerHasZeroRemainingTimeAfterTickingItsStartingAmount(float duration)
    {
        // Arrange
        var updater = Substitute.For<ITimerUpdater>();
        TimerHandle handle = new(duration, updater, null, null);

        // Act
        handle.Tick(duration);

        // Assert
        Assert.AreEqual(0.0f, handle.RemainingTime);

    }

    [Test]
    [TestCase(1.0f)]
    [TestCase(3.0f)]
    [TestCase(21.37f)]
    public void CanceledTimer_IsNotCounting(float duration)
    {
        // Arrange
        var updater = Substitute.For<ITimerUpdater>();
        TimerHandle handle = new(duration, updater, null, null);

        // Act
        handle.CancelTimer();
        handle.Tick(1.0f);

        // Assert
        Assert.AreEqual(duration, handle.RemainingTime);
    }

    [Test]
    [TestCase(1.0f)]
    [TestCase(3.0f)]
    [TestCase(21.37f)]
    public void PasuedTimer_IsNotCounting(float duration)
    {
        // Arrange
        var updater = Substitute.For<ITimerUpdater>();
        TimerHandle handle = new(duration, updater, null, null);
        
        // Act
        handle.PauseTimer();
        handle.Tick(1.0f);

        // Assert
        Assert.AreEqual(duration, handle.RemainingTime);
    }
}
