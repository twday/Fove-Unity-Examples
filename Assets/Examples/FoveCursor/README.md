# FoveCursor
## An example of a fove cursor
This example demonstrates a cursor that is placed based on a ray cast from both eyes.

This cursor will also work if the user has closed either of their eyes.

### Materials
#### Cursor.mat
A bright red material to make the cursor more noticeable

### Prefabs
#### Cursor.prefab
A cursor prefab for use in other projects

### Scenes
#### FoveCursor.unity
The example scene file

### Scripts
#### FoveCursor.cs
This script gets the raycast for each eye and then places the cursor accordingly

If both eyes are open:
 + Check if both raycasts have hit an object
 + If yes, places the cursor at the midpoint between the two hit locations
 + Otherwise, places the cursor at the midpoint of two points that are 3 units infront of the user

If either eys is closed:
 + Check if the open eyes raycast has hit an object
 + If yes, places cursor at the hit location
 + Otherwise, places the cursor 3 units in front of the users open eye
