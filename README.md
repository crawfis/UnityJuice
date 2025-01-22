# UnityJuice
Juice Framework for Unity. Using it to show spawning and animate sampling and maze generation algorithms.

Look at the two Sample Scenes for how to use:
- ClickToSpawn - plays the juice as the object spawns
- SpawnReplay - Keeps track of the spawning order and adds two buttons to the SpawnReplayJuice class. One to add or replace the current juice and then another to replay the spawning.

Both subscribe to an event that a prefab was created.
Juice is defined in ScriptableObjects:
- AudioJuice - play audio on spawning
- EffectJuice - spawn a temperary object (usually a Vfx or particle system), deleting it after a fixed amount of time.
- NoOpJiuce - do nothing
- RotateAboutJuice - rotate the object about an axis according to the rotation curve.
- ScaleUpJuice - scale the object according to the rotation curve.
- TranslateJuice - translate the object in a fixed direction an amount according to the rotation curve.
- SequentialJuice - play a list of juices in order, waiting until one is finished before starting the other.
- ParallelJuices - play a list of juices together.

The JuicePlayer class is a helper class to Instantiate a juice template and the play the resulting instance.
