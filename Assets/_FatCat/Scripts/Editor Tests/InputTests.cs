using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class InputTests
{
    [Test]
    public void MouseInput_ReturnsWrongPosition_WhenCantHit()
    {
        //ARRANGE
        var mousePosCalculator = new MouseInputCalculator(new LayerMask(), null);

        //ACT
        Vector2 calculatedPosition = mousePosCalculator.CalculatePosition();

        //ASSERT
        Assert.AreEqual(new Vector2(5000, 5000), calculatedPosition);
    }
}
