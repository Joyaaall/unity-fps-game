# FPS Game (In Progress) 🎮

A first-person shooter game currently under active development, built with Unity and the Universal Render Pipeline (URP).

## 📌 Overview

This project is a work-in-progress FPS game featuring custom character movement mechanics, camera look handling using Unity's new Input System, modular prefabs, and test PvP environments.

## 🚀 Current Features

- **Player Controller**:
  - Smooth walking and sprint movement (`player_motor.cs`)
  - Jumping and gravity handling
  - Mouse look and vertical camera clamping (`player_look.cs`)
- **Input System**:
  - Configured with Unity's new Input System (`player_control.inputactions` & `input_manager.cs`)
- **Level & Assets**:
  - Custom PvP test map (`pvp_map.fbx`) with PBR textures and materials
  - Player prefab setup with camera and character controller

## 🛠️ Built With

- **Engine**: Unity (URP - Universal Render Pipeline)
- **Language**: C#
- **Input**: Unity New Input System

## 📂 Project Structure

- `Assets/script/`: Gameplay and character control scripts
- `Assets/prefabs/`: Player and environment prefabs
- `Assets/Scenes/`: Game scenes and 3D environment assets
- `Assets/Settings/`: URP graphics and pipeline configuration

## 🚧 Roadmap

- [ ] Weapon handling & shooting mechanics
- [ ] Enemy AI / Target dummies
- [ ] Health and damage system
- [ ] UI / HUD (crosshair, ammo, health bar)
- [ ] Audio and sound effects
