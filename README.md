# 🕹️ Catch the Monster - Unity 3D RPG Game

> A simple first-person RPG game built with Unity where players complete quests, defeat monsters, and trade items with NPCs.

## Project Overview

This project is a lightweight 3D RPG game developed in Unity.  
The core mechanics include:

- Accepting and completing quests
- Fighting monsters with skills
- Receiving gold as a reward
- Purchasing and equipping items from NPC merchants

The gameplay cycle allows the player to engage in combat, manage character stats, and interact with the game world in a simple but meaningful way.

##  Game Features

### Quest System
- Receive quests from a Collector NPC
- Complete quests by defeating specific monsters
- Receive rewards (e.g., 15 gold) upon quest completion

### Monster Combat
- Missile skill with cooldown
- Damage application and hit effects
- Enemy AI: chase and attack the player
- Monster respawn system

### Character System
- Character information popup
- Equipment stats update character attributes
- Inventory management

### Item Trading
- NPC merchant dialogue and interaction
- Purchase/sell items with gold
- Dynamic item info panel
- Gold calculation and slot management

### Others
- Camera follows player
- NPC interactions with Mayor, Merchant, and Collector
- Monster patrols only within spawn areas

## Key Scripts

### `PlayerController.cs`
Handles:
- Click-based movement (via raycasting)
- Enemy/NPC targeting
- Character info panel activation
- Inventory interaction

### `QuestScript.cs`
Handles:
- Quest initiation logic
- Quest completion and reward distribution
- Communication between NPC and player quest state

##  Development Stack

- **Engine**: Unity
- **Language**: C#
- **Assets**: Free Unity assets for NPCs and environments
- **UI**: Unity UI system with Canvas, Panels, and Buttons

## Screenshots

> *(Insert gameplay screenshots here if needed)*

## Reflection

### Expected Outcomes
- Learn basic RPG game structure using Unity
- Understand quest, combat, and inventory systems

### Limitations
- Only one quest implemented
- NPCs (except enemies) lack animations
- Player does not receive damage from monsters

### 🔧 Future Improvements
- Add multiple quests and interactions
- Implement player HP/damage system
- Improve item-use animations and close merchant UI panels correctly

## Author

- Yoo Da Yeon  
  Major in ICT Convergence  
  University project for final semester Unity course

## License

This project is for educational purposes only.
