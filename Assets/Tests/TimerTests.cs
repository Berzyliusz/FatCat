using NUnit.Framework;

public class TimerTests
{
    [Test]
    [TestCase(1f)]
    [TestCase(5f)]
    [TestCase(36.3f)]
    public void StartingDurationIsSet(float duration)
    {
        Timer timer = new(duration);

        Assert.AreEqual(duration, timer.RemainingSeconds);
    }

    [TestCase(-1f)]
    [TestCase(-5f)]
    [TestCase(-36.3f)]
    public void NegativeDuration_ResultsAtZero(float duration)
    {
        Timer timer = new(duration);

        Assert.AreEqual(0f, timer.RemainingSeconds);
    }

    [Test]
    public void TickingBelowZeroSeconds_StopsAtZero()
    {
        Timer timer = new(1f);

        timer.Tick(2f);

        Assert.AreEqual(0f, timer.RemainingSeconds);
    }

    [Test]
    public void TimerEnds_EventIsRaised()
    {
        Timer timer = new(1f);

        bool eventHasBeenRaised = false;
        timer.OnTimerEnd += () => eventHasBeenRaised = true;

        timer.Tick(1f);

        Assert.IsTrue(eventHasBeenRaised);
    }

    [Test]
    public void TimerDoesNotEnd_EventIsNotRaised()
    {
        Timer timer = new(1f);

        bool eventHasBeenRaised = false;
        timer.OnTimerEnd += () => eventHasBeenRaised = true;

        timer.Tick(0.5f);

        Assert.IsFalse(eventHasBeenRaised);
    }
}
