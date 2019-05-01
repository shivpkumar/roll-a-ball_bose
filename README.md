# Roll-a-Ball Bose AR Tutorial

![Image of Roll-a-Ball](https://assetstorev1-prd-cdn.unity3d.com/key-image/93cb3095-8ffd-4a8e-bea0-58233c41fadc.jpg)

This tutorial adapts Unity's basic [Roll-a-Ball tutorial](https://unity3d.com/kr/learn/tutorials/s/roll-ball-tutorial) for the Bose AR glasses. Rather than using your keyboard arrows to roll the ball around, you're going to use the motion sensors embedded in your glasses to move the ball around by just moving your head!

We're assuming you're already somewhat familiar with Unity, but if not, go ahead and complete the Roll-a-Ball tutorial first. That'll teach you the basics of Unity. Once you're done, head on back here to get it working with your Bose glasses.

## Basic Roll-a-Ball

Ok, let's get the basic Roll-a-ball working in Unity first. By the end of this setup, you should be able to use your keyboard arrows to win the game. Here's what you'll need to do:

1. Clone the repo `git clone git@github.com:shivpkumar/roll-a-ball_bose.git`
1. Open up Unity and open up the project you just cloned to your machine
1. Press play and use your keyboard arrows to roll the ball and collect pick-ups
1. Win!

## Using the Bose AR Glasses

Well, that was easy. Now let's do something a bit more interesting: roll the ball with our Bose AR glasses!

### Step 1: Install the Bose AR SDK for Unity

The first thing we'll need to do is add the latest version of the Bose AR SDK to your project. Head on over to the Bose Developer Portal and download the latest Unity SDK: https://developer.bose.com/bose-ar/bose-ar-downloads (you will have to create an account if this is your first time visiting the portal). Once downloaded, import the SDK package into Unity via Assets >> Import Package >> Custom Package.

### Step 2: Hook up Player to Bose AR glasses

Next, let's update our Player object (the ball) with the logic to move as we tilt our Bose AR glasses in different directions. Open up `PlayerController.cs` and update it with the following lines of code:

```csharp
using Bose.Wearable;
.
.
.

public class PlayerController : MonoBehaviour {
    
    .
    .
    .
    WearableControl wearableControl;
    
    void Start() {
        .
        .
        .
        
        wearableControl = WearableControl.Instance;

        WearableRequirement requirement = GetComponent<WearableRequirement>();
        if (requirement == null) {
            requirement = gameObject.AddComponent<WearableRequirement>();
        }
        requirement.EnableSensor(SensorId.Rotation);
        requirement.SetSensorUpdateInterval(SensorUpdateInterval.EightyMs);
    }
    
    void FixedUpdate() {
        if (wearableControl.ConnectedDevice == null) {
            return;
        }

        SensorFrame sensorFrame = wearableControl.LastSensorFrame;

        float moveHorizontal = sensorFrame.rotation.value.z;
        float moveVertical = sensorFrame.rotation.value.x;
        
        // Disable keyboard behavior
        // float moveHorizontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");
        
        .
        .
        .
    }
    
    .
    .
    .
}
```

### Step 3: Connect Bose AR glasses to the Unity scene

If you were to hit play right now (go on, try it!), nothing works. Even if you plug in your Bose AR glasses via USB to your computer, it still won't work. The reason is because there's no logic in the scene that tells Unity to look for connected Bose devices when the scene starts. In order to do this, we'll have to add a couple new objects to the scene:

Find the **WearableConnectUIPanel** prefab (as shown below) and drag it into the scene.

![WearableConnectUIPanel prefab](https://user-images.githubusercontent.com/3858670/57002661-d75c3200-6b75-11e9-87a8-709511c17551.png)

Now, when you press play, you'll see a Bose UI panel that searches for a connected Bose AR device. It hasn't located your Bose AR glasses yet. We'll get to that in the next step.

![Searching](https://user-images.githubusercontent.com/3858670/57002943-e3e18a00-6b77-11e9-8bc3-e9a0bfe4a18a.png)

To force Unity to find the Bose AR glasses connected via USB:

1. Create an Empty GameObject in the scene and call it "WearableControl"
1. Click the **Add Component** button, search for "WearableControl", and add the component
1. In the **WearableControl** component, change the **Editor Default Provider** to **USB Provider**

Your scene should look something like this:

![Finished Unity scene](https://user-images.githubusercontent.com/3858670/57003102-22c40f80-6b79-11e9-8560-2e8db857b3ed.png)

### Step 4: Try it out!

Now, when you press play with your Bose AR glasses connected via USB, the Bose UI panel should show that its found your "Bose Frames". Click that button, wait for it to connect, and start playing. You should be able to collect all the pick ups by simply tilting your head left and right, forward and backward. Nice work!
