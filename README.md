# Last Signal - Developer Guide

Welcome to the development of **Last Signal**. This project is structured as a Unity 3D project.

## 🚀 Getting Started

### 1. Unity (The Game)
- Open the root folder in Unity.
- Attach `NetworkManager.cs` to a persistent object.
- Ensure the `backendUrl` is set correctly.

### 2. Backend (Python API)
- `cd backend`
- Install dependencies: `pip install fastapi uvicorn`
- Run: `python main.py`
- API docs will be at: `http://localhost:8000/docs`

### 3. Frontend (Hunter Dashboard)
- `cd frontend`
- Install dependencies: `npm install`
- Run: `npm run dev`
- Open your browser to view the sci-fi dashboard.

## 🕹️ Controls
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
