#PlayerController Script

Overview
The `PlayerController` script is responsible for managing the movement, jumping, sprinting, and health of a 2D player character in Unity. It also handles interactions with the user interface, such as displaying a menu when the player dies.

Features
- **Movement**: The player can move left and right using horizontal input.
- **Jumping**: The player can jump if grounded.
- **Sprinting**: The player can sprint by holding down the `Left Shift` key.
- **Health Management**: The player's health is tracked, and upon death, the character is destroyed, and a UI panel is displayed.
- **Ground Detection**: The script uses collision detection to check if the player is on the ground.

---
Usage
Setup Instructions
1. Attach the `PlayerController` script to your 2D player object.
2. Assign the following components in the Unity Inspector:
   - **Move Speed (`moveSpeed`)**: Float value for the player's normal movement speed.
   - **Sprint Speed (`sprintSpeed`)**: Float value for the player's sprinting speed.
   - **Jump Force (`jumpForce`)**: Float value for the player's jump strength.
   - **User Interface (`userInterface`)**: Reference to the `UserInterface` script managing the in-game UI.

Requirements
- The player object must have:
  - A **`Rigidbody2D`** component for physics.
  - A collider for detecting collisions with the ground.
- Ground objects must have the tag **"Ground"** for detection.

---
Public Variables
- `health`: An integer representing the player's health. The player dies when this value reaches 0.

Private Variables
- `_isSprinting`: A flag to indicate if the player is sprinting.
- `_rb`: The player's `Rigidbody2D` for movement and physics.
- `_checkingGround`: An instance of the `GroundStatus` class to track the player's grounded state.

---
Key Methods
### `Move(float horizontalInput)`
Moves the player horizontally based on the input. Adjusts speed depending on whether the player is sprinting.

`Jump()`
Applies an upward force to the player, allowing them to jump if grounded.

`Sprint()`
Enables sprinting, increasing the player's movement speed.

`OnCollisionEnter2D(Collision2D collision)` and `OnCollisionExit2D(Collision2D collision)`
Used to check if the player is on the ground by detecting collisions with objects tagged as "Ground".

---
GroundStatus Class
A helper class to manage the player's grounded state.
- **`isGrounded`**: Boolean flag indicating if the player is on the ground.
- **`CheckOnGround(Collider2D collider)`**: Sets `isGrounded` to `true` if the player collides with a "Ground" object.
- **`NotOnGround()`**: Sets `isGrounded` to `false`.

---
Example UI Integration
To connect the script with a user interface, create a separate `UserInterface` script that manages health display and death menus. Assign the `UserInterface` script to the `userInterface` field in the `PlayerController` inspector.

```csharp
public void ShowPanelMenuOnDie()
{
    panelMenu.SetActive(true);
}
```

---
Notes
- Make sure to tag all ground objects with **"Ground"** for collision detection.
- Ensure the `UserInterface` script is assigned, or add a null check in the code to avoid runtime errors.

---
© 2024 FoxKK - Developer Portfolio 
