# Last Signal - Developer Guide

Welcome to the development of **Last Signal**. This project is structured as a Unity 3D project.

## 🚀 Getting Started
1. **Open in Unity:** Launch Unity Hub and open this folder (`Last-Signal-Game`) as a project. Use Unity 2021.3 LTS or newer.
2. **Setup Scene:**
   - Create a new 3D Scene.
   - Add a `CharacterController` to a Player object.
   - Attach the `PlayerController.cs` and `MouseLook.cs` scripts.
   - Create a Camera as a child of the Player and assign it to the `MouseLook` script.
3. **Tools:**
   - Attach `Flashlight.cs` to a child object with a Light component.
   - Attach `SignalScanner.cs` to the player.
4. **Managers:**
   - Create an empty GameObject named `Systems` and attach `ResourceManager.cs` and `MemoryMissionManager.cs`.

## 🎮 Controls
- **WASD:** Movement
- **Mouse:** Look around
- **Space:** Jump
- **Left Shift:** Run
- **F:** Toggle Flashlight
- **Tab (Planned):** Open Signal Scanner UI

## 📡 Signal Hunting
- Place a `SignalSource.cs` on any object you want the player to find.
- Set a unique `SignalID` and `DetectionRadius`.
- Ensure the object is on a Layer that matches the `Signal Layer` mask in the `SignalScanner` script.

## 🎨 Art Style
- Aim for **Low Poly** assets.
- Use the `Assets/Models` folder for your meshes.
- Use `Assets/Materials` for simple flat-shaded materials.

## 🧩 Current Progress
- [x] Player Movement & Mouse Look
- [x] Flashlight & Scanner core logic
- [x] Resource Management (Battery/Scrap)
- [x] Puzzle Logic (Frequency Match)
- [x] Memory Mission transitions
