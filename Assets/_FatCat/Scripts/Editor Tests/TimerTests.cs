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
    public void TimerIsFinishing(float duration)
    {

    }

    [Test]
    public void PasuedTimer_IsNotCounting()
    {
        // Arrange
        var timer = Timer.SetTimer(null, 1);
        timer.PauseTimer();

        var updater = Substitute.For<ITimerUpdater>();
        
        // We have to simulate tick here...
        // Act

        // Assert
    }
}
