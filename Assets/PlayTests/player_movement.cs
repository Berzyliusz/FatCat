using Assets.UnitTestingScripts;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using NSubstitute;
using UnityEngine.TestTools;

public class player_movement
{
    [UnityTest]
    public IEnumerator witch_positive_vertical_input_moves_forward()
    {
        GameObject playerGameObject = new GameObject("Player");
        Player player = playerGameObject.AddComponent<Player>();
        player.PlayerInput = Substitute.For<IPlayerInput>();
        player.PlayerInput.Vertical.Returns(1f);

        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.SetParent(playerGameObject.transform);
        cube.transform.localPosition = Vector3.zero;

        yield return new WaitForSeconds(0.3f);

        Assert.IsTrue(player.transform.position.z > 0f);
        Assert.AreEqual(0, player.transform.position.x);
        Assert.AreEqual(0, player.transform.position.y);
    }
}
