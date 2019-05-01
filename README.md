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
